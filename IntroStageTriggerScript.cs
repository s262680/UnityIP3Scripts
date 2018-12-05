using UnityEngine;
using System.Collections;

public class IntroStageTriggerScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/*
	void OnTriggerEnter2D(Collider2D other)
	{

		switch (Random.Range (1, 3)) {
		case 1:
			Application.LoadLevel ("ForwardNumberMiniGame");
			break;
		case 2:
			Application.LoadLevel ("BackwardNumberMiniGame");
			break;
		}


	*/

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.name == "egg") 
		{
			Application.LoadLevel ("DrawLineMiniGame");
		}
	}

}
