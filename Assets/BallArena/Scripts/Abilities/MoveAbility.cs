using UnityEngine;

public class MoveAbility : Ability
{
    public override string Id => AbilityIds.Move;
    public override bool IsCondiitonForUse => true;
    private IMoveable moveable;
    private IKeepablePath keepablePath;

    public override void OnInit(Unit unit)
    {
        moveable = (IMoveable)unit;
        keepablePath = (IKeepablePath)unit;
    }

    float time = 0;
    public override void Update()
    {
        if (IsCondiitonForUse)
        {
            time += Time.deltaTime;
            if (time >= 1f)
            {
                keepablePath.SaveData();
                GetSpeedAndDirection();
                time = 0;
            }
            Vector3 directionMove = moveable.Direction * moveable.Speed * Time.deltaTime;
            moveable.DistanceTraveled += Vector3.Magnitude(directionMove);
            unit.View.transform.Translate(directionMove);
        }
    }

    private void GetSpeedAndDirection()
    {
        moveable.Speed = GetSpeed();
        moveable.Direction = GetDirection();
    }

    private float GetSpeed()
    {
        return Random.Range(1f, 5f);
    }

    private Vector3 GetDirection()
    {
        return new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f)).normalized;
    }

    public override void Stop()
    {
        keepablePath.SaveData();
        base.Stop();       
    }

    public override void Start()
    {
        GetSpeedAndDirection();
    }
}
