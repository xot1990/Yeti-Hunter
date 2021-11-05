using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseWait : StateMachine
{

    AbstractBoss mob;
    float time;

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
        time = 0;
    }

    public override void OnUpdateState()
    {
        time += Time.deltaTime;

        if (time >= 2f)
        {
            if (mob.currentState == GetComponent<CrabRun>())
            {
                mob.ChangeState<CrabClamp>();
            }
            else if (mob.currentState == GetComponent<CrabFastRun>())
            {
                mob.ChangeState<CrabClamp>();
            }
            else if (mob.currentState == GetComponent<CrabClamp>())
            {
                if (mob.PhaseTimer >= 6) mob.ChangeState<CrabFastRun>();
                else mob.ChangeState<CrabRun>();
            }
        }
        
    }

    public override void OnExitState()
    {
        time = 0;
    }

}
