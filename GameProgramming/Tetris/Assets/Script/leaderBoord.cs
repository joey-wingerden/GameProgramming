using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class leaderBoord : MonoBehaviour
{
    // Start is called before the first frame update
    public Text Textbox;

    private Dictionary<string, List<leaderBoordScore>> leaderBoords = new Dictionary<string, List<leaderBoordScore>>();

    void Start()
    {
        leaderBoords.Add("Heigt", GetLeaderBoord("Heigt"));
        leaderBoords.Add("BlockPlaced", GetLeaderBoord("BlockPlaced"));
        ClearLeaderboord("BlockPlaced");
        ClearLeaderboord("Heigt");
        SetLeaderBoord();

    }

    private List<leaderBoordScore> GetLeaderBoord(string leaderBoordName)
    {
        var LS = new List<leaderBoordScore>();
        for(int i = 1; i <= 5; i++)
        {
           LS.Add(new leaderBoordScore(leaderBoordName, i)); 
        }
        return LS;
    }
    private void SetLeaderBoord()
    {
        string leaderBoord = "";

        leaderBoord += "Heigt \n";
        leaderBoords["Heigt"].ForEach(A => leaderBoord += A.GetString());

        leaderBoord += "BlockPlaced \n";
        leaderBoords["BlockPlaced"].ForEach(A => leaderBoord += A.GetString());
        Textbox.text = leaderBoord;
    }
    public void updateLeaderboord(string leaderBoordName, int score, string name)
    {
        foreach (var LBScore in leaderBoords[leaderBoordName])
        {
            if(score > LBScore.Score)
            {
                var OldName = LBScore.Name;
                var OldScore = LBScore.Score;

                LBScore.UpdateScore(score, name);
                SetLeaderBoord();

                updateLeaderboord(leaderBoordName, OldScore, OldName);
                return;
            }
        }
    }
    public void ClearLeaderboord(string leaderBoordName)
    {
        foreach (var LBScore in leaderBoords[leaderBoordName])
        {
                LBScore.UpdateScore(0, "");
                SetLeaderBoord();            
        }
        SetLeaderBoord();
    }
    private class leaderBoordScore
    {
        public string LeaderBoordName {get; private set;}
        public int Place {get; private set;}
        public int Score {get; private set;}
        public string Name {get; private set;}

        public leaderBoordScore(string leaderBoordName, int place)
        {
            LeaderBoordName = leaderBoordName;
            Place = place;
            LoadPrefs();
        }
        public void UpdateScore(int score, string name)
        {
            Score = score;
            Name = name;
            SaveData();
        }

        private void SaveData()
        {
            PlayerPrefs.SetString("LeaderBoord_"+LeaderBoordName+"_"+Place+"_Name", Name);
            PlayerPrefs.SetInt("LeaderBoord_"+LeaderBoordName+"_"+Place+"_Score", Score);
            PlayerPrefs.Save();
        }
        
        private void LoadPrefs()
        {
            Name = PlayerPrefs.GetString("LeaderBoord_"+LeaderBoordName+"_"+Place+"_Name", "");
            Score = PlayerPrefs.GetInt("LeaderBoord_"+LeaderBoordName+"_"+Place+"_Score", 0);
        }

        public string GetString()
        {
            return Place + ". " + Score + "  " + Name + "\n";
        }
    }
}

