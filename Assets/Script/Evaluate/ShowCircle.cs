using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowCircle : MonoBehaviour {

    // Use this for initialization

    public static GameObject aimObject;
    public static Vector2 screenObjPos;
    public static float[] taskPointValue = new float[2];

    void Start()
    {
        aimObject = GameObject.Find("Canvas/objcircle");

        aimObject.SetActive(false);
    }

    public static void EndPointCircle(int num)
    {
        float offset = 1;// size offset

        //color
        aimObject.GetComponent<SpriteRenderer>().color = Color.grey;
        aimObject.GetComponent<Renderer>().enabled = true; // circle shows
        aimObject.transform.SetAsFirstSibling();
        aimObject.SetActive(true);
        //postion
        
        string taskPointKey = SetYaml.taskNames[num];
        
        SetYaml.endPointDic.TryGetValue(taskPointKey, out taskPointValue);
        //print(taskPointValue[0]);
        //print(taskPointValue[1]);

        float xM2 = (float)(taskPointValue[0] - ScreenSize.SCREEN_MID_X);
        float yM2 = (float)(taskPointValue[1] - ScreenSize.SCREEN_MID_Y);
        float objectX = xM2 * ScreenSize.xScreenOffset;
        float objectY = yM2 * ScreenSize.yScreenOffset;
        Vector2 screenPos = new Vector2(objectX, objectY);

        aimObject.transform.position = screenPos;

        // size
        Vector3 localscale = aimObject.transform.localScale;
        Vector3 localScale = new Vector3(localscale.x * offset, localscale.y * offset, localscale.z * offset);
        aimObject.transform.localScale = localScale;

    }
               
}
