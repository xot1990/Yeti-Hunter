using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrostCrab : AbstractBoss
{    
    
    public bool isDead;
    Collider2D[] colliders;



    void Start()
    {

    }
    

    public void Dead()
    {
        foreach(var C in colliders)
        {
            C.enabled = false;
        }

        GetComponent<Collider2D>().enabled = false;        
        Vector3 f = transform.up * Time.deltaTime * speed/6;
        Rbody.AddForce(f, ForceMode2D.Impulse);
        Rbody.gravityScale = 1;
        StartCoroutine(DelGo());
        FindObjectOfType<Player_Test>().pause = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Projectile" && hp > 0 && !isDead)
        {
            StartCoroutine(AnimHit());
            Hit((int)collision.gameObject.GetComponentInChildren<Projectile>().DamageArmor);
            collision.GetComponentInChildren<Animator>().SetBool("Enter", true);
            collision.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            collision.name = "DamegeEffect";
            collision.GetComponent<Rigidbody2D>().isKinematic = true;
            collision.GetComponent<BoxCollider2D>().enabled = false;
            collision.transform.parent = transform;

            if(hp <= 0)
            {
                Dead();
            }
        }
        
        
    }

    IEnumerator DelGo()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }

    public IEnumerator AnimHit()
    {        
        audioSourse.PlayOneShot(hart);
        float t = 0;
        for (int i = 0; i < 2; i++)
        {
            while (true)
            {
                yield return new WaitForEndOfFrame();
                if (t >= 1) break;
                float g = Mathf.Lerp(1, 0, t);
                float b = Mathf.Lerp(1, 0, t);
                t += 0.05f;
                spriteRenderer.color = new Vector4(1, g, b, 1);

            }

            while (true)
            {
                yield return new WaitForEndOfFrame();
                if (t <= 0) break;
                float g = Mathf.Lerp(1, 0, t);
                float b = Mathf.Lerp(1, 0, t);
                t -= 0.05f;
                spriteRenderer.color = new Vector4(1, g, b, 1);

            }
        }
    }

    void Update()
    {
        state?.OnUpdateState();
    }
}
