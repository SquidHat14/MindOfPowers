using System;
using UnityEngine;

public class IdleState : BaseState
{
    /// <summary>
    /// Constructor.
    /// </summary>
    public IdleState(Enemy e) : base(e) {}

    /// <summary>
    /// Acts as the update function.
    /// </summary>
    public override Type Tick()
    {
        if (me.isDead)
        {
            return null;
        }

        if (IsAlerted())
        {
            return typeof(AlertState);
        }

        return null;
    }

    /// <summary>
    /// Check if player is in range to aggro.
    /// </summary>
    private bool IsAlerted()
    {
        // TODO:
        // Update to check in desired directions.
        // Set a mask to the appropriate layer mask.
        RaycastHit2D hit = Physics2D.Raycast(
            me.transform.position,
            Vector2.left,
            me.aggroRange);
        
        return hit.collider != null;
    }
}