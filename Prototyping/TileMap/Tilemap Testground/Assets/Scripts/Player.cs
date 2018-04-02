using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character {
	
	// Use this for initialization
	protected override void Start () 
	{
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
	}
}
