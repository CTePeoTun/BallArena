using System.Collections.Generic;

namespace BallArena
{
    public abstract class Unit : Product
    {
        public enum StateUnit
        {
            None, Active
        }

        public AbilityCreator abilityCreator;

        private StateUnit state;
        protected UnitView view;
        protected List<Ability> abilities;

        public List<Ability> Abilities => abilities;

        public Unit()
        {
            abilities = new List<Ability>();
            state = StateUnit.None;
        }

        protected abstract void InitAbilities();

        public void Init(UnitView view)
        {
            this.view = view;
            InitAbilities();
        }

        public virtual void Start()
        {
            state = StateUnit.Active;
            foreach (var ability in abilities)
            {
                ability.Start();
            }
        }

        public void Update()
        {
            if (state == StateUnit.Active)
            {
                foreach (var ability in abilities)
                {
                    ability.Update();
                }
            }
        }

        public void AddAbility(string abilityId)
        {
            var ability = abilityCreator.GetById(abilityId);
            ability.Init(this);
            abilities.Add(ability);
        }

        public virtual void Stop()
        {
            state = StateUnit.None;
            foreach (var ability in abilities)
            {
                ability.Stop();
            }
        }

        public void Clear()
        {
            abilities.Clear();
            view.ReturnToPool();
        }

    }
}