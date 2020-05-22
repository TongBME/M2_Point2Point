using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using FFTAICommunicationLib;
using UnityEngine.UI;

public class RunFSM : MonoBehaviour {
    
    // all states 
    public enum GameState_Enum
    {
        STATE_CMD2ROBOT,
        STATE_MOVE2START, // M2 moves to start
        STATE_TRIALSTART, // endpoint shows
        STATE_INCIRCLE, // move in circle position
        STATE_OUTCIRCLE, // move out circle position
        STATE_TRIALSUCCEED, // touch circle within 3 seconds
        STATE_BREAK,
        STATE_BLOCKSET,// 10 trials finish, task(block) changes
        NULL,
    }; 

    public static GameState_Enum currState; // current state

    public static DelsysEMG EMG;
    public long t0;
    public static Text EMGState;

    private void Start()
    {
        currState = GameState_Enum.NULL;
        EMGState = GameObject.Find("Canvas/EMGStateTxt").GetComponent<Text>();
        EMGState.gameObject.SetActive(false);

        t0 = DateTime.Now.Ticks;
        EMG = new DelsysEMG();
        EMG.Init(t0);
        EMG.Connect();
        if (EMG.IsConnected())
        {
            EMG.StartAcquisition();
            EMGState.text = EMG.GetNbSensors() + "EMGs connected.";
            EMGState.gameObject.SetActive(true);
            Debug.Log("Delsys通道" + EMG.GetNbSensors());
        }
        else
        {
            EMGState.gameObject.SetActive(true);
            EMGState.text = "EMGs NOT connected.";
        }

    }
    // Update is called once per frame
    void Update () {

        if (EMG.IsConnected())
        {
            EMG.Update();
        }
            
        switch (currState)
        {
            case GameState_Enum.STATE_CMD2ROBOT:
                StateFunc.Cmd2Robot();
                break;
            case GameState_Enum.STATE_MOVE2START:
                StateFunc.Move2Start();
                break;
            case GameState_Enum.STATE_TRIALSTART:
                StateFunc.TrialStart();
                break;

            case GameState_Enum.STATE_INCIRCLE:
                StateFunc.InCircle();
                break;

            case GameState_Enum.STATE_OUTCIRCLE:
                StateFunc.OutCircle();
                break;

            case GameState_Enum.STATE_TRIALSUCCEED:
                StateFunc.TaskSucceed();
                break;

            case GameState_Enum.STATE_BREAK:
                StateFunc.Break();
                break;

            case GameState_Enum.STATE_BLOCKSET:
                StateFunc.BlockSet();
                break;

            case GameState_Enum.NULL:
                break;
        }
    }
}
