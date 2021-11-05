using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCM : StateMachine
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
        mob.audioSourse.clip = mob.deth;
        Destroy(mob.Rbody);
    }

    public override void OnUpdateState()
    {
        
    }

    public override void OnExitState()
    {
        
    }
}
