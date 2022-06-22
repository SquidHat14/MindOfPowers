using System;
using UnityEngine;

public abstract class BaseState
{
    /// <summary>
    /// Enemy the state is controlling.
    /// </summary>
    protected Enemy me;

    /// <summary>
    /// Constructor.
    /// </summary>
    public BaseState(Enemy e)
    {
        me = e;
    }

    /// <summary>
    /// Acts as the update function.
    /// </summary>
    public abstract Type Tick();
}