using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FFTAICommunicationLib;
using System.Text;
using System.Timers;

public class InitSetting : MonoBehaviour {

    private Vector2 screenSize;
    private static Timer timerRealse;
    // Use this for initialization
    void Start()
    {
        
        ScreenSize.ScreenSet();

        // center point
        //DynaLinkHS.CmdPassiveMovementControl(ScreenSize.M2_SIZE_X, ScreenSize.M2_SIZE_Y, (float)0.05);
        DynaLinkHS.CmdFindHomePosition();

        timerRealse = new Timer();
        timerRealse.Interval = 10000;  //Wait for 10 seconds
        timerRealse.Elapsed += startMov1; //Hook up the elapsed event for the timer
        timerRealse.AutoReset = false; //Have the timer fire repeated events(true is the default)
        timerRealse.Enabled = false;
        timerRealse.Start();

    }

    private static void startMov1(object source, System.Timers.ElapsedEventArgs e)
    {
        DynaLinkHS.CmdTransparentControl(0.2f, 0.2f, 1.0f, 1.0f, 10.0f, 10.0f, 10.0f, 10.0f);
        DynaLinkHS.CmdServoOff();
        SetYaml.LoadTaskInfo();// load .yaml file
        print("初始化完成，实验开始");
        // first block set
        RunFSM.currState = RunFSM.GameState_Enum.STATE_BLOCKSET;   
    }

    ///*
    // Initiate Control Mode(mass/damping/spring)
    /// for M2, the parameters are
    ///     - origin/target position x [原始/目标位置 x 轴] (type : float, unit : m, range : )
    ///     - origin/target position y [原始/目标位置 y 轴] (type : float, unit : m, range : )
    ///     - M (mass) x [模拟质量 x 轴] (type : float, unit : kg, range : )
    ///     - M (mass) y [模拟质量 y 轴] (type : float, unit : kg, range : )
    ///     - B (damping) x [模拟阻尼 x 轴] (type : float, unit : N/(m/s), range : )
    ///     - B (damping) y [模拟阻尼 y 轴] (type : float, unit : N/(m/s), range : )
    ///     - K (spring) x [模拟弹簧 x 轴] (type : float, unit : N/m, range : )
    ///     - K (spring) y [模拟弹簧 y 轴] (type : float, unit : N/m, range : )
    ///*  

    //DynaLinkHS.CmdTransparentControl(5f, 5f, 10f, 10f, 10f, 10f, 10f, 10f);


}
