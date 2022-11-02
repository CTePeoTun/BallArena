using System.Collections.Generic;
using UnityEngine;

namespace BallArena
{
    public abstract class BaseUnit
    {
        public enum StateUnit
        {
            None, Active
        }

        private AbilityCreator abilityCreator;
        private StateUnit state;
        protected UnitView view;
        protected List<BaseAbility> abilities;

        public List<BaseAbility> Abilities => abilities;

        public BaseUnit()
        {
            abilities = new List<BaseAbility>();
            state = StateUnit.None;
        }

        public void Init(UnitView view, AbilityCreator abilityCreator)
        {
            this.view = view;
            this.abilityCreator = abilityCreator;
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

        protected TypeAbility AddAbility<TypeAbility>() where TypeAbility : BaseAbility, new()
        {
            var ability = abilityCreator.Get<TypeAbility>();
            ability.Init(this);
            abilities.Add(ability);
            return ability;
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