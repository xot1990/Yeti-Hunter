using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractBoss : AbstractUnit
{
    public int PhaseTimer;
    public StateMachine currentState;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
