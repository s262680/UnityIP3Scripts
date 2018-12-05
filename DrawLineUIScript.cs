using UnityEngine;
using System.Collections;

public class DrawLineUIScript : MonoBehaviour {

	Camera mainCam;
	Camera cam;
	bool zoomInTrigger=false;
	public bool zoomOutTrigger=false;
	GameObject egg;
	EggMovement eggMovement;

	GameObject drawLineObj;
	DrawLineScript dls;
	bool audioTrigger=true;
	GameObject data;
	DataScript ds;
	//GameObject pen;
	//public GameObject penFab;

	// Use this for initialization
	void Start () {
		data = GameObject.Find ("Data");
		ds = data.GetComponent<DataScript> ();
		mainCam = Camera.main;
		cam = Camera.main.GetComponent<Camera>();
		cam.orthographicSize = 15.0f;
		egg = GameObject.Find ("egg");
		eggMovement=egg.GetComponent<EggMovement>();
		drawLineObj = GameObject.Find ("Pen");
		dls = drawLineObj.GetComponent<DrawLineScript> ();
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

		//play a sound and zoom out when node counter reach 9
		if (dls.nodeCounter>=9) 
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
		//pen = (GameObject)Instantiate (penFab, transform.position, transform.rotation);
		//pen.name = "pen";
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

