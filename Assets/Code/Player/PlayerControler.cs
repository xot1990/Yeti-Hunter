using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : AbstractUnit
{
    public GameObject rangeStrike;
    public bool onLend;
    public float jumpPower;
    public GameObject menu;
    public GameObject victory;
    public AudioClip jump;
    public AudioClip[] steps = new AudioClip[6];

    private Transform strikePoint;
   

   

    void Start()
    {
        strikePoint = FindObjectOfType<ProjectilePoint>().transform;
        ChangeState<PlayerStateIdle>();
        animator.Play("Idle");
    }

    void Update()
    {
       state.OnUpdateState();

        if (hp <= 0)
        {
            ChangeState<PlayerStateDeath>();
        }
    }

    private void FixedUpdate()
    {
        
    }

    private void OnDestroy()
    {
        menu.SetActive(true);
    }

    public void StrikeUp()
    {
        GameObject strike = Instantiate(rangeStrike, strikePoint.transform.position, strikePoint.transform.rotation);
        strike.GetComponentInChildren<Projectile>().id = 0;
        strike.GetComponentInChildren<Rigidbody2D>().velocity = strike.transform.right * 5;
    }

}
