using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailCatchCM : StateMachine
{
    AbstractMob mob;
    GameObject tongue;
    Transform tip;

    private void Awake()
    {
        OnGetClass<AbstractMob>();
    }

    private void Start()
    {
        tongue = GetComponentInChildren<Tongue>().gameObject;
        tip = GetComponentInChildren<Tip>().transform;
    }

    public void OnGetClass<T>() where T : AbstractMob
    {
        mob = GetComponent<T>();
    }

    public override void OnEnterState()
    {
        mob.animator.SetBool("OnEat", false);
    }

    public override void OnUpdateState()
    {
        tongue.transform.position -= Vector3.down * Time.deltaTime * 5;

        if (Physics2D.OverlapArea(new Vector2(tip.position.x - 0.3f, tip.position.y), new Vector2(tip.position.x + 0.3f, tip.position.y), ContactList.layerMaskEnemy))
        {
            mob.ChangeState<HuntCM>();
        }
    }

    public override void OnExitState()
    {
        mob.animator.SetBool("OnEat", false);
    }
}
