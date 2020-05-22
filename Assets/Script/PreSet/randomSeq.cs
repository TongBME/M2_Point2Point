using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class randomSeq : MonoBehaviour {

    public static int[] GetRandomNum(int[] num)
    {
        for (int i = 0; i < num.Length; i++)
        {
            int temp = num[i];
            int randomIndex = Random.Range(0, num.Length);
            num[i] = num[randomIndex];
            num[randomIndex] = temp;
        }
        return num;
    }

}
