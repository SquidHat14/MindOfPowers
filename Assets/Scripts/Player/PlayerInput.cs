using System;
using UnityEngine;

public class PlayerInput
{
	/// <summary>
	/// Move input detected
	/// </summary>
	public bool move {get; private set;}

	/// <summary>
	/// Jump input detected
	/// </summary>
	public bool jump {get; private set;}

	/// <summary>
	/// Crouch input detected
	/// </summary>
	public bool crouch {get; private set;}

	/// <summary>
	/// Attack input detected
	/// </summary>
	public bool attack {get; private set;}

	/// <summary>
	/// Default constructor.
	/// </summary>
	public PlayerInput() {}

	/// <summary>
	/// Reads input from the respective platform.
	/// </summary>
	public void ReadInput()
	{
		#if !UNITY_EDITOR && (UNITY_IOS || UNITY_ANDROID)
			// Mobile Touch/Button reader
		#else
			KeyboardReader();
		#endif
	}

	/// <summary>
	/// Keyboard input controls.
	/// These are just boilerplate, change as desired.
	/// Move = WASD
	/// Jump = Space
	/// Crouch = L-Ctrl
	/// Attack = Left Mouse
	/// </summary>
	private void KeyboardReader()
	{

	}
}