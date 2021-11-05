using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatCM : StateMachine
{
    AbstractMob mob;
    GameObject tongue;
    float time = 0;

    private void Awake()
    {
        OnGetClass<AbstractMob>();
    }

    private void Start()
    {
        tongue = GetComponentInChildren<Tongue>().gameObject;
    }

    public void OnGetClass<T>() where T : AbstractMob
    {
        mob = GetComponent<T>();
    }

    public override void OnEnterState()
    {
        mob.animator.SetBool("OnEat", true);
        Destroy(GetComponentInChildren<Player_Test>().gameObject);
    }

    public override void OnUpdateState()
    {
        time += Time.deltaTime;

        if (time >= 1) 
        {
            mob.ChangeState<HuntCM>();
        }
    }

    public override void OnExitState()
    {
        mob.animator.SetBool("OnEat", false);
    }
}
