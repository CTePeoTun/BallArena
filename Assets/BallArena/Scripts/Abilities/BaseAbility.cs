namespace BallArena
{
    public abstract class BaseAbility
    {
        public abstract bool IsCondiitonForUse { get; }

        public abstract void Update();
        public abstract void Init(BaseUnit unit);

        public virtual void Start()
        {

        }

        public virtual void Stop()
        {

        }
    }
}