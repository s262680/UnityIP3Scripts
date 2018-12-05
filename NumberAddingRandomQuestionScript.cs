using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NumberAddingRandomQuestionScript : MonoBehaviour {

	int Q1;
	int Q2;
	int Ans;
	//Text question;
	Image Ans1;
	Image Ans2;
	Image Ans3;
	Image Ans4;
	Image Qnum1;
	Image Qnum2;
	Image Qans;
	Text result;
	//string displayAns="?";
	int ansChoice;
	int rngAns1;
	int rngAns2;
	int rngAns3;

	public Sprite[] ObjImg;
	//public Sprite questionMark;
	GameObject egg;
	EggMovement eggMovement;
	GameObject data;
	DataScript ds;

	GameObject wrongSound;

	// Use this for initialization
	void Start () {

		wrongSound = GameObject.Find ("wrongSound");

		data = GameObject.Find ("Data");
		ds = data.GetComponent<DataScript> ();

		egg = GameObject.Find ("egg");
		eggMovement=egg.GetComponent<EggMovement>();

		//assign random value to the equation
		Q1 = Random.Range (1,6);
		Q2 = Random.Range (1,5);
		Ans = Q1 + Q2;
	
		result = transform.Find ("Result").GetComponent<Text> ();
		Ans1 = transform.Find ("Ans1").GetComponent<Image> ();
		Ans2 = transform.Find ("Ans2").GetComponent<Image> ();
		Ans3 = transform.Find ("Ans3").GetComponent<Image> ();
		Ans4 = transform.Find ("Ans4").GetComponent<Image> ();
		Qnum1 = transform.Find ("Qnum1").GetComponent<Image> ();
		Qnum2 = transform.Find ("Qnum2").GetComponent<Image> ();
		Qans = transform.Find ("Ans").GetComponent<Image> ();
	
		//randomly pick the currect answer button
		ansChoice = Random.Range (1, 5);

		//randomly pick the wrong answer, if they equal to correct
		//answer, add 1 to it
		rngAns1 = Random.Range (1, 10);
		rngAns2 = Random.Range (1, 10);
		rngAns3 = Random.Range (1, 10);

		if (rngAns1 == Ans) 
		{
			rngAns1 +=1;
		} 
		if (rngAns2 == Ans) 
		{
			rngAns2 +=1;
		} 
		if (rngAns3 == Ans) 
		{
			rngAns3 +=1;
		} 

	}

	// Update is called once per frame
	void Update () {
		
		//assign images to the equation that represent numbers
		Qnum1.sprite = ObjImg [Q1 - 1];
		Qnum2.sprite = ObjImg [Q2 - 1];



		switch(ansChoice)
		{
		case 1:
			Ans1.sprite=ObjImg[Ans-1];
			break;
		case 2:
			Ans2.sprite=ObjImg[Ans-1];
			break;
		case 3:
			Ans3.sprite=ObjImg[Ans-1];
			break;
		case 4:
			Ans4.sprite=ObjImg[Ans-1];
			break;
	
		}

		//assign images to the answers
		if (ansChoice == 1)
		{
			Ans1.sprite=ObjImg[Ans-1];
			Ans2.sprite=ObjImg[rngAns1-1];
			Ans3.sprite=ObjImg[rngAns2-1];
			Ans4.sprite=ObjImg[rngAns3-1];
		}
		else if (ansChoice == 2)
		{
			Ans2.sprite=ObjImg[Ans-1];
			Ans1.sprite=ObjImg[rngAns1-1];
			Ans3.sprite=ObjImg[rngAns2-1];
			Ans4.sprite=ObjImg[rngAns3-1];
		
		}
		else if (ansChoice == 3)
		{
			Ans3.sprite=ObjImg[Ans-1];
			Ans2.sprite=ObjImg[rngAns1-1];
			Ans1.sprite=ObjImg[rngAns2-1];
			Ans4.sprite=ObjImg[rngAns3-1];
		
		}
		else if (ansChoice == 4)
		{
			Ans4.sprite=ObjImg[Ans-1];
			Ans2.sprite=ObjImg[rngAns1-1];
			Ans3.sprite=ObjImg[rngAns2-1];
			Ans1.sprite=ObjImg[rngAns3-1];
	
		}

	}


	//if clicking the correct button, answer will be display on the equation
	//and egg movement will be triggered to allow process to the next level
	public void OnButton1Click()
	{
		if (ansChoice == 1) 
		{
			Qans.sprite = ObjImg[Ans-1];
			result.color = new Color (0, 1, 0, 1);
			result.text="Correct!!";
			eggMovement.movementTrigger = true;
			AudioSource audio = GetComponent<AudioSource> ();
			audio.Play();
		} 
		else 
		{
			AudioSource audio = wrongSound.GetComponent<AudioSource>();
			audio.Play();

			result.color = new Color (1, 0, 0, 1);
			result.text="Wrong Answer, try again :)";
		}
	}
	public void OnButton2Click()
	{
		if (ansChoice == 2) 
		{
			Qans.sprite = ObjImg[Ans-1];
			result.color = new Color (0, 1, 0, 1);
			result.text="Correct!!";
			eggMovement.movementTrigger = true;
			AudioSource audio = GetComponent<AudioSource> ();
			audio.Play();

		}
		else 
		{
			AudioSource audio = wrongSound.GetComponent<AudioSource>();
			audio.Play();

			result.color = new Color (1, 0, 0, 1);
			result.text="Wrong Answer, try again :)";
		}
	}
	public void OnButton3Click()
	{
		if (ansChoice == 3) 
		{
			Qans.sprite = ObjImg[Ans-1];
			result.color = new Color (0, 1, 0, 1);
			result.text="Correct!!";
			eggMovement.movementTrigger = true;
			AudioSource audio = GetComponent<AudioSource> ();
			audio.Play();

		}
		else 
		{
			AudioSource audio = wrongSound.GetComponent<AudioSource>();
			audio.Play();

			result.color = new Color (1, 0, 0, 1);
			result.text="Wrong Answer, try again :)";
		}
	}
	public void OnButton4Click()
	{
		if (ansChoice == 4) 
		{
			Qans.sprite = ObjImg[Ans-1];
			result.color = new Color (0, 1, 0, 1);
			result.text="Correct!!";
			eggMovement.movementTrigger = true;
			AudioSource audio = GetComponent<AudioSource> ();
			audio.Play();

		}
		else 
		{
			AudioSource audio = wrongSound.GetComponent<AudioSource>();
			audio.Play();

			result.color = new Color (1, 0, 0, 1);
			result.text="Wrong Answer, try again :)";
		}
	}

	public void OnRestartClick()
	{
		Application.LoadLevel ("NumberAddingMiniGame");
	}

	public void OnNextClick()
	{
		Application.LoadLevel ("ForwardNumberMiniGame");
	}

	public void OnQuit()
	{
		Application.Quit ();
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
