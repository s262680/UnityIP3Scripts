using UnityEngine;
using System.Collections;

public class EggSelectionScript : MonoBehaviour {

	public GameObject[] eggs;
	bool rightTrigger=false;
	bool leftTrigger=false;
	int currentEgg=0;
	GameObject tube;
	bool eggTrigger1=false;
	bool eggTrigger2=false;
	bool eggTrigger3=false;
	bool eggTrigger4=false;
	public GameObject[] suckEgg;

	GameObject data;
	DataScript ds;
	// Use this for initialization
	void Start () {

		data = GameObject.Find ("Data");
		ds = data.GetComponent<DataScript> ();

		tube = GameObject.Find ("tube");
	}
	
	// Update is called once per frame
	void Update () 
	{
		//if raycast hit a egg object, modify the egg selection data value
		//and set egg trigger to true depending on the name of selected egg
		if (Input.GetButtonDown ("Fire1")) 
		{
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit = new RaycastHit ();

			if (Physics.Raycast (ray, out hit)) 
			{
				if (hit.collider.gameObject.tag == "eggs") 
				{
					AudioSource audio = GetComponent<AudioSource>();
					audio.Play();
					if (hit.collider.gameObject.name == "egg1") 
					{
						ds.eggSelection = 0;
						eggTrigger1 = true;
					}
					else if (hit.collider.gameObject.name == "egg2") 
					{
						ds.eggSelection = 1;
						eggTrigger2 = true;
					}
					else if (hit.collider.gameObject.name == "egg3") 
					{
						ds.eggSelection = 2;
						eggTrigger3 = true;
					}
					else if (hit.collider.gameObject.name == "egg4") 
					{
						ds.eggSelection = 3;
						eggTrigger4 = true;
					}
						
				}
			}
		
		}


		//suck egg animation when egg trigger equal to true
		if (eggTrigger1) 
		{
			if (tube.transform.position.y >= 5.0f) 
			{
				tube.transform.Translate (new Vector2 (0, -2f) * Time.deltaTime);
			} 
			else 
			{
				suckEgg[0].transform.Translate (new Vector2 (0, 10f) * Time.deltaTime);
			}
		}
		if (eggTrigger2) 
		{
			if (tube.transform.position.y >= 5.0f) 
			{
				tube.transform.Translate (new Vector2 (0, -2f) * Time.deltaTime);
			} 
			else 
			{
				suckEgg[1].transform.Translate (new Vector2 (0, 10f) * Time.deltaTime);
			}
		}
		if (eggTrigger3) 
		{
			if (tube.transform.position.y >= 5.0f) 
			{
				tube.transform.Translate (new Vector2 (0, -2f) * Time.deltaTime);
			} 
			else 
			{
				suckEgg[2].transform.Translate (new Vector2 (0, 10f) * Time.deltaTime);
			}
		}
		if (eggTrigger4) 
		{
			if (tube.transform.position.y >= 5.0f) 
			{
				tube.transform.Translate (new Vector2 (0, -2f) * Time.deltaTime);
			} 
			else 
			{
				suckEgg[3].transform.Translate (new Vector2 (0, 10f) * Time.deltaTime);
			}
		}


		//move all eggs to a direction when the trigger equal true
		if (rightTrigger) 
		{
			if (eggs [currentEgg].transform.position.x > -10) 
			{
				foreach (GameObject temp in eggs) 
				{
					temp.transform.Translate (-0.5f, 0, 0);
				}
			}
			if (eggs [currentEgg].transform.position.x <= -10) 
			{
				currentEgg += 1;
				rightTrigger = false;
			}
		}

		if (leftTrigger) 
		{
			if (eggs [currentEgg].transform.position.x < 10) 
			{
				foreach (GameObject temp in eggs) 
				{
					temp.transform.Translate (0.5f, 0, 0);
				}
			}
			if (eggs [currentEgg].transform.position.x >= 10) 
			{
				currentEgg -= 1;
				leftTrigger = false;
			}
		}


		//hide arrow button when the egg selection is going to out of range
		if (currentEgg == 0)
		{
			transform.Find ("left").gameObject.SetActive (false);
		} 
		else
		{
			transform.Find ("left").gameObject.SetActive (true);
		}

		if (currentEgg == 3)
		{
			transform.Find ("right").gameObject.SetActive (false);
		} 
		else
		{
			transform.Find ("right").gameObject.SetActive (true);
		}
	}

	//set trigger equal true when arrow button click
	public void OnRightClick()
	{
		rightTrigger = true;
	}

	public void OnLeftClick()
	{
		leftTrigger = true;
	}




}
