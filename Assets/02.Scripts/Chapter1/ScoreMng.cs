using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMng : MonoBehaviour
{
    public static ScoreMng main;

    public int totalScore = 0;
    public int ch1Score = 0;
    public int ch2Score = 0;
    public int ch4Score = 0;
    public int ch5Score = 0;

    private void Awake()
    {
        if (main == null)
        {
            main = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
            Destroy(this.gameObject);
    }

    //public ScoreMng Main()
    //{
    //    if (main == null)
    //    {
    //        main = new ScoreMng();
    //    }
    //    return main;
    //}

    public void addScore(int getScore, string chName)
    {
        totalScore += getScore;

        if(chName == "Chapter1")
        {
            ch1Score += getScore;
        }

        if(chName == "Chapter2")
        {
            ch2Score += getScore;
        }

        if (chName == "Chapter4")
        {
            ch4Score += getScore;
        }
        if (chName == "Chapter5")
        {
            ch5Score += getScore;
        }
    }
}
