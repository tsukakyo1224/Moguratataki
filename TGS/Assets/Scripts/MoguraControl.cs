using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class MoguraControl : MonoBehaviour
{

    private PhotonView MyPhotonView;
    private PhotonTransformView photonTransformView;

    public static GameObject Camera;
    public static GameObject RightContoroller;
    public static GameObject LeftContoroller;
    public GameObject CameraRig;

    public GameObject Mogura;
    public static Vector3 mogura_pos;
    private float heikin;

    public SteamVR_Input_Sources rightHand;
    public SteamVR_Input_Sources leftHand;
    public SteamVR_Input_Sources Hand;
    public SteamVR_Action_Boolean triggerAction;
    public SteamVR_Action_Boolean Teleport;



    // Start is called before the first frame update
    void Start()
    {

        CameraRig = GameObject.Find("[CameraRig]");
        Camera = GameObject.Find("Camera");
        RightContoroller = GameObject.Find("Controller (right)");
        LeftContoroller = GameObject.Find("Controller (left)");
        Mogura = GameObject.Find("Mogura(Clone)");
        mogura_pos = this.transform.position;

        MyPhotonView = PhotonView.Get(this);
        photonTransformView = GetComponent<PhotonTransformView>();

    }

    // Update is called once per frame
    void Update()
    {

        //モグラの位置が地面に入ったらゲームスタート
        if (this.transform.position.y < -2.0f)
        {
            GameManager.GamestartFlag = true;
        }

        //モグラが顔を出したらモグラフラグをtrue
        if (this.transform.position.y > -0.5 && GameManager.GamestartFlag == true)
        {
            GameManager.MoguraFlag = true;
            if (PhotonNetwork.player.ID == 2)
            {
                GameManager.WinText.GetComponent<TextMesh>().text = "ハンマーをなぐれ！！";
            }
        }

        //モグラフラグがtrueの状態で
        if (GameManager.MoguraFlag == true)
        {

            if (Teleport.GetState(Hand))
            {
                Debug.Log("aa");
            }


            //地面に潜ったらモグラの勝ち
            if (this.transform.position.y < -2.0f)
            {
                GameManager.MoguraWin();
            }


        }

        //if(PhotonNetwork.playerList.Length==2)
        if (PhotonNetwork.player.ID == 2 && MyPhotonView.isMine)
        {
            //if (GameManager.GameEndFlag == false)
            //{
                heikin = ((RightContoroller.transform.localPosition.y + LeftContoroller.transform.localPosition.y) / 2.0f) * 3.0f;
                heikin = Camera.transform.localPosition.y - heikin;
                //Debug.Log(heikin);
            //}

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
