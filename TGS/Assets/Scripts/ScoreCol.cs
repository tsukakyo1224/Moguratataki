using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCol : MonoBehaviour
{

    //スコア
    public static int Score;
    //スコアテキスト
    public GameObject ScoreText;

    // Start is called before the first frame update
    void Start()
    {
        
        Score = 0;
        ScoreText = GameObject.Find("Score");
        
    }

    // Update is called once per frame
    void Update()
    {
        
        ScoreText.GetComponent<Text>().text = "Score:" + Score;
    }
}
