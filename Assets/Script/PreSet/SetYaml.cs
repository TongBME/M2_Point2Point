using UnityEngine;
using System;
using UnityEditor;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using YamlDotNet.Serialization;

public class SetYaml : MonoBehaviour
{
    public static List<string> taskNames;
    public static int trialNum;
    public static int touchTimeSet;
    public static int breakTimeSet;
    public static int[] sequence;
    public static string subjectName;

    public static Dictionary<string,float[]> startPointDic = new Dictionary<string, float[]>();
    public static Dictionary<string, float[]> endPointDic = new Dictionary<string, float[]>();

    internal class ShoulderTouch
    {
        public string experimentName { get; set; }
        public string dateTime { get; set; }
        public string subject { get; set; }
        public List<string> taskName { get; set; }
        public int trialNumbers { get; set; }
        public int touchTime { get; set; }
        public int breakTime { get; set; }
        public List<string> startPoint { get; set; }
        public List<string> endPoint { get; set; }
    }

    public static void IniTaskInfo(string subName,List<string> startPointArr, List<string> endPointArr)
    {
        // set task key imfo in .yaml
        var subjectData = new ShoulderTouch
        {
            experimentName = "shoulder touching test",
            dateTime = DateTime.Now.ToString("yyyy-MM-dd"),
            subject = subName,
            taskName = new List<string>()
            {
                "Abduction","Aduction","Reach","ReachAduc"
            },
            trialNumbers = 10,
            touchTime = 3,
            breakTime = 3,
            startPoint = startPointArr,
            endPoint = endPointArr,
        };
        
        // serialization process
        var serializer = new Serializer();
        var fittsYaml = serializer.Serialize(subjectData);
        Debug.LogFormat("new serialization was created in .yaml file:\n{0}", fittsYaml);
        // save .yaml

        //create new folder
        string currPath = System.Environment.CurrentDirectory + "\\" + GlobalVar.expFolderName + "\\";
        print(currPath);
        string subjectPath = currPath + subName + "\\";
        if (false == System.IO.Directory.Exists(subjectPath))
        {
            System.IO.Directory.CreateDirectory(subjectPath);
        }
        else
        {
            subjectPath = currPath; // create new folder fail, use current folder path
        }

        //save .yaml file
        string TextName = currPath + GlobalVar.YAMLNAME + ".yaml";
        print(TextName);
        using (TextWriter writer = File.CreateText(TextName))
        {
            writer.Write(fittsYaml.ToString());
        }
    }

    // load .yaml file
    public static void LoadTaskInfo()
    {
        string yamlName = System.Environment.CurrentDirectory + "\\" + GlobalVar.expFolderName  + "\\" + GlobalVar.YAMLNAME +".yaml";
        string content = File.ReadAllText(yamlName);
        var input = new StringReader(content);
        var deserializer = new DeserializerBuilder().Build();
        var yamlObject = deserializer.Deserialize<ShoulderTouch>(input);

        List<string> startPos;
        List<string> endPos;

    // experiment info
        subjectName = yamlObject.subject;
        taskNames = yamlObject.taskName;
        trialNum = yamlObject.trialNumbers;
        touchTimeSet = yamlObject.touchTime;
        breakTimeSet = yamlObject.breakTime;
        startPos = yamlObject.startPoint;
        endPos = yamlObject.endPoint;

        // decompose startPos and endpoint
        for (int i = 0; i < startPos.Count; i++)
        {
            string[] startArr = startPos[i].Split(new Char[] { ',' });
            string[] endArr = endPos[i].Split(new Char[] { ',' });
            float[] pointStartArr = new float[2];
            float[] pointEndArr = new float[2];
            for (int j = 0; j < startArr.Length; j++)
            {
                pointStartArr[j] = Convert.ToSingle(startArr[j]);
                pointEndArr[j] = Convert.ToSingle(endArr[j]);
            }
            startPointDic.Add(taskNames[i], pointStartArr);
            endPointDic.Add(taskNames[i], pointEndArr);
        }
        //Debug.Log("读取成功");
    }
}
