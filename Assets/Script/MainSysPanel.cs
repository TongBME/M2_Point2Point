using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;
using FFTAICommunicationLib;
using System.Threading;
using UnityEngine.SceneManagement;
using System.Timers;

public class MainSysPanel : MonoBehaviour {

    public MainSysPanel MainPanel;

    public UpgradePanelManager UpgradePanelManager;

    public GameObject Player;
    public GameObject Beacon;

    public Button ConnectNetBtn;
    public Button DisConnectNetBtn;

    public Button TrainBtn;
    public Button EvaluateBtn;
    public Button PreSetBtn;
    

    private System.Timers.Timer timerInit;
    private static bool isCarGame;

    // Use this for initialization
    void Start()
    {
        ConnectNetBtn.onClick.AddListener(ConnectNetBtnClick);
        DisConnectNetBtn.onClick.AddListener(DisConnectNetBtnClick);
        TrainBtn.onClick.AddListener(OnTrainBtnClick);
        EvaluateBtn.onClick.AddListener(OnEvaluateBtnClick);
        PreSetBtn.onClick.AddListener(OnPreSetBtnClick);
    }

    void FixedUpdate()
    {
    }

    void ConnectNetBtnClick()
    {
        DynaLinkCore.ConnectClick();
    }

    void DisConnectNetBtnClick()
    {
        DynaLinkCore.StopSocket();
    }


    private void Update()
    {
    }
    private void CarGameStart(object source, System.Timers.ElapsedEventArgs e)
    {
        DynaLinkHS.CmdServoOff();
        isCarGame = true;
    }

    private void OnTrainBtnClick()
    {
        SceneManager.LoadScene("Training");  // touching training
    }
    private void OnEvaluateBtnClick()
    {
        // keep last scene active 【LoadSceneMode.Additive】
        //SceneManager.LoadScene("Evaluate", LoadSceneMode.Additive);  // touching evaluation
       
        SceneManager.LoadScene("Evaluate", LoadSceneMode.Additive);  // touching evaluation
    }
    private void OnPreSetBtnClick()
    {
        SceneManager.LoadScene("PreSet",LoadSceneMode.Additive);  // touching pre setting
    }



	void OnClickUpgrade()
	{
		UpgradePanelManager.gameObject.SetActive(true);
		MainPanel.gameObject.SetActive(false);
	}

    private void OnDestroy()
    {
        DynaLinkCore.StopSocket();
        Thread.Sleep(100);
    }

}
