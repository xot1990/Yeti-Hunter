using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateLavaDeath : StateMachine
{
    private PlayerControler _controler;
    private Game _game;
    private float deathTimer = 2f;

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
        _controler.animator.Play("LavaDeath");
    }

    public override void OnUpdateState()
    {
        if (!_game.isPause)
        {
            deathTimer -= Time.deltaTime;

            if (deathTimer < 0)
                _controler.menu.SetActive(true);
        }
    }

    public override void OnExitState()
    {

    }

    


}
