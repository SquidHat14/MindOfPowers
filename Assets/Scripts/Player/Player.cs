using System;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public static Player instance;

	[Header("Stats")]
	public float maxHp;
	public float moveSpeed;

	// State
	public bool isDead;
	public bool isMoving;
	public bool isCrouching;
	public bool isJumping;
	public bool isAttacking;

	// Components
	private PlayerInput input;
	private Rigidbody2D rb;

	/// <summary>
	/// Initialization.
	/// </summary>
	private void Awake()
	{
		Debug.Assert(instance == null);
		instance = this;
		rb = GetComponent<Rigidbody2D>();
	}

	/// <summary>
	/// Initialization Pt2.
	/// </summary>
	private void Start()
	{
		input = new PlayerInput();
	}

	/// <summary>
	/// Called every frame.
	/// </summary>
	private void Update()
	{
		if (isDead)
		{
			return;
		}

		input.ReadInput();
		InputHandler();
	}

	/// <summary>
	/// Interpret input into state flags and actions.
	/// </summary>
	private void InputHandler()
	{
		// Read platform independent input flags and decide how they
		// affect the state of the player (or how input flags override each other like not moving if crouching, or not crouching if jumping, etc.).
		// Then convert those state flags into actions like movement, attacks, etc.
	}
}