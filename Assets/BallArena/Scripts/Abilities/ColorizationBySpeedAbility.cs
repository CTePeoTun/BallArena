using UnityEngine;

public class ColorizationBySpeedAbility : Ability
{
    public override string Id => AbilityIds.ColorizationBySpeed;
    public override bool IsCondiitonForUse => SpeedIsChanged() && moveable.Speed > 3;

    private IColored colored;
    private IMoveable moveable;
    private float speed;

    public override void OnInit(Unit unit)
    {
        colored = (IColored)unit;
        moveable = (IMoveable)unit;
    }

    public override void Update()
    {
        if(IsCondiitonForUse)
        {
            colored.SetColor(Color.green);
        }
    }

    private bool SpeedIsChanged()
    {
       if (speed != moveable.Speed)
        {
            speed = moveable.Speed;
            return true;
        }
        return false;
    }
}
