using UnityEngine;
using System.Collections;

public class OnHomeScript : MonoBehaviour {
	GameObject data;
	DataScript ds;
	// Use this for initialization
	void Start () {
		data = GameObject.Find ("Data");
		ds = data.GetComponent<DataScript> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnClick()
	{
		ds.eggSelection=0;
		ds.headSelection=0;
		ds.handSelection=0;
		ds.bodySelection=0;
		ds.legsSelection=0;
		ds.stage = 0;
		Application.LoadLevel ("MainMenu");
	}
}
