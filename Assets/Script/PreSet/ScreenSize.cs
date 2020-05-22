using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenSize : MonoBehaviour {

    public static Vector2 screenSize;


    //public static float[] M2_AXIS_X = new float[] { -0.022f, 0.552f };
    //public static float[] M2_AXIS_Y = new float[] { -0.02f, 0.434f }; // 公司

    public static float[] M2_AXIS_X = new float[] { -0.001f, 0.572f };
    public static float[] M2_AXIS_Y = new float[] { -0.001f, 0.449f }; // 瑞金

    public static float M2_SIZE_X;
    public static float M2_SIZE_Y;
    public static float SCREEN_MID_X;
    public static float SCREEN_MID_Y;

    public static float xScreenOffset;
    public static float yScreenOffset;

    public static void ScreenSet()
    {
        screenSize = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        print(screenSize);
        M2_SIZE_X = (M2_AXIS_X[1] - M2_AXIS_X[0]) / 2;
        M2_SIZE_Y = (M2_AXIS_Y[1] - M2_AXIS_Y[0]) / 2;
        SCREEN_MID_X = (M2_AXIS_X[1] + M2_AXIS_X[0]) / 2;
        SCREEN_MID_Y = (M2_AXIS_Y[1] + M2_AXIS_Y[0]) / 2;
        xScreenOffset = (screenSize.x) / M2_SIZE_X;
        yScreenOffset = (screenSize.y) / M2_SIZE_Y;
    }
}
    
