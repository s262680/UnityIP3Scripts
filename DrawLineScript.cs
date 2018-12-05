using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DrawLineScript : MonoBehaviour {

	//GameObject line;
	LineRenderer lr;
	public int nodeCounter=0;
	//int stage=1;
	GameObject[] node;

	bool mouseTrigger=false;
	bool startNodeTrigger=true;
	bool tempTrigger=false;

	// Use this for initialization


	void Start () {

		//find all the number dots
		node = new GameObject[9];
		node [0] = GameObject.Find ("1");
		node [1] = GameObject.Find ("2");
		node [2] = GameObject.Find ("3");
		node [3] = GameObject.Find ("4");
		node [4] = GameObject.Find ("5");
		node [5] = GameObject.Find ("6");
		node [6] = GameObject.Find ("7");
		node [7] = GameObject.Find ("8");
		node [8] = GameObject.Find ("9");

		//set up line renderer
		node[0].AddComponent<LineRenderer>();
		lr = node[0].GetComponent<LineRenderer>();
		lr.SetWidth(0.08f, 0.08f);
		lr.SetPosition (0, node[0].transform.position);
		/*
		if (startNodeTrigger) {
			lr.SetPosition (1,node[0].transform.position)+ new Vector3 (0.1f, 0, 0);
		}
		*/
	
	}
	
	// Update is called once per frame
	void Update () {
		lr.SetVertexCount (nodeCounter+1);
		/*
		gameObject.transform.position = Camera.main.ScreenToWorldPoint (Input.mousePosition) + new Vector3 (0, 0, 10);
		if (Input.GetButtonDown ("Fire1")) 
		{
			gameObject.transform.position = Camera.main.ScreenToWorldPoint (Input.mousePosition) + new Vector3 (0, 0, 10);
		}
		*/

	
	
	}

	//allow this object and line follow the cursor
	void OnMouseDrag()
	{
			gameObject.transform.position = Camera.main.ScreenToWorldPoint (Input.mousePosition) + new Vector3 (0, 0, 10);
			mouseTrigger = true;
			lr.SetPosition (nodeCounter, Camera.main.ScreenToWorldPoint (Input.mousePosition) + new Vector3 (0, 0, 10));

		/*
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit = new RaycastHit ();

		if (Physics.Raycast (ray, out hit)) {

			if (hit.collider.gameObject.name == "2") {
				Debug.Log ("abc");
			}
		}
		*/
	}

	void OnMouseUp()
	{
		mouseTrigger = false;

	}

	//when collided with the next number dot, connect line to that dot and increase the counter for the next connection
	void OnTriggerEnter2D(Collider2D other)
	{
		if (mouseTrigger) 
		{
			if (other.gameObject==node[nodeCounter])
			{
				lr.SetPosition (nodeCounter,  node[nodeCounter].transform.position);
				nodeCounter++;
			}
		}
	}



}
