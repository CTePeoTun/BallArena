using UnityEngine;
public class ColorizationByDistance : Ability
{
    public override string Id => AbilityIds.ColorizationByDistance;
    public override bool IsCondiitonForUse => CheckThreeMetersBehind();

    private IColored colored;
    private IMoveable moveable;

    private float lastPoint;

    public override void OnInit(Unit unit)
    {
        colored = (IColored)unit;
        moveable = (IMoveable)unit;
    }

    public override void Update()
    {
        if (IsCondiitonForUse)
        {
            colored.SetColor(Random.ColorHSV());
        }
    }

    private bool CheckThreeMetersBehind()
    {
        if (moveable.DistanceTraveled - lastPoint >= 3)
        {
            lastPoint = moveable.DistanceTraveled;
            return true;
        }
        return false;
    }
}
