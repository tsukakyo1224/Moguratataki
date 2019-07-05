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
        Vector3 mogurapos = new Vector3(-6f, 2f, 0f);

        if (NetWork_01.startflag == true && PhotonNetwork.playerList.Length == 1)
        {
            GameObject obj = PhotonNetwork.Instantiate
                ("test", pos, Quaternion.identity, 0);
            NetWork_01.startflag = false;
        }
        GameObject.Find("test(Clone)").transform.parent = GameObject.Find("[CameraRig]").transform;
    }
}
