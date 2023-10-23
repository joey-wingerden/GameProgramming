using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetKeybinds: MonoBehaviour
{
    public string changeKey;
    public Text Textbox;

    public void changevalue()
    {
        KeyCode key = SelectButton();
        KeyBinds.ChangeKey(changeKey, key);
        Textbox.text = key.ToString();
    }

    //private KeyCode[] keyCodes = System.Enum.GetValues(typeof(KeyCode)).Tolist();
    private KeyCode SelectButton()
    {
        foreach (KeyCode key in System.Enum.GetValues(typeof(KeyCode)))
        {
            if(Input.GetKeyDown(key))
            {
                return key;
            }
        }
        return KeyCode.None;
    }

}
/*
Text in small amaunt possible
lachen

*/