using UnityEngine;
using System.Collections;

public class FeetMovementScript : MonoBehaviour {
	public bool feetTrigger = false;
	GameObject egg;
	EggMovement eggmovement;
	// Use this for initialization
	void Start () {
		egg = GameObject.Find ("egg");
		eggmovement = egg.GetComponent<EggMovement> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (feetTrigger) 
		{
			eggmovement.movementTrigger = true;
			this.transform.Translate (new Vector2 (0.0f, 3.0f) * Time.deltaTime);
			this.transform.Rotate (new Vector3 (0, 0, 2.5f) * Time.deltaTime);
		}
	}
}
