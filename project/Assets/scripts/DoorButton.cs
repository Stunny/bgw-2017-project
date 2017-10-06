using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {

	}

	void OnMouseOver(){
		if(Input.GetMouseButtonDown(0)){
			Debug.Log("PULSO");
			sendCitizenToDoor();
		}
		if (Input.GetMouseButtonUp(0)) {
			Debug.Log("SUELTO");
		}
	}

	void sendCitizenToDoor(){
		GameObject ctzn = GameObject.Find("citizen");
		Citizen ctzscrpt = (Citizen) ctzn.GetComponent(typeof(Citizen));

		if(this.gameObject.transform.name == "Happy"){
			ctzscrpt.sendToHappyDoor();
		}else{
			ctzscrpt.sendToHappifier();
		}

	}
}
