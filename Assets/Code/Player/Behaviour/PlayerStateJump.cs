using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateJump : StateMachine
{
    
    private PlayerControler _controler;
    private Game _game;
    private float _jumpDelay = 0.1f;

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
        if (_controler.body.velocity.y < -0.5f)
        {
            _controler.animator.Play("DownJump");
        }
        else
        {
            _controler.body.AddForce(Vector2.up * _controler.jumpPower, ForceMode2D.Impulse);
            _controler.animator.Play("Jump");
            _controler.audioSource.clip = _controler.jump;
            _controler.PlaySound();
        }
    }

    public override void OnUpdateState()
    {
        if (!_game.isPause)
        {
            _jumpDelay -= Time.deltaTime;

            if (Input.GetKey(KeyCode.A))
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
                if (Mathf.Abs(_controler.body.velocity.x) < _controler.maxSpeed)
                {
                    Vector3 f = transform.right * Time.deltaTime * _controler.speed;
                    _controler.body.AddForce(f, ForceMode2D.Impulse);
                }
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

            if (_controler.body.velocity.y < -1)
            {
                _controler.animator.Play("DownJump");
            }

            if (onLend() && _jumpDelay < 0)
                _controler.ChangeState<PlayerStateIdle>();

            if (onLava())
            {
                _controler.ChangeState<PlayerStateLavaDeath>();
            }
        }
    }

    public override void OnExitState()
    {
        _jumpDelay = 0.1f;
        _controler.animator.Play("LendingJump");
    }

    private bool onLend()
    {
        return Physics2D.OverlapCircle(_controler.foot.position,0.1f,_game.layerMaskGround);
    }

    private bool onLava()
    {
        return Physics2D.OverlapCircle(_controler.foot.position, 0.1f, _game.layerMaskLava);
    }
}

