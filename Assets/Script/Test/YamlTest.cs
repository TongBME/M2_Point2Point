using UnityEngine;
using UnityEditor;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using YamlDotNet.Serialization;

public class YamlTest : MonoBehaviour
{

    void Start()
    {
        //SetYaml.LoadTaskInfo();
        int [] a = new int[] { 1, 2, 3, 4 };
        int[] b = new int[] { };
        b = GetRandomNum(a);
        print(b);

    }

    public int[] GetRandomNum(int[] num)
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


