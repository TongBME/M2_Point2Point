using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using FFTAICommunicationLib;
using System;
using UnityEngine.SceneManagement;

public class SetBtn : MonoBehaviour {

    // Use this for initialization

    Button startBtn;
    Button loadBtn;

    // task1:StartX,StartY,EndX,EndY.
    public static double[] taskPoint = new double[16];
    void Start () {

        startBtn = GameObject.Find("Canvas/okBtn").GetComponent<Button>();
        startBtn.onClick.AddListener(OkBtnClick);
        loadBtn = GameObject.Find("Canvas/loadBtn").GetComponent<Button>();
        loadBtn.onClick.AddListener(LoadBtnClick);

    }

    // Update is called once per frame
    void Update()
    {
        //Vector2 a = new Vector2(DynaLinkHS.StatusRobot.PositionDataJoint1, DynaLinkHS.StatusRobot.PositionDataJoint2);
    }

    //load task information to .YAML file
    void LoadBtnClick()
    {
        /* 
         * get info in text and inputfield
         * */
        string subjectName = TaskSetting.nameInput.text;
        List<string> startPoint = new List<string>()
        {
            TaskSetting.task1StartTxt.text,TaskSetting.task2StartTxt.text,TaskSetting.task3StartTxt.text,TaskSetting.task4StartTxt.text,

        };
        List<string> endPoint = new List<string>()
        {
            TaskSetting.task1EndTxt.text,TaskSetting.task2EndTxt.text,TaskSetting.task3EndTxt.text,TaskSetting.task4EndTxt.text,

        };

        // sequence
        //int[] sequence = new int[] { 1, 2, 3, 4, 5};
        //SetYaml.IniTaskInfo(subjectName, randomSeq.GetRandomNum(sequence),startPoint,endPoint);
        SetYaml.IniTaskInfo(subjectName,startPoint,endPoint);

        /*
         *  destroy all gameobject
         */
        //GameObject.Destroy(startBtn, 0.3f);
        //GameObject.Destroy(loadBtn, 0.3f);
        //GameObject.Destroy(TaskSetting.task1Txt, 0.0f);
        //GameObject.Destroy(TaskSetting.task2Txt, 0.0f);
        //GameObject.Destroy(TaskSetting.task3Txt, 0.0f);
        //GameObject.Destroy(TaskSetting.task4Txt, 0.0f);
        //GameObject.Destroy(TaskSetting.task1StartTxt, 0.0f);
        //GameObject.Destroy(TaskSetting.task2StartTxt, 0.0f);
        //GameObject.Destroy(TaskSetting.task3StartTxt, 0.0f);
        //GameObject.Destroy(TaskSetting.task4StartTxt, 0.0f);
        //GameObject.Destroy(TaskSetting.task1EndTxt, 0.0f);
        //GameObject.Destroy(TaskSetting.task2EndTxt, 0.0f);
        //GameObject.Destroy(TaskSetting.task3EndTxt, 0.0f);
        //GameObject.Destroy(TaskSetting.task4EndTxt, 0.0f);
        //GameObject.Destroy(TaskSetting.nameInput, 0.0f);
        //GameObject.Destroy(MoveObject.objPoint, 0.0f);

        //SceneManager.LoadScene("M2SysEthHW-DLL",LoadSceneMode.Additive);
        SceneManager.LoadScene("M2SysEthHW-DLL");

    }

    void OkBtnClick()
    {
        switch (TaskSetting.txtTask)
        {
            case "外展起点":
               
                taskPoint[0] = Math.Round(DynaLinkHS.StatusRobot.PositionDataJoint1, 3);
                taskPoint[1] = Math.Round(DynaLinkHS.StatusRobot.PositionDataJoint2, 3);
                TaskSetting.task1StartTxt.color = Color.red;
                TaskSetting.txtTask = "外展终点";
                break;

            case "外展终点":
                taskPoint[2] = Math.Round(DynaLinkHS.StatusRobot.PositionDataJoint1, 3);
                taskPoint[3] = Math.Round(DynaLinkHS.StatusRobot.PositionDataJoint2, 3);
                TaskSetting.task1EndTxt.color = Color.red;
                TaskSetting.txtTask = "内旋起点";
                break;

            case "内旋起点":
                taskPoint[4] = Math.Round(DynaLinkHS.StatusRobot.PositionDataJoint1, 3);
                taskPoint[5] = Math.Round(DynaLinkHS.StatusRobot.PositionDataJoint2, 3);
                TaskSetting.task2StartTxt.color = Color.red;
                TaskSetting.txtTask = "内旋终点";
                break;

            case "内旋终点":
                taskPoint[6] = Math.Round(DynaLinkHS.StatusRobot.PositionDataJoint1, 3);
                taskPoint[7] = Math.Round(DynaLinkHS.StatusRobot.PositionDataJoint2, 3);
                TaskSetting.task2EndTxt.color = Color.red;
                TaskSetting.txtTask = "前伸起点";
                break;

            case "前伸起点":
                taskPoint[8] = Math.Round(DynaLinkHS.StatusRobot.PositionDataJoint1, 3);
                taskPoint[9] = Math.Round(DynaLinkHS.StatusRobot.PositionDataJoint2, 3);
                TaskSetting.task3StartTxt.color = Color.red;
                TaskSetting.txtTask = "前伸终点";
                break;

            case "前伸终点":
                taskPoint[10] = Math.Round(DynaLinkHS.StatusRobot.PositionDataJoint1, 3);
                taskPoint[11] = Math.Round(DynaLinkHS.StatusRobot.PositionDataJoint2, 3);
                TaskSetting.task3EndTxt.color = Color.red;
                TaskSetting.txtTask = "前伸外展起点";
                break;

            case "前伸外展起点":
                taskPoint[12] = Math.Round(DynaLinkHS.StatusRobot.PositionDataJoint1, 3);
                taskPoint[13] = Math.Round(DynaLinkHS.StatusRobot.PositionDataJoint2, 3);
                TaskSetting.task4StartTxt.color = Color.red;
                TaskSetting.txtTask = "前伸外展终点";
                break;

            case "前伸外展终点":
                taskPoint[0] = Math.Round(DynaLinkHS.StatusRobot.PositionDataJoint1, 3);
                taskPoint[1] = Math.Round(DynaLinkHS.StatusRobot.PositionDataJoint2, 3);
                TaskSetting.task4EndTxt.color = Color.red;
                TaskSetting.txtTask = "设置完成";
                break;
        }
      
    }
}
