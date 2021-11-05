using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWall : MonoBehaviour
{
    SoundControler source;
    FrostCrab crab;

    private void Start()
    {
        source = FindObjectOfType<SoundControler>();
        crab = FindObjectOfType<FrostCrab>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            source.GetComponent<AudioSource>().clip = source.Boss;
            source.GetComponent<AudioSource>().Play();
            crab.ChangeState<CrabRun>();

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
