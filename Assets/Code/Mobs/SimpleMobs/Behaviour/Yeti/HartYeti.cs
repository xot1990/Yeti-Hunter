using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HartYeti : StateMachine
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
        mob.Rbody.velocity = Vector2.zero;
        mob.animator.SetBool("Hit", true);
        mob.audioSourse.clip = mob.hart;
    }

    public override void OnUpdateState()
    {
        mob.audioSourse.Play();
        mob.ChangeState<RunYeti>();
    }

    public override void OnExitState()
    {        
        mob.animator.SetBool("Hit", false);
    }
}
