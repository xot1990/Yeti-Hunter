using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    Rigidbody2D body;
    Vector2[] forses;


    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        forses = new Vector2[2];
        forses[0] = new Vector2(-1, 1); forses[1] = new Vector2(1, 1);
    }
    void Start()
    {

        body.angularVelocity = Random.Range(50,220);
        StartCoroutine(LifeTime());
    }

    IEnumerator LifeTime()
    {
        yield return new WaitForSeconds(6);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Lend"))
        {
            body.velocity = Vector2.zero;
            body.AddForce(forses[Random.Range(0, 2)] * 3,ForceMode2D.Impulse);
            body.angularVelocity += 100;
            GetComponent<Collider2D>().enabled = false;
            Debug.Log("1");
        }
    }
}
