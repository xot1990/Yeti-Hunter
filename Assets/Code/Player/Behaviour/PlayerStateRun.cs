using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateRun : StateMachine
{
    private PlayerControler _controler;
    private Game _game;
    private float stepSoundDelay = 0.1f;

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

                stepSoundDelay -= Time.deltaTime;

                if (stepSoundDelay < 0)
                {
                    _controler.audioSource.clip = _controler.steps[Random.Range(0, _controler.steps.Length)];
                    _controler.PlaySound();
                    stepSoundDelay = 0.1f;
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

                stepSoundDelay -= Time.deltaTime;

                if (stepSoundDelay < 0)
                {
                    _controler.audioSource.clip = _controler.steps[Random.Range(0, _controler.steps.Length)];
                    _controler.PlaySound();
                    stepSoundDelay = 0.1f;
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
            }

            if (_controler.body.velocity.y < -0.5f)
            {
                _controler.ChangeState<PlayerStateJump>();
            }

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (onLend()) _controler.ChangeState<PlayerStateAttack>();
            }

        }
    }

    public override void OnExitState()
    {
        _controler.animator.Play("Idle");
    }

    private bool onLend()
    {
        return Physics2D.OverlapCircle(_controler.foot.position, 0.2f, _game.layerMaskGround);
    }
}
