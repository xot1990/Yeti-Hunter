using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunYeti : StateMachine
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
        mob.animator.SetBool("Run", true);
        mob.isRuning = true;
        mob.audioSourse.clip = mob.step;
    }

    public override void OnUpdateState()
    {
        if (Mathf.Abs(mob.Rbody.velocity.x) < mob.maxSpeed && mob.isRuning)
        {
            Vector3 f = transform.right * Time.deltaTime * mob.speed;
            mob.Rbody.AddForce(f, ForceMode2D.Impulse);
        }

        if (!Physics2D.OverlapArea(new Vector2(mob.foot.position.x, mob.foot.position.y), new Vector2(mob.foot.position.x, mob.foot.position.y - 0.5f), ContactList.layerMaskGround))
        {
            mob.Rotation();
        }

        if (Physics2D.OverlapArea(new Vector2(mob.eya.position.x, mob.eya.position.y), new Vector2(mob.eya.position.x + 0.3f, mob.eya.position.y), ContactList.layerMaskGround))
        {
            mob.Rotation();
        }

        if (Physics2D.OverlapArea(new Vector2(mob.eya.position.x, mob.eya.position.y), new Vector2(mob.eya.position.x + 0.6f, mob.eya.position.y), ContactList.layerMaskPlayer))
        {
            mob.ChangeState<AttackYeti>();
        }
    }

    public override void OnExitState()
    {
        mob.audioSourse.clip = null;
        mob.animator.SetBool("Run", false);
        mob.isRuning = false;
    }
    



}
