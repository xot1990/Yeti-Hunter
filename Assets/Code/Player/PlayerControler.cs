using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : AbstractUnit
{
    public GameObject rangeStrike;
    public Transform strikePoint;
    public bool onLend;
    public GameObject menu;
    public GameObject victory;
    public AudioClip jump;
    public AudioClip[] steps = new AudioClip[6];
    KeyCode[] keys;


    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        state.OnUpdateState();
    }
}
