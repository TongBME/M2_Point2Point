using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        StateFunc.circleTimer = SetYaml.touchTimeSet;
        StateFunc.isCollisionOn = true;
        StateFunc.isCollisionOff = false;
        TimerFlash.FlashSet();

    }

    void OnCollisionExit2D(Collision2D collision)
    {
        StateFunc.isCollisionOff = true;
        StateFunc.isCollisionOn = false;
    }
}
