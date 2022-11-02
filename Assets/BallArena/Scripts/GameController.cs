using System.Collections.Generic;

namespace BallArena
{
    public class GameController
    {
        private UnitsController unitsController;
        private HistoryStorage historyStorage;

        public GameController(UnitsController unitsController, HistoryStorage historyStorage)
        {
            this.unitsController = unitsController;
            this.historyStorage = historyStorage;
        }

        public void Start()
        {
            unitsController.Spawn(historyStorage.History);
            unitsController.Start();
        }

        public void Restart()
        { 
            Stop();
            Start();
        }

        private void Stop()
        {
            unitsController.Stop();
            AddHistoryToStorage();
            unitsController.Clear();
        }

        private void AddHistoryToStorage()
        {
            List<HistoryData> history = unitsController.GetHistoryDataFromUnits();
            historyStorage.AddHistory(history);
        }

    }
}