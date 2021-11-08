using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateRun : StateMachine
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
        _controler.animator.Play("Run");
    }

    public override void OnUpdateState()
    {
        if (!_game.isPause)
        {
            if (Input.GetKey(KeyCode.A))
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
                if (Mathf.Abs(_controler.body.velocity.x) < _controler.maxSpeed)
                {
                    Vector3 f = transform.right * Time.deltaTime * _controler.speed;
                    _controler.body.AddForce(f, ForceMode2D.Impulse);
                }
            }

            if (Input.GetKeyUp(KeyCode.A))
            {
                _controler.ChangeState<PlayerStateIdle>();
                _controler.audioSource.Stop();
            }

            if (Input.GetKey(KeyCode.D))
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                if (Mathf.Abs(_controler.body.velocity.x) < _controler.maxSpeed)
                {
                    Vector3 f = transform.right * Time.deltaTime * _controler.speed;
                    _controler.body.AddForce(f, ForceMode2D.Impulse);
                }                
            }

            if (Input.GetKeyUp(KeyCode.D))
            {
                _controler.ChangeState<PlayerStateIdle>();
                _controler.audioSource.Stop();
            }                        

            if (Input.GetKeyDown(KeyCode.Space))
            {

                _controler.ChangeState<PlayerStateJump>();
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
