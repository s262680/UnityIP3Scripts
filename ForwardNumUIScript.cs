using UnityEngine;
using System.Collections;
[RequireComponent(typeof(AudioSource))]
public class ForwardNumUIScript : MonoBehaviour {

	Camera mainCam;
	Camera cam;
	bool zoomInTrigger=false;
	public bool zoomOutTrigger=false;
	GameObject egg;
	EggMovement eggMovement;
	bool audioTrigger=true;
	GameObject data;
	DataScript ds;
	// Use this for initialization
	void Start () {
		data = GameObject.Find ("Data");
		ds = data.GetComponent<DataScript> ();
		mainCam = Camera.main;
		cam = Camera.main.GetComponent<Camera>();
		cam.orthographicSize = 15.0f;
		egg = GameObject.Find ("egg");
		eggMovement=egg.GetComponent<EggMovement>();
	}
	
	// Update is called once per frame
	void Update () {


		//allow camera to zoom in
		if (zoomInTrigger) 
		{
			if(cam.orthographicSize > 5.5f) 
			{
				cam.orthographicSize -= Time.deltaTime*5.0f;
				mainCam.transform.Translate (0, 0.04f, 0);
			}
			if (cam.orthographicSize <= 5.5f) 
			{
				zoomInTrigger = false;
			}
		}


		//play a sound and zoom out when not more drag objects found
		if (!GameObject.FindWithTag ("DragNum")) 
		{
			if (audioTrigger) 
			{
				AudioSource audio = GetComponent<AudioSource> ();
				audio.Play();
				audioTrigger = false;
			}

			if(cam.orthographicSize < 15.0f) 
			{
				cam.orthographicSize += Time.deltaTime*5.0f;
				mainCam.transform.Translate (0, -0.04f, 0);
			}

			eggMovement.movementTrigger = true;
		}

	}

	public void OnNextClick()
	{
		Application.LoadLevel ("BackwardNumberMiniGame");
	}

	public void OnZoomClick()
	{
		zoomInTrigger = true;
		this.transform.Find ("screenZoomButton").gameObject.SetActive (false);
	}

	public void OnHomeClick()
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
