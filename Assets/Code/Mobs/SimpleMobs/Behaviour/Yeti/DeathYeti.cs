using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathYeti : StateMachine
{
    AbstractMob mob;

    private void Awake()
    {
        OnGetClass<AbstractMob>();
    }

    public void OnGetClass<T>() where T : AbstractMob
    {
        mob = GetComponent<T>();
    }


    public override void OnEnterState()
    {
        mob.animator.SetBool("Dead", true);
        mob.audioSource.clip = mob.deth;
        Destroy(mob.body);
    }

    public override void OnUpdateState()
    {
        
    }

    public override void OnExitState()
    {
        
    }
}
