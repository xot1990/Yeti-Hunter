using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuntCM : StateMachine
{

    AbstractMob mob;
    RaycastHit2D hit2D;


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
        mob.animator.SetBool("OnEat", false);
        mob.animator.SetBool("OnDown", false);
    }

    public override void OnUpdateState()
    {
        hit2D = Physics2D.Raycast(mob.eya.transform.position, new Vector2(-0.1f,-0.9f), 30f, ContactList.layerMaskPlayer, Mathf.Infinity, Mathf.Infinity);

        if (hit2D)
        {
            mob.ChangeState<AttackCM>();
            return;
        }

        hit2D = Physics2D.Raycast(mob.eya.transform.position, new Vector2(0.1f, -0.9f), 30f, ContactList.layerMaskPlayer, Mathf.Infinity, Mathf.Infinity);

        if (hit2D)
        {
            mob.ChangeState<AttackCM>();
        }
    }

    public override void OnExitState()
    {
        mob.animator.SetBool("OnDown", false);
    }

    
}
