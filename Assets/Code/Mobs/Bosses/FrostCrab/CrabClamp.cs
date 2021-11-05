using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabClamp : StateMachine
{

    AbstractBoss mob;

    private void Awake()
    {
        OnGetClass<AbstractBoss>();
    }

    public void OnGetClass<T>() where T : AbstractBoss
    {
        mob = GetComponent<T>();
    }

    public override void OnEnterState()
    {
        mob.currentState = GetComponent<CrabClamp>();
        mob.animator.SetBool("AttackL", false);
        mob.animator.SetBool("AttackR", false);

    }

    public override void OnUpdateState()
    {
        if (mob.direction == 0)
        {
            mob.animator.Play("AttackLeft");
            mob.audioSourse.PlayOneShot(mob.attack);
            mob.PhaseTimer++;
        }
        else if (mob.direction == 1)
        {
            mob.animator.Play("AttackRight");
            mob.audioSourse.PlayOneShot(mob.attack);
            mob.PhaseTimer++;            
        }
        mob.ChangeState<PhaseWait>();
    }

    public override void OnExitState()
    {
        if (mob.direction == 0) mob.direction = 1;
        else mob.direction = 0;

        mob.animator.SetBool("AttackL", false);
        mob.animator.SetBool("AttackR", false);
    }

}
