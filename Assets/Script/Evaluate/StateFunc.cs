using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine.UI;
using System;
using System.Timers;
using FFTAICommunicationLib;


public class StateFunc: MonoBehaviour {

    private static int trials; // trials number in each task
    private static float timeLine;
    public static float circleTimer;
    private static float breakTimer;

    private static StringBuilder csvContent;

    //collisition flag
    public static bool isCollisionOn;
    public static bool isCollisionOff;
    public static bool isEMGRecording;

    private static float m2MoveTimer; // M2 moves back
    private static float blockTimer;
    public static int blockNum = -1;


    private void Start()
    {
        blockTimer = 5f;
    }

    private void Update()
    {
        //print(blockNum);
    }

    public static void Cmd2Robot()
    {
        // CMD: M2 move to starting point
        string taskPointKey = SetYaml.taskNames[blockNum];
        float[] taskPointValue = new float[2];
        SetYaml.startPointDic.TryGetValue(taskPointKey, out taskPointValue);
        print(taskPointKey);
        DynaLinkHS.CmdPassiveMovementControl(taskPointValue[0], taskPointValue[1], (float)0.08);
        
        timeLine += Time.deltaTime;
        csvContent.AppendLine((float)timeLine + "," + trials + "," + "CMDM2Reset" + "," + DynaLinkHS.StatusRobot.PositionDataJoint1 + "," + DynaLinkHS.StatusRobot.PositionDataJoint2);
        RunFSM.currState = RunFSM.GameState_Enum.STATE_MOVE2START;
        
        RunFSM.EMG.StartRecording();// start record sEMG
    }
    public static void Move2Start()
    {
        m2MoveTimer -= Time.deltaTime;
        if (m2MoveTimer < 0)
        {
            timeLine += Time.deltaTime;
            csvContent.AppendLine((float)timeLine + "," + trials + "," + "M2Reset" + "," + DynaLinkHS.StatusRobot.PositionDataJoint1 + "," + DynaLinkHS.StatusRobot.PositionDataJoint2);
            DynaLinkHS.CmdServoOff();
            ShowCircle.EndPointCircle(blockNum);
            RunFSM.currState = RunFSM.GameState_Enum.STATE_TRIALSTART;
        }
        else
        {
            timeLine += Time.deltaTime;
            csvContent.AppendLine((float)timeLine + "," + trials + "," + "M2Reset" + "," + DynaLinkHS.StatusRobot.PositionDataJoint1 + "," + DynaLinkHS.StatusRobot.PositionDataJoint2);
        }
        
    }

    public static void TrialStart()
    {
        // record data
        timeLine += Time.deltaTime;
        csvContent.AppendLine((float)timeLine + "," + trials + "," + "TrialStart" + "," + DynaLinkHS.StatusRobot.PositionDataJoint1 + "," + DynaLinkHS.StatusRobot.PositionDataJoint2);

        if (isCollisionOn == true)
        {
            // 【circle shows】transfer to 【in circle】
            RunFSM.currState = RunFSM.GameState_Enum.STATE_INCIRCLE;
        }     
    }

    public static void InCircle()
    {
        circleTimer -= Time.deltaTime;
        ShowCircle.aimObject.GetComponent<SpriteRenderer>().color = Color.blue;
        // record data
        timeLine += Time.deltaTime;
        csvContent.AppendLine((float)timeLine + "," + trials + "," + "InCircle" + "," + DynaLinkHS.StatusRobot.PositionDataJoint1 + "," + DynaLinkHS.StatusRobot.PositionDataJoint2);

        if (isCollisionOff == true)
        {
            // 【in circle】transfer to【out circle】
            RunFSM.currState = RunFSM.GameState_Enum.STATE_OUTCIRCLE;
        }
        else
        {
            if (circleTimer <= 0f)
            {
                // 【in circle】transfer to【trial succeed】
                RunFSM.currState = RunFSM.GameState_Enum.STATE_TRIALSUCCEED;
            }
        }

    }
    public static void OutCircle()
    {
        ShowCircle.aimObject.GetComponent<SpriteRenderer>().color = Color.grey;
        // record data
        timeLine += Time.deltaTime;
        csvContent.AppendLine((float)timeLine + "," + trials + "," + "OutCircle" + "," + DynaLinkHS.StatusRobot.PositionDataJoint1 + "," + DynaLinkHS.StatusRobot.PositionDataJoint2);

        if (isCollisionOn == true)
        {
            // 【out circle】transfer to【in circle】
            RunFSM.currState = RunFSM.GameState_Enum.STATE_INCIRCLE;
        }  
    }

