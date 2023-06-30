using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LiveScore : MonoBehaviour
{
    // Start is called before the first frame update
    public Text Textbox;

    public Game _game;

    void Update()
    {
        if(_game.GameRunning && !_game.gamePauze)
        {
            
            string Score = "";

            Score += "Heigt: \n";
            Score += _game.GetMaxheigt();
            Score += "\nBlockPlaced \n";
            Score += _game.GetTotalBlocks();

            Textbox.text = Score;
        }
        
    }

    
    
    
    
}

