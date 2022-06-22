using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random=UnityEngine.Random;

public class Enemy : MonoBehaviour
{
	[Header("Stats")]
    public int powerLevel;
    public int maxHp;
    public int moveSpeed;
    public float aggroRange;

    [Header("Combat")]
    public bool isMelee;
    public float meleeRange;
    public float meleeCooldown;
    public float rangedRange;
    public float rangedCooldown;
    public float projectileSpeed;

    // State
    public bool isDead;
    public bool isAlerted;
    public bool isAttacking;
    private int hp;

    // Components
    public StateMachine stateMachine {get; private set;}
    public Rigidbody2D rb {get; private set;}
    public SpriteRenderer rend {get; private set;}
    public Collider2D coll {get; private set;}

    // Events
    public delegate void Damaged(int dmg);
    public Damaged OnDamaged;
    public event Action OnDeath;

    /// <summary>
    /// Initialization.
    /// </summary>
    private void Awake()
    {
        stateMachine = GetComponent<StateMachine>();
        rb = GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();
        coll = GetComponent<Collider2D>();
    }

    /// <summary>
    /// Initialization Pt2.
    /// </summary>
    private void Start()
    {
        hp = maxHp;
        isDead = false;
        OnDamaged += TakeDamage;
        InitializeStateMachine();
    }

    /// <summary>
    /// Loads state machine with desired states.
    /// </summary>
    private void InitializeStateMachine()
    {
        Dictionary<Type, BaseState> states = new Dictionary<Type, BaseState>()
        {
            {typeof(IdleState), new IdleState(this)},
            {typeof(AlertState), new AlertState(this)},
            {typeof(ChaseState), new ChaseState(this)},
            {typeof(AttackState),  new AttackState(this)}
        };
        stateMachine.SetStates(states);
    }

    /// <summary>
    /// Check if we are in range to attack.
    /// </summary>
    public bool InRange()
    {
        Vector3 dist = Player.instance.transform.position - transform.position;
        float dist2 = dist.sqrMagnitude;
        return dist2 < (aggroRange * aggroRange);
    }

    /// <summary>
    /// Listener for OnDamaged event.
    /// </summary>
    private void TakeDamage(int dmg)
    {
        hp -= dmg;
        if (hp <= 0)
        {
            isDead = true;
            this.gameObject.SetActive(false);
            OnDeath?.Invoke();
        }
    }
}