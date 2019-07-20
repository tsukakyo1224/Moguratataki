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

    //
    public GameObject Mogura;
    public static Vector3 mogura_pos;
    private float heikin;

    public GameObject Hammer;

    //VIVEコントローラー用関数
    public SteamVR_Input_Sources rightHand;
    public SteamVR_Input_Sources leftHand;
    public SteamVR_Input_Sources Hand;
    public SteamVR_Action_Boolean triggerAction;
    public SteamVR_Action_Boolean Teleport;

    //音楽
    private AudioSource audioSource1;
    private AudioSource audioSource2;
    private AudioSource audioSource3;
    public AudioClip mogura_come_music;
    public AudioClip mogura_go_music;
    public AudioClip Bomb;
    public bool audioFlag = false;

    //エフェクト
    [SerializeField] private GameObject effectObject;
    //　エフェクトを消す秒数
    [SerializeField] private float deleteTime;
    //　エフェクトの出現位置のオフセット値
    [SerializeField] private float offset;


    // Start is called before the first frame update
    void Start()
    {

        CameraRig = GameObject.Find("[CameraRig]");
        Camera = GameObject.Find("Camera");
        RightContoroller = GameObject.Find("Controller (right)");
        LeftContoroller = GameObject.Find("Controller (left)");
        Mogura = GameObject.Find("Mogura(Clone)");
        mogura_pos = this.transform.position;

        Hammer = GameObject.Find("H(Clone)");

        MyPhotonView = PhotonView.Get(this);
        photonTransformView = GetComponent<PhotonTransformView>();

        audioSource1 = gameObject.GetComponent<AudioSource>();
        audioSource2 = gameObject.GetComponent<AudioSource>();
        audioSource3 = gameObject.GetComponent<AudioSource>();
        audioSource1.clip = mogura_come_music;
        audioSource2.clip = mogura_go_music;
        audioSource3.clip = Bomb;



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
            if (PhotonNetwork.player.ID == 2 && GameManager.GameEndFlag== false)
            {
                GameManager.WinText.GetComponent<TextMesh>().text = "ハンマーをなぐれ！！";
                if (audioFlag == false)
                {
                    audioSource1.Play();
                    audioFlag = true;
                }

            }
        }

        //モグラフラグがtrueの状態で
        if (GameManager.MoguraFlag == true && GameManager.GameEndFlag == false)
        {

            if (Teleport.GetState(Hand) || Input.GetKey(KeyCode.V))
            {
                //Debug.Log("aa");
                var instantiateEffect = GameObject.Instantiate(effectObject, 
                    transform.position + new Vector3(Hammer.transform.position.x, Hammer.transform.position.y, Hammer.transform.position.z), 
                    Quaternion.identity) as GameObject;
                audioSource3.Play();
                GameObject.Find("WinFlag").GetComponent<PhotonView>().TransferOwnership(PhotonNetwork.player.ID);
                WinCol.P2_Win = true;
                GameManager.MoguraWin();
            }
            /*
            //地面に潜ったらモグラの勝ち
            if (this.transform.position.y < -2.0f)
            {
                GameManager.MoguraWin();
                audioSource2.Play();

            }*/

        }

        if (PhotonNetwork.player.ID == 2 && MyPhotonView.isMine)
        {
            heikin = ((RightContoroller.transform.localPosition.y + LeftContoroller.transform.localPosition.y) / 2.0f) * 3.0f;
            heikin = Camera.transform.localPosition.y - heikin;
                
            //トリガーによってモグラの位置変更
            if (triggerAction.GetStateDown(leftHand))
            {
                Mogura.transform.position = new Vector3(2f, heikin + 0.5f, 2f);
            }
            else if (triggerAction.GetStateDown(rightHand))
            {
                Mogura.transform.position = new Vector3(-2f, heikin + 0.5f, 2f);
            }
            else if(triggerAction.GetStateDown(leftHand) && triggerAction.GetStateDown(rightHand))
            {
                Mogura.transform.position = new Vector3(0.0f, heikin + 0.5f, 0.0f);
            }
            CameraRig.transform.position = Mogura.transform.position;
        }

    }
}
