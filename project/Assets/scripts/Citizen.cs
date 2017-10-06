using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Citizen : MonoBehaviour {

	public bool isHappy;
	private GameController controller;

	void Awake(){
		InitData();
	}

	// Use this for initialization
	void Start () {
		GameObject gcontobj = GameObject.Find("Game Controller");
		controller = (GameController)gcontobj.GetComponent(typeof(GameController));
	}

	// Update is called once per frame
	void Update () {

	}

	public void sendToHappyDoor(){
		Debug.Log("oh sweet");

		controller.DestroyCitizen(isHappy, true);

		//Send to happy door animation
	}

	public void sendToHappifier(){
		Debug.Log("fuck my life");

		controller.DestroyCitizen(isHappy, false);

		//Send to happifier door animation
	}

	public void InitData(){
		
	}
}
