public abstract class Ability : Product
{
    protected Unit unit;

    public abstract bool IsCondiitonForUse { get; }
    
    public abstract void Update();
    public abstract void OnInit(Unit unit);

    public void Init(Unit unit)
    {
        this.unit = unit;
        OnInit(unit);
    }

    public virtual void Start()
    {

    }

    public virtual void Stop()
    {

    }
}
