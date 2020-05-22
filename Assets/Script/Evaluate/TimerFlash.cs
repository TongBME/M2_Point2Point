using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerFlash : MonoBehaviour {

    public static GameObject flash;
    private static Vector3 originScale;
    // Use this for initialization
    void Start () {

        flash = GameObject.Find("Canvas/timerFlash");
        flash.transform.position = new Vector2(0.0f, 0.0f);
        //flash = Instantiate(timeFlash, transform.position, Quaternion.identity);
        flash.SetActive(false);
        originScale = flash.transform.localScale;
    }
	
	// Update is called once per frame
	void Update () {

        if(RunFSM.currState == RunFSM.GameState_Enum.STATE_INCIRCLE)
        {
            //flash
            //print("倒计时");
            flash.GetComponent<Image>().fillAmount = Mathf.Lerp(0, 1, StateFunc.circleTimer / SetYaml.touchTimeSet);
        }
        else
        {
            flash.SetActive(false);
        }
        
    }

    public static void FlashSet()
    {
        flash.SetActive(true);
        float offset = 1;

        //postion
        flash.transform.position = ShowCircle.aimObject.transform.position;
        // size
        //Vector3 circleScale = ShowCircle.aimObject.transform.localScale;
        Vector3 localScale = new Vector3(originScale.x * offset, originScale.y * offset, originScale.z * offset);
        flash.transform.localScale = localScale;
    }
}
