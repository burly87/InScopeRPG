using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character {

	[SerializeField]
	private Stat health;
	[SerializeField]
	private float maxHealth;

	[SerializeField]
	private Stat mana;
	[SerializeField]
	private float maxMana;

	// Use this for initialization
	protected override void Start () 
	{
		health.Initialize (maxHealth, maxHealth);
		mana.Initialize (maxMana, maxMana);
		base.Start ();
	}
	
	// Update is called once per frame
	protected override void Update () 
	{
		GetInput ();
		//base is allways the class we inherit from. so after GetInput we call Charakter.Update();
		base.Update (); 
	}

	private void GetInput()
	{
		direction = Vector2.zero;//so it doesnt get faster and faster

		//FOR DEBUGGIN ONLY
		if(Input.GetKeyDown(KeyCode.DownArrow))
		{
			health.MyCurrentValue -= 10.0f;
			mana.MyCurrentValue -= 10.0f;
		}
		if(Input.GetKeyDown(KeyCode.UpArrow))
		{
			health.MyCurrentValue += 10.0f;
			mana.MyCurrentValue += 10.0f;
		}

		//Movement
		if(Input.GetKey(KeyCode.W))
		{
			direction += Vector2.up;				
		}
		if(Input.GetKey(KeyCode.A))
		{
			direction += Vector2.left;
		}
		if(Input.GetKey(KeyCode.S))
		{
			direction += Vector2.down;
		}
		if(Input.GetKey(KeyCode.D))
		{
			direction += Vector2.right;
		}

		//Attacking
		if(Input.GetKeyDown(KeyCode.Space))
		{
			attackRoutine = StartCoroutine(Attack ());
		}

	}

	private IEnumerator Attack()
	{
		if(!isAttacking && !IsMoving)
		{
			isAttacking = true;
			animator.SetBool ("attack", isAttacking);

			yield return new WaitForSeconds (3); //hardcoded casttime for debugging
			StopAttack();
		}
	}
}
