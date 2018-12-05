using UnityEngine;
using System.Collections;



public class EggSpawnScript : MonoBehaviour {

	public GameObject[] eggFabs;

	GameObject egg;

	GameObject data;
	DataScript ds;
	// Use this for initialization
	void Start () {
		data = GameObject.Find ("Data");
		ds = data.GetComponent<DataScript> ();

		spawn ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//spawn a egg based on the eggSelection value in data script
	void spawn()
	{
		egg = (GameObject)Instantiate (eggFabs[ds.eggSelection], transform.position, transform.rotation);
		egg.name = "egg";
	}
}
