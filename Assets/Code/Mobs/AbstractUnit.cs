using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;

public class AbstractUnit : MonoBehaviour, TakenDamage
{

    public float hp;
    public float maxHp;
    public float speed;
    public float maxSpeed;
    public bool isRuning;
    public AudioSource audioSource;
    public StateMachine state;
    public Animator animator;
    public Rigidbody2D body;
    public Transform eya;
    public Transform foot;
    public Transform healsBar;
    public AudioClip deth;
    public AudioClip hart;
    public AudioClip step;
    public AudioClip attack;
    public SpriteRenderer spriteRenderer;
    public int direction = 1;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        healsBar = GetComponentInChildren<HealsBar>().transform;
        eya = GetComponentInChildren<Eya>().transform;
        foot = GetComponentInChildren<Foot>().transform;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Rotation()
    {
        if (direction == 0) direction = 1;
        else if (direction == 1) direction = 0;
        body.velocity = Vector2.zero;
        transform.rotation = Quaternion.Euler(0, 180 * direction, 0);
    }

    public void ChangeState<T>() where T : StateMachine
    {
        if (state != null) state.OnExitState();
        state = GetComponent<T>();
        state.OnEnterState();
    }

    public void PlaySound()
    {
        audioSource.Play();
    }
    
    public void Hit(int value)
    {
        hp -= value;
        audioSource.clip = hart;
        healsBar.transform.localPosition = new Vector3(-1 + (hp / maxHp), 0, 0);
    }

    public void Death()
    {
        Destroy(gameObject);
    }
}
