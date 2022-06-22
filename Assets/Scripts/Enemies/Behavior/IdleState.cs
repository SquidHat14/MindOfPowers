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
        LayerMask mask = LayerMask.GetMask("Player");
        Vector3 direction = Player.instance.transform.position - me.transform.position;
        RaycastHit2D hit = Physics2D.Raycast(
            me.transform.position,
            direction,
            me.aggroRange,
            mask);
        
        return hit.collider != null;
    }
}