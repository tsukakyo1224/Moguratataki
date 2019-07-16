using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public static float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = 10.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0 && GameManager.GameEndFlag== false && GameManager.GamestartFlag == true)
        {
            timer -= Time.deltaTime;    //
            GameObject.Find("Mogura_Time").GetComponent<TextMesh>().text = timer.ToString("F2");
            GameObject.Find("Hammer_Time").GetComponent<Text>().text = timer.ToString("F2");
            if (timer <= 0)
            {
                GameManager.MoguraWin();
            }
        }
    }
}
