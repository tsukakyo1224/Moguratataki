﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class MoguraControl : MonoBehaviour
{

    public static GameObject Camera;
    public static GameObject RightContoroller;
    public static GameObject LeftContoroller;
    public GameObject CameraRig;

    public GameObject Mogura;
    public static Vector3 mogura_pos;
    private float heikin;

    public SteamVR_Input_Sources rightHand;
    public SteamVR_Input_Sources leftHand;
    public SteamVR_Action_Boolean triggerAction;



    // Start is called before the first frame update
    void Start()
    {

        CameraRig = GameObject.Find("[CameraRig]");
        Camera = GameObject.Find("Camera");
        RightContoroller = GameObject.Find("Controller (right)");
        LeftContoroller = GameObject.Find("Controller (left)");
        Mogura = GameObject.Find("Mogura");
        mogura_pos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(PhotonNetwork.playerList.Length==2)
        //if (PhotonNetwork.player.ID == 2)
        {
            if (GameManager.GameEndFlag == false)
            {
                //モグラの位置が地面に入ったらゲームスタート

                heikin = ((RightContoroller.transform.localPosition.y + LeftContoroller.transform.localPosition.y) / 2.0f) * 3.0f;
                heikin = Camera.transform.localPosition.y - heikin;
                //Debug.Log(heikin);

                if (this.transform.position.y < -2.0f)
                {
                    GameManager.GamestartFlag = true;
                }

                //モグラが顔を出したらモグラフラグをtrue
                if (this.transform.position.y > -0.5 && GameManager.GamestartFlag == true)
                {
                    GameManager.MoguraFlag = true;
                }

                //モグラフラグがtrueの状態で
                if (GameManager.MoguraFlag == true)
                {
                    //地面に潜ったらモグラの勝ち
                    if (this.transform.position.y < -2.0f)
                    {
                        GameManager.MoguraWin();
                    }
                }
            }



            //トリガーによってモグラの位置変更
            if (triggerAction.GetState(leftHand))
            {
                Mogura.transform.position = new Vector3(1.5f, heikin + 0.5f, 1.5f);
            }
            else if (triggerAction.GetState(rightHand))
            {
                Mogura.transform.position = new Vector3(-1.5f, heikin + 0.5f, 1.5f);
            }
            else
            {
                Mogura.transform.position = new Vector3(0.0f, heikin + 0.5f, 0.0f);
            }
            CameraRig.transform.position = Mogura.transform.position;
        }

    }
}
