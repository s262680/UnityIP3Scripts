using UnityEngine;
using System.Collections;

public class EggMovement : MonoBehaviour {

	float counter=0.5f;
	// Use this for initialization
	public bool movementTrigger;

	GameObject data;
	DataScript ds;

	int stageSelection=0;
	void Start () {

		data = GameObject.Find ("Data");
		ds = data.GetComponent<DataScript> ();
		movementTrigger = false;
	}
	
	// Update is called once per frame
	void Update () {


		//egg shaking animtaion
		if (counter>=0.0f&&counter<1.0f) 
		{
			this.transform.Rotate (new Vector3 (0, 0, 50.0f) * Time.deltaTime);
			counter += Time.deltaTime;
		}
		if (counter >= 1.0f&&counter<2.0f) 
		{
			this.transform.Rotate (new Vector3 (0, 0, -50.0f) * Time.deltaTime);
			counter += Time.deltaTime;
		}
		if (counter >= 2.0f) 
		{
			counter = 0;
		}



		//egg movement to the right when triggerd 
		if (movementTrigger) 
		{
			transform.Translate(new Vector3(0.1f,0,0),Space.World);
		}


	}

	void OnTriggerEnter2D(Collider2D other)
	{

		//when egg collided with the stage trigger in intro, 
		//randomly pick 1 of the pre-built connect dot level
		if (other.gameObject.name == "introTrigger") 
		{
			stageSelection = Random.Range (1, 4);
			if (stageSelection == 1)
			{
				Application.LoadLevel ("DrawLineMiniGame");
			}
			else if (stageSelection == 2)
			{
				Application.LoadLevel ("DrawLineMiniGame1");
			}
			else if (stageSelection == 3)
			{
				Application.LoadLevel ("DrawLineMiniGame2");
			}
		}

		//when egg collided with the stage trigger in game scene
		//pick a monster customize stage based on the eggSelection value
		//in the data script
		else if (other.gameObject.name == "stageTrigger") 
		{
			if (ds.eggSelection == 0)
			{
				Application.LoadLevel ("Unicorn");
			}
			else if (ds.eggSelection == 1)
			{
				Application.LoadLevel ("Dragon");
			}
			else if (ds.eggSelection == 2)
			{
				Application.LoadLevel ("Bunny");
			}
			else if (ds.eggSelection == 3)
			{
				Application.LoadLevel ("Penguin");
			}
		}

		/*
		else if (other.gameObject.name == "stageTrigger2") 
		{
			Application.LoadLevel ("NumberAddingMiniGame");

		}
		else if (other.gameObject.name == "stageTrigger3") 
		{
			
			Application.LoadLevel ("ForwardNumberMiniGame");

		}
		else if (other.gameObject.name == "stageTrigger4") 
		{
			Application.LoadLevel ("Unicorn");
		}
		*/
	}
}
