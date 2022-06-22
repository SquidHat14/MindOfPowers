using System;
using UnityEngine;

public class AlertState : BaseState
{
    /// <summary>
    /// Constructor.
    /// </summary>
    public AlertState(Enemy e) : base(e)
    {
        e.stateMachine.OnStateChanged += Alert;
    }

    /// <summary>
    /// Acts as the update function.
    /// </summary>
    public override Type Tick()
    {
        if (me.isDead)
        {
            return null;
        }

        if (me.isAlerted == false)
        {
            return typeof(ChaseState);
        }

        return null;
    }

    /// <summary>
    /// Listener for state change.
    /// </summary>
    private void Alert(BaseState state)
    {
        if (state is AlertState)
        {
            me.isAlerted = true;
        }
    }
}