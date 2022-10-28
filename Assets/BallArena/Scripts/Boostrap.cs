using UnityEngine;

namespace BallArena
{
    public class Boostrap : MonoBehaviour
    {
        [SerializeField] private UnitsPool unitsPool;
        [SerializeField] private Updater updater;
        [SerializeField] private InputController inputController;

        private AbilityCreator abilityCreator;
        private UnitsCreator unitsCreator;
        private UnitsController unitsController;
        private GameController gameController;
        private HistoryStorage historyStorage;

        private void Awake()
        {
            InitCreators();
            InitControllers();
        }

        private void Start()
        {
            gameController.Start();
        }

        private void InitCreators()
        {
            abilityCreator = new AbilityCreator();
            unitsCreator = new UnitsCreator();
        }

        private void InitControllers()
        {
            unitsController = new UnitsController(unitsPool, unitsCreator, abilityCreator, updater);
            historyStorage = new HistoryStorage();
            gameController = new GameController(unitsController, historyStorage);
            inputController.OnRestart = gameController.Restart;

        }

    }
}