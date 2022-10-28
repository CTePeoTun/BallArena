using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : Product
{
    public enum StateUnit 
    {
        None, Active
    }

    public AbilityCreator abilityCreator; //TODO: mv Singleton

    private StateUnit state;
    protected List<Ability> abilities;

    public List<Ability> Abilities => abilities;
    public UnitView View { get; set; }

    public Unit()
    {
        abilities = new List<Ability>();
        state = StateUnit.None;
    }

    protected abstract void InitAbilities();

    public void Init()
    {
        state = StateUnit.Active;
        InitAbilities();
    }

    public virtual void Start()
    {
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
        foreach (var ability in abilities)
        {
            ability.Stop();
        }
    }

    public void Clear()
    {
        state = StateUnit.None;
        abilities.Clear();
        View.ReturnToPool();
    }

}
