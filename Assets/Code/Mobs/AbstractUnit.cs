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
    public AudioSource audioSourse;
    public StateMachine state;
    public Animator animator;
    public Rigidbody2D Rbody;
    public Transform eya;
    public Transform foot;
    public Transform HealsBar;
    public AudioClip deth;
    public AudioClip hart;
    public AudioClip step;
    public AudioClip attack;
    public SpriteRenderer spriteRenderer;
    public int direction = 1;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        Rbody = GetComponent<Rigidbody2D>();
        audioSourse = GetComponent<AudioSource>();
        HealsBar = GetComponentInChildren<HealsBar>().transform;
        eya = GetComponentInChildren<Eya>().transform;
        foot = GetComponentInChildren<Foot>().transform;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Rotation()
    {
        if (direction == 0) direction = 1;
        else if (direction == 1) direction = 0;
        Rbody.velocity = Vector2.zero;
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
        audioSourse.Play();
    }
    
    public void Hit(int value)
    {
        hp -= value;
        audioSourse.clip = hart;
        HealsBar.transform.localPosition = new Vector3(-1 + (hp / maxHp), 0, 0);
    }

    public void Death()
    {
        Destroy(gameObject);
    }
}
