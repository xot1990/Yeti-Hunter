using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCM : StateMachine
{
    AbstractMob mob;
    GameObject tongue;
    Transform tip;
    Collider2D CatchetEnemy;

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
        mob.animator.SetBool("OnDown", true);
    }

    public override void OnUpdateState()
    {
        tongue.transform.position += Vector3.down * Time.deltaTime * 15;

        if (Physics2D.OverlapArea(new Vector2(tip.position.x - 0.3f, tip.position.y), new Vector2(tip.position.x + 0.3f, tip.position.y), ContactList.layerMaskPlayer))
        {
            CatchetEnemy = Physics2D.OverlapArea(new Vector2(tip.position.x - 0.3f, tip.position.y), new Vector2(tip.position.x + 0.3f, tip.position.y), ContactList.layerMaskPlayer);
            CatchetEnemy.transform.parent = tip.transform;
            CatchetEnemy.transform.position = new Vector3(tip.position.x, tip.position.y - 0.5f, tip.position.y);
            CatchetEnemy.GetComponent<Rigidbody2D>().gravityScale = 0;
            CatchetEnemy.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            CatchetEnemy.GetComponent<Player_Test>().MaxSpeed = 0;
            mob.ChangeState<CatchCM>();
        }

        if (Physics2D.OverlapArea(new Vector2(tip.position.x - 0.2f, tip.position.y + 0.2f), new Vector2(tip.position.x + 0.2f, tip.position.y - 0.2f), ContactList.layerMaskGround))
        {
            Debug.Log("1");
            mob.ChangeState<FailCatchCM>();
        }
    }

    public override void OnExitState()
    {
        mob.animator.SetBool("OnDown", false);
    }
}
