﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Leaderboard : MonoBehaviour
{
    [SerializeField]
    private GameObject[] entries;

    public Transform leaderboardBody;

    void Start()
    {
        List<Highscore> highscores = LeaderboardData.LoadScores();

        entries = new GameObject[10];
        for (int i = 0; i < 10; i++)
        {
            Transform entry = leaderboardBody.GetChild(i);
            entry.GetChild(0).GetComponent<Text>().text = highscores[i].name;
            entry.GetChild(1).GetComponent<Text>().text = highscores[i].score.ToString();
        }
    }
}
