using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour 
{
	[SerializeField]
	private float playerSpeed;

	private Animator animator;

	protected Vector2 direction; // so every Scritp who inherit from it can access 

	// Use this for initialization
	protected virtual void Start () 
	{
		animator = GetComponent<Animator> (); // GetComponent means the Component with name Animator in Inspector
	}

	// Update is called once per frame
	protected virtual void Update () 
	{
		MovePlayer ();
	}

	public void MovePlayer()
	{
		transform.Translate (direction.normalized* playerSpeed * Time.deltaTime); //Time.deltaTime is time since last Update

		// Layer Weight handle! While moving WalkLayer is 1.0f
		if (direction.x != 0 || direction.y != 0) 
		{
			AnimateMovement (direction);
		} else 
		{
			animator.SetLayerWeight (1, 0.0f);
		}

	}

	public void AnimateMovement(Vector2 direction)
	{
		animator.SetLayerWeight (1, 1.0f);

		animator.SetFloat ("x", direction.x);
		animator.SetFloat ("y", direction.y);
	}
}
