using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yeti : AbstractMob
{

    

    void Start()
    {
        ChangeState<RunYeti>();
    }

    private void FixedUpdate()
    {
        state.OnUpdateState();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Projectile"))
        {
            Hit((int)collision.gameObject.GetComponentInChildren<Projectile>().DamageArmor);
            collision.GetComponentInChildren<Animator>().SetBool("Enter", true);
            collision.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            collision.name = "DamegeEffect";
            collision.GetComponent<Rigidbody2D>().isKinematic = true;
            collision.GetComponent<BoxCollider2D>().enabled = false;
            collision.transform.parent = transform;
            if (hp > 0) ChangeState<HartYeti>();
            else ChangeState<DeathYeti>();
        }
    }
}
