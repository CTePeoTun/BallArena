using System;
using System.Collections.Generic;
using UnityEngine;

namespace BallArena
{
    public class UnitsController
    {
        private UnitsPool pool;
        private UnitsCreator unitsCreator;
        private AbilityCreator abilityCreator;
        private IFrameUpdater frameUpdater;
        private List<BaseUnit> units;

        public UnitsController(UnitsPool pool, UnitsCreator unitsCreator, AbilityCreator abilityCreator, IFrameUpdater frameUpdater)
        {
            this.pool = pool;
            this.unitsCreator = unitsCreator;
            this.abilityCreator = abilityCreator;
            this.frameUpdater = frameUpdater;
            units = new List<BaseUnit>();
        }

        public void Spawn(List<HistoryData> history)
        {
            SpawnOriginalUnit();
            foreach (var data in history)
            {
                SpawnShadowUnit(data);
            }
        }

        public void Start()
        {
            foreach (var unit in units)
            {
                unit.Start();
            }
        }

        private void SpawnOriginalUnit()
        {
            OriginalUnit unit = GetUnit<OriginalUnit>();
            unit.InitAbilities();
        }

        private void SpawnShadowUnit(HistoryData data)
        {
            ShadowUnit unit = GetUnit<ShadowUnit>();
            unit.InitAbilities(data);
        }

        private TypeUnit GetUnit<TypeUnit>() where TypeUnit : BaseUnit, new()
        {
            UnitView view = GetViewFromPool();
            TypeUnit unit = unitsCreator.Get<TypeUnit>();
            unit.Init(view, abilityCreator);
            frameUpdater.OnUpdate += unit.Update;
            units.Add(unit);
            return unit;
        }

        private UnitView GetViewFromPool()
        {
            UnitView view = pool.Get();
            view.transform.SetParent(null);
            view.transform.localPosition = Vector3.zero;
            return view;
        }

        public List<HistoryData> GetHistoryDataFromUnits()
        {
            List<HistoryData> history = new List<HistoryData>();
            foreach (var unit in units)
            {
                if (unit is IKeepable)
                {
                    HistoryData data = new HistoryData();
                    if (unit is IKeepablePath)
                    {
                        data.Paths = new List<PathData>(((IKeepablePath)unit).Points);
                    }
                    if (unit is IKeepableColor)
                    {
                        data.Colors = new List<Color>(((IKeepableColor)unit).Colors);
                    }
                    history.Add(data);
                }
            }
            return history;
        }

        public void Stop()
        {
            foreach (var unit in units)
            {
                unit.Stop();
            }
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
}