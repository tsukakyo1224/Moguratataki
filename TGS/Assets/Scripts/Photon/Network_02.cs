﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Network_02 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 生成位置をランダムな座標にする
        float x = 0f;
        float y = 2f;
        float z = 0f;
        Vector3 pos = new Vector3(x, y, z);

        if (NetWork_01.startflag == true)
        {
            GameObject obj = PhotonNetwork.Instantiate
                ("[CameraRig]", pos, Quaternion.identity, 0);
            NetWork_01.startflag = false;
        }
    }
}
