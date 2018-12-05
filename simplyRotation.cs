using UnityEngine;
using System.Collections;

public class simplyRotation : MonoBehaviour {
	float counter=1.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (counter>=0.0f&&counter<2.0f) 
		{
			this.transform.Rotate (new Vector3 (0, 0, 20.0f) * Time.deltaTime);
			counter += Time.deltaTime;
		}
		if (counter >= 2.0f&&counter<4.0f) 
		{
			this.transform.Rotate (new Vector3 (0, 0, -20.0f) * Time.deltaTime);
			counter += Time.deltaTime;
		}
		if (counter >= 4.0f) 
		{
			counter = 0;
		}
	}
}
