using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using FFTAICommunicationLib;
using System;

public class TaskSetting : MonoBehaviour {

    /*
     * task1: abduction
     * task2: aduction
     * task3: readching
     * task4: abduction within the reaching posture
    */

    public static Text task1Txt;
    public static Text task2Txt;
    public static Text task3Txt;
    public static Text task4Txt;

    public static Text task1StartTxt;
    public static Text task2StartTxt;
    public static Text task3StartTxt;
    public static Text task4StartTxt;
    public static Text task1EndTxt;
    public static Text task2EndTxt;
    public static Text task3EndTxt;
    public static Text task4EndTxt;

    public static InputField nameInput;

    public static string txtTask;
    // Use this for initialization
    void Start () {

        //Initiate 4 task texts
        task1Txt = GameObject.Find("Canvas/taskTxt/Text1").GetComponent<Text>();
        task1Txt.gameObject.SetActive(false);
        task2Txt = GameObject.Find("Canvas/taskTxt/Text2").GetComponent<Text>();
        task2Txt.gameObject.SetActive(false);
        task3Txt = GameObject.Find("Canvas/taskTxt/Text3").GetComponent<Text>();
        task3Txt.gameObject.SetActive(false);
        task4Txt = GameObject.Find("Canvas/taskTxt/Text4").GetComponent<Text>();
        task4Txt.gameObject.SetActive(false);

        //Initiate 4 task text: start point, end point
        task1StartTxt = GameObject.Find("Canvas/startTxt/startTxt1").GetComponent<Text>();
        task1StartTxt.gameObject.SetActive(false);
        task2StartTxt = GameObject.Find("Canvas/startTxt/startTxt2").GetComponent<Text>();
        task2StartTxt.gameObject.SetActive(false);
        task3StartTxt = GameObject.Find("Canvas/startTxt/startTxt3").GetComponent<Text>();
        task3StartTxt.gameObject.SetActive(false);
        task4StartTxt = GameObject.Find("Canvas/startTxt/startTxt4").GetComponent<Text>();
        task4StartTxt.gameObject.SetActive(false);
        task1EndTxt = GameObject.Find("Canvas/endTxt/endTxt1").GetComponent<Text>();
        task1EndTxt.gameObject.SetActive(false);
        task2EndTxt = GameObject.Find("Canvas/endTxt/endTxt2").GetComponent<Text>();
        task2EndTxt.gameObject.SetActive(false);
        task3EndTxt = GameObject.Find("Canvas/endTxt/endTxt3").GetComponent<Text>();
        task3EndTxt.gameObject.SetActive(false);
        task4EndTxt = GameObject.Find("Canvas/endTxt/endTxt4").GetComponent<Text>();
        task4EndTxt.gameObject.SetActive(false);

        nameInput = GameObject.Find("Canvas/nameInput").GetComponent<InputField>();

        txtTask = "外展起点";
    }

    // Update is called once per frame
    void Update()
    {

        // convert position num to string
        float temx = DynaLinkHS.StatusRobot.PositionDataJoint1;
        float temy = DynaLinkHS.StatusRobot.PositionDataJoint2;
        string X = (Math.Round(temx,3)).ToString();
        string Y = (Math.Round(temy,3)).ToString();
        string textShow = X + "," + Y;

        // task 1
        switch (txtTask)
        {
            case "外展起点":
                task1Txt.gameObject.SetActive(true);
                task1StartTxt.gameObject.SetActive(true);
                task1StartTxt.text = textShow;
                break;
            case "外展终点":
                task1EndTxt.gameObject.SetActive(true);
                task1EndTxt.text = textShow;
                break;

            case "内旋起点":
                task2Txt.gameObject.SetActive(true);
                task2StartTxt.gameObject.SetActive(true);
                task2StartTxt.text = textShow;
                break;
            case "内旋终点":
                task2EndTxt.gameObject.SetActive(true);
                task2EndTxt.text = textShow;
                break;

            case "前伸起点":
                task3Txt.gameObject.SetActive(true);
                task3StartTxt.gameObject.SetActive(true);
                task3StartTxt.text = textShow;
                break;
            case "前伸终点":
                task3EndTxt.gameObject.SetActive(true);
                task3EndTxt.text = textShow;
                break;

            case "前伸外展起点":
                task4Txt.gameObject.SetActive(true);
                task4StartTxt.gameObject.SetActive(true);
                task4StartTxt.text = textShow;
                break;
            case "前伸外展终点":
                task4EndTxt.gameObject.SetActive(true);
                task4EndTxt.text = textShow;
                break;

            case "设置完成":
                break;
        }

        //remindTxt.text;

    }
        
}
