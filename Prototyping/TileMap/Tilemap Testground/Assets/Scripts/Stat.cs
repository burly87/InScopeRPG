using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stat : MonoBehaviour {

	private Image content;
	private float currentFill; //fillAmount
	private float currentValue;
	[SerializeField]
	private float lerpSpeed;

	[SerializeField]
	private Text statValue;

	public float MyMaxValue { get; set;}

	//property
	public float MyCurrentValue
	{
		get
		{ 
			return currentValue;
		}
		set
		{ 
			//make sure value will never go over MyMaxValue
			//value is what we set in Player/Character by using health.MyCurrentValue
			if (value > MyMaxValue) 
			{ 
				currentValue = MyMaxValue;
			} else if (value < 0) 
			{
				currentValue = 0;
			} else 
			{
				currentValue = value;
			}

			//currentFill calculation
			currentFill = currentValue / MyMaxValue; // has to be between 0 - 1.0
			statValue.text = currentValue + " / " + MyMaxValue;
		}
	}

	// Use this for initialization
	void Start () 
	{		
		content = GetComponent<Image> (); // content has now reference to image
		//content.fillAmount = 0.5f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (currentFill != content.fillAmount) 
		{
			content.fillAmount = Mathf.Lerp (content.fillAmount, currentFill, Time.deltaTime*lerpSpeed);
		}
	}

	public void Initialize(float currentValue, float maxValue)
	{
		MyMaxValue = maxValue;
		MyCurrentValue = currentValue;
	}
}
