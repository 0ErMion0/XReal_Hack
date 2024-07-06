using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMng : MonoBehaviour
{
    public static ScoreMng main;

    public int score = 0;

    public ScoreMng Main()
    {
        if (main == null)
        {
            main = new ScoreMng();
        }
        return main;
    }

    public void addScore(int getScore)
    {
        score += getScore;
    }
}
