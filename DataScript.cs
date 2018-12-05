using UnityEngine;
using System.Collections;

public class DataScript : MonoBehaviour {

	public int eggSelection=0;
	public int headSelection=0;
	public int handSelection=0;
	public int bodySelection=0;
	public int legsSelection=0;
	public int stage=0;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (transform.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
