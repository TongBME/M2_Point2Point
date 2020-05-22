using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FFTAICommunicationLib;
using System.Timers;

public class InitM2 : MonoBehaviour {

    
    private static Timer timerRealse;
    // Use this for initialization
    void Start () {

        ScreenSize.ScreenSet();
       // center point
        //DynaLinkHS.CmdPassiveMovementControl(ScreenSize.SCREEN_MID_X, ScreenSize.SCREEN_MID_X, (float)0.05);
        //DynaLinkHS.CmdPassiveMovementControl(ScreenSize.SCREEN_MID_X, ScreenSize.SCREEN_MID_Y, (float)0.05);
        DynaLinkHS.CmdFindHomePosition();

        timerRealse = new Timer();
        timerRealse.Interval = 10000;  //Wait for 10 seconds
        timerRealse.Elapsed += startMov; //Hook up the elapsed event for the timer
        timerRealse.AutoReset = false; //Have the timer fire repeated events(true is the default)
        timerRealse.Enabled = false;
        timerRealse.Start();
    }
	
    private static void startMov(object source, System.Timers.ElapsedEventArgs e)
    {
        DynaLinkHS.CmdServoOff();
    }
    // Update is called once per frame

}