    public static void TaskSucceed()
    {
        ShowCircle.aimObject.GetComponent<Renderer>().enabled = false; // circle vanish
        // record data
        timeLine += Time.deltaTime;
        csvContent.AppendLine((float)timeLine + "," + trials + "," + "TrialSucceed" + "," + DynaLinkHS.StatusRobot.PositionDataJoint1 + "," + DynaLinkHS.StatusRobot.PositionDataJoint2);
        trials += 1;
        breakTimer = SetYaml.breakTimeSet;// breaktimer start
        // 【trial succeed】transfer to【break】
        DynaLinkHS.CmdPauseMotion();
        RunFSM.currState = RunFSM.GameState_Enum.STATE_BREAK;
        
    }

    public static void Break()
    {
        string blockName = SetYaml.taskNames[blockNum];
        //save sEMG
        string fileNamesemg = SetYaml.subjectName + "_" + blockName + "_" + GlobalVar.sEMGCSVNAME + "_" + Convert.ToString(trials) + ".csv";
        string csvfullemg = System.Environment.CurrentDirectory + "\\" + GlobalVar.expFolderName + "\\" + fileNamesemg;
        if (RunFSM.EMG.IsConnected())
        {
            if(isEMGRecording == false)
            {
                RunFSM.EMG.StopRecording(csvfullemg);
                isEMGRecording = true;
            }            
        }

        if (trials >= SetYaml.trialNum)
        {
            timeLine += Time.deltaTime;
            csvContent.AppendLine((float)timeLine + "," + trials + "," + "TrialBreak" + "," + DynaLinkHS.StatusRobot.PositionDataJoint1 + "," + DynaLinkHS.StatusRobot.PositionDataJoint2);
            //save kinematics
            
            string fileName = SetYaml.subjectName + "_" + blockName + "_"+ GlobalVar.CSVNAME+".csv";
            string csvfullfilename = System.Environment.CurrentDirectory + "\\" + GlobalVar.expFolderName + "\\" + fileName;
            File.WriteAllText(csvfullfilename, "Time,Trial,State,PositionX,PositionY\n");
            File.AppendAllText(csvfullfilename, csvContent.ToString());
    
            // finish 4 blocks
            if (blockNum >= 3)
            {
                Application.Quit();
            }
            else
            {
                RunFSM.currState = RunFSM.GameState_Enum.STATE_BLOCKSET;
                blockTimer = 5f;
            }

        }
        else
        {
            
            timeLine += Time.deltaTime;
            csvContent.AppendLine((float)timeLine + "," + trials + "," + "TrialBreak" + "," + DynaLinkHS.StatusRobot.PositionDataJoint1 + "," + DynaLinkHS.StatusRobot.PositionDataJoint2);
            breakTimer -= Time.deltaTime; // break timer -- 
            if (breakTimer <= 0f)
            {
                DynaLinkHS.CmdServoOff();
                DynaLinkHS.CmdTransparentControl(0.2f, 0.2f, 1.0f, 1.0f, 10.0f, 10.0f, 10.0f, 10.0f);
                // next trial set
                isCollisionOn = false;
                isCollisionOff = false;
                m2MoveTimer = 5f;
                RunFSM.currState = RunFSM.GameState_Enum.STATE_CMD2ROBOT;
                
            }
        }
            
    }

    public static void BlockSet()
    {
        blockTimer -= Time.deltaTime; // preparation time
        if (blockTimer < 0)
        {
            // init variable 
            isCollisionOn = false;
            isCollisionOff = false;
            isEMGRecording = false;
            timeLine = 0f;
            trials = 0;
            blockNum++;
            m2MoveTimer = 5f;
            csvContent = new StringBuilder(); // csv builder
            RunFSM.currState = RunFSM.GameState_Enum.STATE_CMD2ROBOT;
            print("倒计时完成 cmd开始");
        }        

    }
   
    /// <summary>
    /// Collision Detect
    /// </summary>
    /// <param name="collision"></param>
  
}
