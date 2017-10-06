using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HappyMeterController : MonoBehaviour {
    SpriteRenderer sr;
    public Sprite[] sprites;
    int i;

    private bool boom;

    // Use this for initialization
    void Start () {
        // sprites = new Sprite[5];
        i = 4;
        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[i];
        boom = false;
    }

	// Update is called once per frame
	void Update () {

    }

    public void incHappyMeter(){
      if(i < 4) i++;
      gameObject.GetComponent<SpriteRenderer>().sprite = sprites[i];
    }

    public void decrHappyMeter(){
      if(i > 0){
           i--;
       }else{
           boom = true;
       }
      gameObject.GetComponent<SpriteRenderer>().sprite = sprites[i];
    }

    public bool isBoom(){
        return boom;
    }
}
