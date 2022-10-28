using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BallArena
{
    public class HistoryStorage
    {
        private List<HistoryData> history = new List<HistoryData>();

        public List<HistoryData> History => history;

        public void AddHistory(List<HistoryData> history)
        {
            this.history.AddRange(history);
        }

        public void Clear()
        {
            history.Clear();
        }
    }
}