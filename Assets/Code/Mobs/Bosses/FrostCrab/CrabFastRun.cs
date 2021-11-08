using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabFastRun : StateMachine
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
        mob.PhaseTimer = 0;
        mob.currentState = GetComponent<CrabFastRun>();
        mob.isRuning = true;
        mob.audioSource.clip = mob.step;
        mob.maxSpeed = 12;

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
        mob.audioSource.Play();
    }

    public override void OnUpdateState()
    {
        

        if (mob.direction == 0)
        {
            if (Mathf.Abs(mob.body.velocity.x) < mob.maxSpeed && mob.isRuning)
            {
                Vector2 f = -transform.right * Time.deltaTime * mob.speed;
                mob.body.AddForce(f, ForceMode2D.Impulse);
            }

            if (Physics2D.OverlapArea(new Vector2(mob.transform.position.x - 1.5f, mob.transform.position.y - 0.1f), new Vector2(mob.transform.position.x, mob.transform.position.y + 0.1f), ContactList.layerMaskGround))
            {
                if (mob.PhaseTimer >= 10)
                {
                    mob.ChangeState<PhaseWait>();
                    return;
                }

                if (mob.direction == 0)
                {
                    mob.direction = 1;

                    mob.animator.SetBool("RunL", false);
                    mob.animator.SetBool("RunR", true);
                }
                else
                {
                    mob.direction = 0;
                    mob.animator.SetBool("RunR", false);
                    mob.animator.SetBool("RunL", true);
                }

                mob.PhaseTimer++;
            }
        }
        else if (mob.direction == 1)
        {
            if (Mathf.Abs(mob.body.velocity.x) < mob.maxSpeed && mob.isRuning)
            {
                Vector2 f = transform.right * Time.deltaTime * mob.speed;
                mob.body.AddForce(f, ForceMode2D.Impulse);
            }

            if (Physics2D.OverlapArea(new Vector2(mob.transform.position.x, mob.transform.position.y - 0.1f), new Vector2(mob.transform.position.x + 1.5f, mob.transform.position.y + 0.1f), ContactList.layerMaskGround))
            {
                if (mob.PhaseTimer >= 10)
                {
                    mob.ChangeState<PhaseWait>();
                    return;
                }

                if (mob.direction == 0)
                {
                    mob.direction = 1;

                    mob.animator.SetBool("RunL", false);
                    mob.animator.SetBool("RunR", true);
                }
                else
                {
                    mob.direction = 0;
                    mob.animator.SetBool("RunR", false);
                    mob.animator.SetBool("RunL", true);
                }
                mob.PhaseTimer++;
            }
        }
        
    }

    public override void OnExitState()
    {
        mob.animator.SetBool("RunR", false);
        mob.animator.SetBool("RunL", false);
        mob.isRuning = false;
        mob.audioSource.clip = null;
        mob.PhaseTimer = 0;
        mob.maxSpeed = 4;
    }

   
}
