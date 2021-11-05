using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabRun : StateMachine
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
        mob.currentState = GetComponent<CrabRun>();
        mob.isRuning = true;
        mob.audioSourse.clip = mob.step;
        if (mob.direction == 0)
        {
            mob.animator.SetBool("RunR", false);
            mob.animator.SetBool("RunL", true);
        }
        else if (mob.direction == 1)
        {
            mob.animator.SetBool("RunL", false);
            mob.animator.SetBool("RunR", true);
        }
        mob.audioSourse.Play();
    }

    public override void OnUpdateState()
    {
        if (mob.direction == 0)
        {
            if (Mathf.Abs(mob.Rbody.velocity.x) < mob.maxSpeed && mob.isRuning)
            {
                Vector2 f = -transform.right * Time.deltaTime * mob.speed;
                mob.Rbody.AddForce(f, ForceMode2D.Impulse);
            }

            if (Physics2D.OverlapArea(new Vector2(mob.transform.position.x - 1.5f, mob.transform.position.y - 0.1f), new Vector2(mob.transform.position.x, mob.transform.position.y + 0.1f), ContactList.layerMaskGround))
            {
                mob.ChangeState<PhaseWait>();
            }
        }
        else if (mob.direction == 1)
        {
            if (Mathf.Abs(mob.Rbody.velocity.x) < mob.maxSpeed && mob.isRuning)
            {
                Vector2 f = transform.right * Time.deltaTime * mob.speed;
                mob.Rbody.AddForce(f, ForceMode2D.Impulse);
            }

            if (Physics2D.OverlapArea(new Vector2(mob.transform.position.x, mob.transform.position.y - 0.1f), new Vector2(mob.transform.position.x + 1.5f, mob.transform.position.y + 0.1f), ContactList.layerMaskGround))
            {
                mob.ChangeState<PhaseWait>();
            }
        }
        
    }

    public override void OnExitState()
    {
        mob.animator.SetBool("RunR", false);
        mob.animator.SetBool("RunL", false);
        mob.isRuning = false;
        mob.audioSourse.clip = null;
    }

   
}
