using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RemindTxt : MonoBehaviour {

    public static Text remindTxt;
    // Use this for initialization
    void Start () {
        remindTxt = GameObject.Find("Canvas/remindTxt").GetComponent<Text>();
        remindTxt.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {

        remindTxt.gameObject.SetActive(true);
        string taskName = "";

        switch (StateFunc.blockNum)
        {
            case 0:
                taskName = "外展";
                break;
            case 1:
                taskName = "内旋";
                break;
            case 2:
                taskName = "前伸";
                break;
            case 3:
                taskName = "前伸+外展";
                break;
        }
            
            remindTxt.text = taskName + "运动";
    }
        

}
