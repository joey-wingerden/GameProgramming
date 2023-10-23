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

    private static KeyCode leftkey = KeyCode.A;
    private static KeyCode Richtkey = KeyCode.D;
    private static KeyCode Downkey = KeyCode.S;

    private static KeyCode rotateLkey = KeyCode.Q;
    private static KeyCode rotateRkey = KeyCode.E;

    private static KeyCode Pauzekey = KeyCode.Escape;
    private static KeyCode Resetkey = KeyCode.R;
    public static string PlayerName;

    private  Text leftText;
    private  Text RichtText;
    private  Text DownText;

    private  Text rotateLText;
    private  Text rotateRText;

    private  Text PauzeText;
    private  Text ResetText;

    private Text PlayerNameText;

    public void LeftChangeKey(KeyCode changevalue)
    {
        leftkey = changevalue;
    }
    public void RichtChangeKey(KeyCode changevalue)
    {
        Richtkey = changevalue;
    }
    public void DownChangeKey(KeyCode changevalue)
    {
        Downkey = changevalue;
    }
    public void RotateLChangeKey(KeyCode changevalue)
    {
        rotateLkey = changevalue;
    }
    public void RotateQChangeKey(KeyCode changevalue)
    {
        rotateRkey = changevalue;
    }
    public void PauzeChangeKey(KeyCode changevalue)
    {
        Pauzekey = changevalue;
    }
    public void ResetChangeKey(KeyCode changevalue)
    {
        Resetkey = changevalue;
    }
    public void SetPlayerName(string changevalue)
    {
        PlayerName = changevalue;
    }

    public static void ChangeKey(string ChangeItem, KeyCode changevalue)
    {
        switch (ChangeItem)
        {
            case "leftkey":     leftkey = changevalue;      break;
            case "Richtkey":    Richtkey = changevalue;     break;
            case "Downkey":     Downkey = changevalue;      break;
            case "rotateLkey":  rotateLkey = changevalue;   break;
            case "rotateRkey":  rotateRkey = changevalue;   break;
            case "Pauzekey":    Pauzekey = changevalue;     break;
            case "Resetkey":    Resetkey = changevalue;     break;
        }
    }
    
}
