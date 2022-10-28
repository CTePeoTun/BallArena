using UnityEngine;

public class Boostrap : MonoBehaviour
{
    [SerializeField] private UnitsPool unitsPool;
    [SerializeField] private Updater updater;
    [SerializeField] private InputController inputController;

    private AbilityCreator abilityCreator;
    private UnitsCreator unitsCreator;
    private UnitsController unitsController;
    private GameController gameController;

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
        gameController = new GameController(unitsController);
        inputController.OnRestart = gameController.Restart;

    }

}
