using System;
using UnityEngine;

public class ChaseState : BaseState
{
    /// <summary>
    /// Constructor.
    /// </summary>
    public ChaseState(Enemy e) : base(e) {}

    /// <summary>
    /// Acts as the update function.
    /// </summary>
    public override Type Tick()
    {
        if (me.isDead)
        {
            return null;
        }

        if (me.InRange())
        {
            return typeof(AttackState);
        }
        else
        {
            // TODO:
            // Change code so that it isn't just moving left.
            me.rb.velocity = Vector2.left * me.moveSpeed;
            return null;
        }
    }
}