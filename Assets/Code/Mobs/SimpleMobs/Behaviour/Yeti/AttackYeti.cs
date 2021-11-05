using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackYeti : StateMachine
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
        mob.animator.SetBool("Strike", true);
        mob.Rbody.velocity = Vector2.zero;
        mob.audioSourse.clip = mob.attack;
    }

    public override void OnUpdateState()
    {        
        if (!Physics2D.OverlapArea(new Vector2(mob.eya.position.x, mob.eya.position.y - 0.5f), new Vector2(mob.eya.position.x + 1, mob.eya.position.y), ContactList.layerMaskPlayer))
        {
            mob.ChangeState<RunYeti>();
        }
    }

    public override void OnExitState()
    {
        mob.audioSourse.clip = null;
        mob.animator.SetBool("Strike", false);
    }

    
}
