﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonCol : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Main()
    {
        Debug.Log("Start Button is pressed");
        SceneManager.LoadScene("SampleScene");
    }

    public void Title()
    {
        Debug.Log("Start Button is pressed");
        SceneManager.LoadScene("Title");
    }

}
