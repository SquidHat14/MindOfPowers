using System;
using UnityEngine;

public class AttackState : BaseState
{
    /// <summary>
    /// Constructor.
    /// </summary>
    public AttackState(Enemy e) : base(e) {}
    
    /// <summary>
    /// Acts as the update function.
    /// </summary>
    public override Type Tick()
    {
        if (me.isDead)
        {
            return null;
        }

        if (me.isAttacking == false)
        {
            if (me.InRange())
            {
                me.rb.velocity = Vector3.zero;
                me.isAttacking = true;
            }
            else
            {
                return typeof(ChaseState);
            }
        }

        return null;
    }

}