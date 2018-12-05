using UnityEngine;
using System.Collections;

public class DragShapesScript : MonoBehaviour {

	Vector2 cursorPosition;
	Vector2 defaultPos;
	public bool rightAns=false;
	//public bool showAns=false;
	Renderer rend;
	GameObject feet;
	FeetMovementScript fs;
	GameObject[] shapes;

	GameObject shapesSpawn;
	ShapesSpawnScript sss;
	//GameObject UI;
	//ForwardNumUIScript UIscript;
	// Use this for initialization

	GameObject wrongSound;

	void Start () {
		feet = GameObject.Find ("feet");
		fs = feet.GetComponent<FeetMovementScript> ();
		defaultPos = this.gameObject.transform.position;

		shapesSpawn = GameObject.Find ("shapesSpawnPoint");
		sss = shapesSpawn.GetComponent<ShapesSpawnScript> ();

		wrongSound = GameObject.Find ("wrongSound");
	}

	// Update is called once per frame
	void Update () {
		
	
	}


	//when shapes collided with an object with same name
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.name == this.gameObject.name) 
		{
			//rend = other.gameObject.GetComponent<Renderer> ();

			rightAns = true;

		}
	}


	//when shapes leaving the collider 
	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.name == this.gameObject.name) 
		{
			rightAns = false;
		}
	}

	//allow shape objects to be drag and follow the cursor position 
	void OnMouseDrag()
	{
		cursorPosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		this.gameObject.transform.position = cursorPosition;
	}


	//when releasing mouse button, and the shape collided with the correct object
	//destroy both objects and spawn a new question
	void OnMouseUp()
	{
		if (rightAns) 
		{
			shapes = GameObject.FindGameObjectsWithTag ("feetSpawns");
			foreach (GameObject s in shapes) 
			{
				Destroy (s.gameObject);
			}
			sss.spawnTrigger = true;
			Destroy (this.gameObject);
		} 
		else 
		{
			AudioSource audio = wrongSound.GetComponent<AudioSource> ();
			audio.Play ();
			this.gameObject.transform.position = defaultPos;
		}
	}

	//check if there are any more shapes left
	//if destroy unnecessary background and move the giant leg
	void OnDestroy()
	{
		if (!GameObject.FindWithTag ("DragNum")) 
		{
			fs.feetTrigger = true;
			Destroy(GameObject.Find("Question"));
		}
	}
		
}
