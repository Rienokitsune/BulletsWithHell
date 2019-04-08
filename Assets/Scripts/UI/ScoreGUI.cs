using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreGUI : MonoBehaviour
{
    [SerializeField] public Text text;
    [SerializeField] public GameManagerData data;

    private void Start()
    {
        UpdateScore();
    }

    

    public void UpdateScore()
    {
        text.text = data.score.ToString();
    }

}
