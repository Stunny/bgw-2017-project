using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : ExtendedBehavior {

	private const float RESPAWN_DELAY = 1.5f;

	private int score;
	public Text scoreText;

	private GameObject citizen;
	private Timer timer;
	private HappyMeterController happymeter;
	private DataController datacontroller;

	// Inicializacion de los subcontroladores y de los parametros funcionales
	//
	//
	void Start () {
		score = 0;
		scoreText = GameObject.Find("Canvas/Score").GetComponent<Text>();

		GameObject timergo = GameObject.Find("TimerGO");
		timer = (Timer)timergo.GetComponent(typeof(Timer));

		GameObject happymetergo = GameObject.Find("HappyMeterGO");
		happymeter = (HappyMeterController) happymetergo.GetComponent(typeof(HappyMeterController));

		GameObject datacontrollergo = GameObject.Find("DataController");
		datacontroller = (DataController) datacontrollergo.GetComponent(typeof(DataController));

		citizen = GameObject.Find("citizen");
		citizen.SetActive(false);
		Wait(2f, ()=>{addNewCitizen();});

	}

	// Funcion que actualiza los datos del juego a cada frame
	//
	void Update(){
		UpdateScore();
		if(timer.finished || happymeter.isBoom()){
			SceneManager.LoadScene("gameover");
		}
	}

	//
	// Actualiza la puntuacion y el happymeter del juego a cada boton
	// pulsado en el garito
	void UpdateScore () {
		scoreText.text = "Score: "+score;
	}

	//
	//Incrementa/decrementa la puntuacion-happymetro de la interfaz
	//
	private void incScore(bool citizenHappiness, bool decision){
		if(citizenHappiness == decision){
			score+=1;
			happymeter.incHappyMeter();
		}
		else{
			happymeter.decrHappyMeter();
		}
	}

	//
	// Destruye el ciudadano que actualmente se encuentra en el mostrador
	// y espera 1.5 segundos antes de hacer respawn al siguiente
	public void DestroyCitizen(bool citizenHappiness, bool decision){
		citizen.gameObject.SetActive(false);
		incScore(citizenHappiness, decision);
		timer.stopTimer();
		Wait(RESPAWN_DELAY, ()=>{
			addNewCitizen();
			});
	}

	//
	// Hace respawnear un nuevo ciudadano a interactuar con el agente de aduanas
	//
	private void addNewCitizen(){
		((Citizen)citizen.GetComponent(typeof(Citizen))).InitData(datacontroller.getNewCitizenData());
		citizen.SetActive(true);
		timer.ResetTimer();
	}
}
