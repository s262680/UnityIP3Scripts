using UnityEngine;
using System.Collections;

public class OnHelpClick : MonoBehaviour {



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnHelperClick()
	{
		AudioSource audio = GetComponent<AudioSource>();
		audio.Play();
	}
}
