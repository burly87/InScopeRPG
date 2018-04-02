using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour 
{
	[SerializeField]
	private float playerSpeed;
	private Rigidbody2D myRigidBody;

	protected Animator animator;
	protected bool isAttacking = false;
	protected Coroutine attackRoutine;
	protected Vector2 direction; // so every Scritp who inherit from it can access 

	//property
	public bool IsMoving
	{
		get
		{
			return direction.x != 0 || direction.y != 0;
		}
	}

	// Use this for initialization
	protected virtual void Start () 
	{
		myRigidBody = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> (); // GetComponent means the Component with name Animator in Inspector
	}
	// Update is called once per frame
	protected virtual void Update () 
	{
		HandleAnimationLayers ();
	}

	private void FixedUpdate()
	{
		MovePlayer ();
	}

	public void MovePlayer()
	{
		//transform.Translate (direction.normalized* playerSpeed * Time.deltaTime); //Time.deltaTime is time since last Update
		myRigidBody.velocity = direction.normalized * playerSpeed;
	}

	public void HandleAnimationLayers()
	{
		// Layer Weight handle! While moving WalkLayer is 1.0f
		if (IsMoving) {
			ActivateLayer ("WalkLayer");

			animator.SetFloat ("x", direction.x);
			animator.SetFloat ("y", direction.y);
			StopAttack ();
		} else if (isAttacking) 
		{
			ActivateLayer("AttackLayer");
		} else 
		{
			ActivateLayer("IdleLayer");
		}
	}

	public void ActivateLayer(string layerName)
	{
		for (int i = 0; i < animator.layerCount; i++) 
		{
			animator.SetLayerWeight (i, 0.0f);
		}

		animator.SetLayerWeight (animator.GetLayerIndex (layerName),1.0f);
	}

	public void StopAttack()
	{
		if (attackRoutine != null) 
		{
			StopCoroutine (attackRoutine);
			isAttacking = false;
			animator.SetBool ("attack", isAttacking);
		}
	}
}
