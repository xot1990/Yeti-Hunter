using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateIdle : StateMachine
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
    }

    private bool onLend()
    {
        return Physics2D.OverlapCircle(_controler.foot.position, 0.1f, _game.layerMaskGround);
    }

    
}
