using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVar : MonoBehaviour {

    //file setting
    public static string CSVNAME;
    public static string expFolderName;
    public static string YAMLNAME;
    public static string sEMGCSVNAME;
    private void Start()
    {
        CSVNAME = "Trajectory"; // save .CSV file
        sEMGCSVNAME = "sEMG";
        expFolderName = "ReachingExp";
        YAMLNAME = "TouchingExp";// load .yaml file
    }
    

}
