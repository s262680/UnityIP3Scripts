using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class MonsterCustomizeScript : MonoBehaviour {

	public Sprite[] MonHeadImg;
	public Sprite[] MonHandsImg;
	public Sprite[] MonBodyImg;
	public Sprite[] MonLegsImg;

	GameObject headPanel;
	GameObject handsPanel;
	GameObject bodyPanel;
	GameObject legsPanel;


	GameObject headObj;
	GameObject handsObj;
	GameObject bodyObj;
	GameObject legsObj;

	GameObject headButton;
	GameObject handsButton;
	GameObject bodyButton;
	GameObject legsButton;

	GameObject headButtonBg;
	GameObject handsButtonBg;
	GameObject bodyButtonBg;
	GameObject legsButtonBg;

	Image head;
	Image hands;
	Image body;
	Image legs;

	GameObject data;
	DataScript ds;

	GameObject finishBg;
	GameObject[] RemoveableUI;

	int stageSelection=0;

	// Use this for initialization
	void Start () {
		finishBg = GameObject.Find ("FinishedBg");
		data = GameObject.Find ("Data");
		ds = data.GetComponent<DataScript> ();

		headPanel = GameObject.Find ("HeadPanel");
		handsPanel = GameObject.Find ("HandsPanel");
		bodyPanel = GameObject.Find ("BodyPanel");
		legsPanel = GameObject.Find ("LegsPanel");


		headObj = GameObject.Find ("head");
		handsObj = GameObject.Find ("hands");
		bodyObj = GameObject.Find ("body");
		legsObj = GameObject.Find ("legs");

		headButton = GameObject.Find ("headUI");
		handsButton = GameObject.Find ("handsUI");
		bodyButton = GameObject.Find ("bodyUI");
		legsButton = GameObject.Find ("legsUI");

		headButtonBg = GameObject.Find ("buttonBG1");
		handsButtonBg = GameObject.Find ("buttonBG2");
		bodyButtonBg = GameObject.Find ("buttonBG3");
		legsButtonBg = GameObject.Find ("buttonBG4");

		head = headObj.GetComponent<Image> ();
		hands = handsObj.GetComponent<Image>();
		body = bodyObj.GetComponent<Image>();
		legs = legsObj.GetComponent<Image>();


		headPanel.gameObject.SetActive(false);
		handsPanel.gameObject.SetActive(false);
		bodyPanel.gameObject.SetActive(false);
		legsPanel.gameObject.SetActive(false);

		finishBg.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {


		//assign images to sprite based on the colour that user choose
		head.sprite = MonHeadImg [ds.headSelection];
		hands.sprite = MonHandsImg [ds.handSelection];
		body.sprite = MonBodyImg [ds.bodySelection];
		legs.sprite = MonLegsImg [ds.legsSelection];


		//hidden the body parts depend on the stage 
		if (ds.stage == 0) 
		{
			handsObj.SetActive (false);
			bodyObj.SetActive (false);
			legsObj.SetActive (false);
			handsButton.SetActive (false);
			bodyButton.SetActive (false);
			legsButton.SetActive (false);
			handsButtonBg.SetActive (false);
			bodyButtonBg.SetActive (false);
			legsButtonBg.SetActive (false);
		}
		else if (ds.stage == 1) 
		{
			
			bodyObj.SetActive (false);
			legsObj.SetActive (false);

			bodyButton.SetActive (false);
			legsButton.SetActive (false);

			bodyButtonBg.SetActive (false);
			legsButtonBg.SetActive (false);
		}
		else if (ds.stage == 2) 
		{
			
			legsObj.SetActive (false);

			legsButton.SetActive (false);

			legsButtonBg.SetActive (false);
		}
	
	}

	//when click on the body part button, a list of colour for that body part will show up
	public void OnHeadClick()
	{
		OnCancelClick ();
		headPanel.gameObject.SetActive(true);
	}

	public void OnRightHandClick()
	{
		OnCancelClick ();
		handsPanel.gameObject.SetActive(true);
	}
	public void OnBodyClick()
	{
		OnCancelClick ();
		bodyPanel.gameObject.SetActive(true);
	}
	public void OnLegsClick()
	{
		OnCancelClick ();
		legsPanel.gameObject.SetActive(true);
	}

	//hide the colour list on click
	public void OnCancelClick()
	{
		headPanel.gameObject.SetActive(false);
		handsPanel.gameObject.SetActive(false);
		bodyPanel.gameObject.SetActive(false);
		legsPanel.gameObject.SetActive(false);
	}


	//change the colour of body parts
	public void OnHeadBlueClick()
	{		
		ds.headSelection = 0;
	}
	public void OnHeadGreenClick()
	{
		ds.headSelection = 1;
	}
	public void OnHeadYellowClick()
	{
		ds.headSelection = 2;
	}
	public void OnHeadPinkClick()
	{
		ds.headSelection = 3;
	}
	public void OnHeadRedClick()
	{
		ds.headSelection = 4;
	}







	public void OnHandsBlueClick()
	{
		ds.handSelection = 0;
	}
	public void OnHandsGreenClick()
	{
		ds.handSelection = 1;
	}	
	public void OnHandsYellowClick()
	{
		ds.handSelection = 2;
	}	
	public void OnHandsPinkClick()
	{
		ds.handSelection = 3;
	}	
	public void OnHandsRedClick()
	{
		ds.handSelection = 4;
	}



	public void OnBodyBlueClick()
	{
		ds.bodySelection = 0;
	}
	public void OnBodyGreenClick()
	{
		ds.bodySelection = 1;
	}
	public void OnBodyYellowClick()
	{
		ds.bodySelection = 2;
	}
	public void OnBodyPinkClick()
	{
		ds.bodySelection = 3;
	}
	public void OnBodyRedClick()
	{
		ds.bodySelection = 4;
	}



	public void OnLegsBlueClick()
	{
		ds.legsSelection = 0;
	}
	public void OnLegsGreenClick()
	{
		ds.legsSelection = 1;
	}
	public void OnLegsYellowClick()
	{
		ds.legsSelection = 2;
	}
	public void OnLegsPinkClick()
	{
		ds.legsSelection = 3;
	}
	public void OnLegsRedClick()
	{
		ds.legsSelection = 4;
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

	public void OnNextClick()
	{
		if (ds.stage == 0) 
		{
			ds.stage++;
			Application.LoadLevel ("DragShapesMiniGame");
		} 
		else if (ds.stage == 1) 
		{
			ds.stage++;
			Application.LoadLevel ("NumberAddingMiniGame");
		} 
		else if (ds.stage == 2) 
		{
			ds.stage++;
			stageSelection = Random.Range (1, 4);
			if (stageSelection == 1)
			{
				Application.LoadLevel ("ForwardNumberMiniGame");
			}
			else if (stageSelection == 2)
			{
				Application.LoadLevel ("ForwardNumberMiniGame1");
			}
			else if (stageSelection == 3)
			{
				Application.LoadLevel ("ForwardNumberMiniGame2");
			}
		
		} 
		else if (ds.stage == 3) 
		{
			RemoveableUI = GameObject.FindGameObjectsWithTag ("RemoveUI");
			foreach (GameObject temp in RemoveableUI) 
			{
				temp.gameObject.SetActive (false);
				finishBg.gameObject.SetActive (true);
			}
		}
	}
}
