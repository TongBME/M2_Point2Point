using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FFTAICommunicationLib;
using System.IO;
using System.Text;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class MoveObject : MonoBehaviour
{
    public static GameObject objPoint;
    public static Vector2 screenPos;
    private Vector2 screenSize;

    void Start()
    {
        objPoint = GameObject.Find("Canvas/hand");
        objPoint.transform.position = new Vector2(0.0f, 0.0f);
        objPoint.GetComponent<SpriteRenderer>().color = Color.green;
        objPoint.SetActive(true);
        screenSize = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));// 屏幕尺寸
    }

    void Update()
    {
        float xM2 = (float)(DynaLinkHS.StatusRobot.PositionDataJoint1 - ScreenSize.SCREEN_MID_X);
        float yM2 = (float)(DynaLinkHS.StatusRobot.PositionDataJoint2 - ScreenSize.SCREEN_MID_Y);
        float objectX = xM2 * ScreenSize.xScreenOffset;
        float objectY = yM2 * ScreenSize.yScreenOffset;
        screenPos = new Vector2(objectX, objectY);
        objPoint.transform.position = screenPos;


        //print(DynaLinkHS.StatusRobot.PositionDataJoint1);
        //print(DynaLinkHS.StatusRobot.PositionDataJoint2);

        /*  mouse control
        Vector2 mousePos = Input.mousePosition; //mouse X and Y
        screenPos = Camera.main.WorldToScreenPoint(objPoint.transform.position);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        objPoint.transform.position = worldPos;
        objPoint.transform.position = new Vector2(Mathf.Clamp(transform.position.x, -screenSize.x, screenSize.x), Mathf.Clamp(transform.position.y, -screenSize.y, screenSize.y));
        //print(objPoint.transform.position);
        //System.Type t = (objPoint.transform.position.x).GetType();
        //print(t);
        */
    }
}
