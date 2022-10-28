using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitsController
{
    private UnitsPool pool;
    private UnitsCreator unitsCreator;
    private AbilityCreator abilityCreator;
    private IFrameUpdater frameUpdater;
    private List<Unit> units;

    public UnitsController(UnitsPool pool, UnitsCreator unitsCreator, AbilityCreator abilityCreator, IFrameUpdater frameUpdater)
    {
        this.pool = pool;
        this.unitsCreator = unitsCreator;
        this.abilityCreator = abilityCreator;
        this.frameUpdater = frameUpdater;
        units = new List<Unit>();
    }

    public void Spawn(List<HistoryData> history)
    {
        SpawnUnit(UnitIds.Real);
        foreach (var data in history)
        {
            SpawnUnit(UnitIds.Shadow, data);
        }
    }

    private Unit SpawnUnit(string unitId, HistoryData data = null)
    {
        UnitView view = pool.Get();
        view.transform.SetParent(null);
        view.transform.localPosition = Vector3.zero;
        Unit unit = unitsCreator.GetById(unitId);
        unit.abilityCreator = abilityCreator;
        if (unit is IRepeatablePath)
        {
            ((IRepeatablePath)unit).Points = data.Paths;
        }
        if (unit is IRepeatableColor)
        {
            ((IRepeatableColor)unit).Colors = data.Colors;
        }
        unit.Init();
        unit.View = view;
        unit.Start();
        frameUpdater.OnUpdate += unit.Update;
        units.Add(unit);
        return unit;
    }

    public List<HistoryData> GetHistoryRealUnits()
    {
        List<HistoryData> history = new List<HistoryData>();
        foreach (var unit in units)
        {
            if (unit is IKeepable)
            {
                HistoryData data = new HistoryData();
                if (unit is IKeepablePath)
                {
                    IKeepablePath keepablePath = (IKeepablePath)unit;
                    keepablePath.SaveData();
                    data.Paths = new List<PathData>(keepablePath.Points);
                }
                if (unit is IKeepableColor)
                {
                    data.Colors = new List<ColorData>(((IKeepableColor)unit).Colors);
                }
                history.Add(data);
            }
        }
        return history;
    }

    public void Clear()
    {
        foreach (var unit in units)
        {        
            frameUpdater.OnUpdate -= unit.Update;
            unit.Clear();
        }
        units.Clear();
    }
    
}
