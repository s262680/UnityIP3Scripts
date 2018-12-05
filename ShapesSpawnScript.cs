using UnityEngine;
using System.Collections;

public class ShapesSpawnScript : MonoBehaviour {

	GameObject[] shapesFab;
	int spNum=0;
	GameObject shape;
	int shapesCount=0;
	public bool spawnTrigger=false;
	int combination=0;
	// Use this for initialization
	void Start () {
		shapesFab = new GameObject[3];

		combination = Random.Range (1, 4);
		if (combination == 1) 
		{
			SpawnShapes1 ();
		}
		else if (combination == 2) 
		{
			SpawnShapes2 ();
		}
		else if (combination == 3) 
		{
			SpawnShapes3 ();
		}

	}
	
	// Update is called once per frame
	void Update () {
		if (spawnTrigger) 
		{
			if (combination == 1) 
			{
				SpawnShapes1 ();
				spawnTrigger = false;
			}
			else if (combination == 2) 
			{
				SpawnShapes2 ();
				spawnTrigger = false;
			}
			else if (combination == 3) 
			{
				SpawnShapes3 ();
				spawnTrigger = false;
			}
		}
	}

	public void SpawnShapes1()
	{
		shapesFab [0] = Resources.Load ("TriFab") as GameObject;
		shapesFab [1] = Resources.Load ("StarFab") as GameObject;
		shapesFab [2] = Resources.Load ("RecFab") as GameObject;
		shape = (GameObject)Instantiate (shapesFab [shapesCount], transform.position, transform.rotation);
		switch (shapesCount) 
		{
		case 0:
			shape.name = "tri";
			break;
		case 1:
			shape.name = "star";
			break;
		case 2:
			shape.name = "rec";
			break;
		}
		shapesCount += 1;
	}
	public void SpawnShapes2()
	{
		shapesFab [0] = Resources.Load ("StarFab") as GameObject;
		shapesFab [1] = Resources.Load ("TriFab") as GameObject;
		shapesFab [2] = Resources.Load ("RecFab") as GameObject;
		shape = (GameObject)Instantiate (shapesFab [shapesCount], transform.position, transform.rotation);
		switch (shapesCount) 
		{
		case 0:
			shape.name = "star";
			break;
		case 1:
			shape.name = "tri";
			break;
		case 2:
			shape.name = "rec";
			break;
		}
		shapesCount += 1;
	}
	public void SpawnShapes3()
	{
		shapesFab [0] = Resources.Load ("RecFab") as GameObject;
		shapesFab [1] = Resources.Load ("StarFab") as GameObject;
		shapesFab [2] = Resources.Load ("TriFab") as GameObject;
		shape = (GameObject)Instantiate (shapesFab [shapesCount], transform.position, transform.rotation);
		switch (shapesCount) 
		{
		case 0:
			shape.name = "rec";
			break;
		case 1:
			shape.name = "star";
			break;
		case 2:
			shape.name = "tri";
			break;
		}
		shapesCount += 1;
	}
	/*
	public void SpawnShapes()
	{
		spNum = Random.Range (0, shapesCount);
		shape = (GameObject)Instantiate (shapesFab [spNum], transform.position, transform.rotation);
		switch (spNum) 
		{
		case 0:
			shape.name = "tri";
			break;
		case 1:
			shape.name = "star";
			break;
		case 2:
			shape.name = "rec";
			break;
		}
		shapesCount -= 1;

	}
	*/
}
