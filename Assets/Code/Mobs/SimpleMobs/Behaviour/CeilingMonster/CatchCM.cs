using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchCM : StateMachine
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
        tip.GetComponent<Animator>().SetBool("Catched", true);
    }

    public override void OnUpdateState()
    {
        tongue.transform.position -= Vector3.down * Time.deltaTime * 5;

        if (Physics2D.OverlapArea(new Vector2(tip.position.x - 0.3f, tip.position.y), new Vector2(tip.position.x + 0.3f, tip.position.y), ContactList.layerMaskEnemy))
        {
            mob.ChangeState<EatCM>();
        }
    }

    public override void OnExitState()
    {
        tip.GetComponent<Animator>().SetBool("Catched", false);
    }
    



}
