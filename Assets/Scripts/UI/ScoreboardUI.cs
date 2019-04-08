using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreboardUI : MonoBehaviour
{

    GameManagerData data;
    [SerializeField] Text Score;
    [SerializeField] Text Multiplier;
    [SerializeField] Text Destruction;
    [SerializeField] Text Time;
    [SerializeField] Text Bonus;
    [SerializeField] Text Items;

    void Start()
    {
        data = GameManagerData._GameManagerData;
    }


    public void SetupScoreBoard()
    {
        Score.text = data.score.ToString();
        Multiplier.text = data.GetMultiplier().ToString();
        Destruction.text = data.GetDestruction().ToString();
        Time.text = data.GetTime();
        Items.text = data.itemsCollected.ToString() + "/" + data.itemsSpawned.ToString();

    }


}
