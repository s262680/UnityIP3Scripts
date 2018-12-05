using UnityEngine;
using System.Collections;

public class ForwardNumMiniGameScript : MonoBehaviour {


	Vector2 cursorPosition;
	Vector2 defaultPos;
	public bool rightAns=false;
	public bool showAns=false;
	Renderer rend;


	void Start () {
	
		defaultPos = this.gameObject.transform.position;
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//if collided with object that has same name
	//set rightAns to true
	void OnTriggerEnter2D(Collider2D other)
	{

		if (other.gameObject.name == this.gameObject.name) 
		{
			rend = other.gameObject.GetComponent<Renderer> ();
			rightAns = true;
		}
	}


	//when leaving trigger, set rightAns back to false
	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.name == this.gameObject.name) 
		{
			rightAns = false;
		}
	}
		

	//allow object follow cursor
	void OnMouseDrag()
	{

		cursorPosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		this.gameObject.transform.position = cursorPosition;

	}


	//on releasing mouse button, if rightAns set to true
	//enable the renderer of the answer, otherwise put this object back
	//to default location
	void OnMouseUp()
	{
		if (rightAns) 
		{
			rend.enabled = true;
			Destroy (this.gameObject);
		} 
		else 
		{
			this.gameObject.transform.position = defaultPos;
		}
	}
}
