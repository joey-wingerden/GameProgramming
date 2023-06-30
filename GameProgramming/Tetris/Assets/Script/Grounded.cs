using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : MonoBehaviour
{
    public Game _game;
    public leaderBoord leaderBoord;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Block")
        {
            if(_game.GameRunning)
            {
                _game.GameRunning = false;
                _game.TurnGameOff();

                leaderBoord.updateLeaderboord("Heigt", (int)_game.GetMaxheigt(), "No Name");
                leaderBoord.updateLeaderboord("BlockPlaced", (int)_game.GetTotalBlocks(), "No Name");
                _game.Swapping.GameOverScreen();
                //_game.ResetGame();
            }
            
        }
    }
    
}
