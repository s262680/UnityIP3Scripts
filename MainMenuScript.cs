using UnityEngine;
using System.Collections;

public class MainMenuScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//load egg selection scene when this function call which trigger by button press
	public void OnStartClick()
	{
		Application.LoadLevel ("EggSelection");
	}

	//quit the game when this function call which trigger by button press
	public void OnQuit()
	{
		Application.Quit ();
	}
}
