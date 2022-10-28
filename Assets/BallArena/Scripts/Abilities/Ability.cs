namespace BallArena
{
    public abstract class Ability : Product
    {
        public abstract bool IsCondiitonForUse { get; }

        public abstract void Update();
        public abstract void Init(Unit unit);

        public virtual void Start()
        {

        }

        public virtual void Stop()
        {

        }
    }
}