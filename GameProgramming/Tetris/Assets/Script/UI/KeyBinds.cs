using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyBinds : MonoBehaviour
{
    public static bool left {get{return Input.GetKeyDown(leftkey);}}
    public static bool Richt {get{return Input.GetKeyDown(Richtkey);}}
    public static bool Down {get{return Input.GetKeyDown(Downkey);}}

    public static bool rotateL {get{return Input.GetKeyDown(rotateLkey);}}
    public static bool rotateR {get{return Input.GetKeyDown(rotateRkey);}}

    public static bool Pauze {get{return Input.GetKeyDown(Pauzekey);}}
    public static bool Reset {get{return Input.GetKeyDown(Resetkey);}}

    private static string leftkey = "A";
    private static string Richtkey = "D";
    private static string Downkey = "S";

    private static string rotateLkey = "Q";
    private static string rotateRkey = "E";

    private static string Pauzekey = "ESQ";
    private static string Resetkey = "R";

    private  Text leftText;
    private  Text RichtText;
    private  Text DownText;

    private  Text rotateLText;
    private  Text rotateRText;

    private  Text PauzeText;
    private  Text ResetText;

    public void LeftChangeKey(string changevalue)
    {
        leftkey = changevalue;
    }
    public void RichtChangeKey(string changevalue)
    {
        Richtkey = changevalue;
    }
    public void DownChangeKey(string changevalue)
    {
        Downkey = changevalue;
    }
    public void RotateLChangeKey(string changevalue)
    {
        rotateLkey = changevalue;
    }
    public void RotateQChangeKey(string changevalue)
    {
        rotateRkey = changevalue;
    }
    public void PauzeChangeKey(string changevalue)
    {
        Pauzekey = changevalue;
    }
    public void ResetChangeKey(string changevalue)
    {
        Resetkey = changevalue;
    }
    
    
}
