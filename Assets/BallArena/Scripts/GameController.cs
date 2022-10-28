using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameController
{
    private UnitsController unitsController;
    private List<HistoryData> history;

    public GameController(UnitsController unitsController)
    {
        this.unitsController = unitsController;
        history = new List<HistoryData>();
    }

    public void Start()
    {
        unitsController.Spawn(history);
    }

    public void Restart()
    {
        SaveHistory();
        unitsController.Clear();        
        unitsController.Spawn(history);
    }

    private void SaveHistory()
    {
        List<HistoryData> history = unitsController.GetHistoryRealUnits();
        this.history.AddRange(history);
    }

}
