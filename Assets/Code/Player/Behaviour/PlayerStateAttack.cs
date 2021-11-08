using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateAttack : StateMachine
{
    
    private PlayerControler _controler;
    private Game _game;

    private void Awake()
    {
        OnGetClass<PlayerControler>();
        _game = Game.Get();
    }

    private void Start()
    {
    }

    public void OnGetClass<T>() where T : PlayerControler
    {
        _controler = GetComponent<T>();
    }

    public override void OnEnterState()
    {
        _controler.animator.Play("Idle");
    }

    public override void OnUpdateState()
    {
        if (!_game.isPause)
        {
            if (Input.GetKey(KeyCode.A))
            {
                _controler.ChangeState<PlayerStateRun>();
            }

            if (Input.GetKey(KeyCode.D))
            {
                _controler.ChangeState<PlayerStateRun>();
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _controler.animator.SetBool("Lending", false);
                _controler.animator.SetBool("StartingJump", true);
                _controler.body.AddForce(Vector2.up * 2 * _controler.maxSpeed, ForceMode2D.Impulse);
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {

            }

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                _controler.audioSource.clip = _controler.attack;
                if (onLend()) _controler.animator.SetBool("Strike", true);
            }

            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                if (onLend()) _controler.animator.SetBool("Strike", false);
            }
        }
    }

    public override void OnExitState()
    {
    }

    private bool onLend()
    {
        return true;
    }
}

