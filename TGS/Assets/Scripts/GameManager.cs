using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{


    //プレイヤー1はハンマー
    //プレイヤー2はモグラ

    public static GameObject WinText;

    public static bool GamestartFlag;
    public static bool GameEndFlag;
    public static bool MoguraFlag;

    //ゲームスタート表示秒数
    private float startTime = 1.0f;


    // Start is called before the first frame update
    void Start()
    {
        //勝敗テキストをお互い非表示に設定
        WinText = GameObject.Find("Mogura_Win");
        
        //ゲームエンドフラグをfalseに設定
        GamestartFlag = false;
        GameEndFlag = false;
        MoguraFlag = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.A))
        {
            Reset();
        }

        if(GamestartFlag == false)
        {
            if (PhotonNetwork.player.ID == 1)
            {
                WinText.GetComponent<TextMesh>().text = "モグラが潜ったらゲームスタート！";
            }
            else if (PhotonNetwork.player.ID == 2)
            {
                WinText.GetComponent<TextMesh>().text = "準備できたら潜ってスタート";
            }
        }


        //メインテキスト表示設定
        if (GamestartFlag == true)
        {
            if (startTime >= 0)
            {
                WinText.GetComponent<TextMesh>().text = "ゲームスタート！！";
                startTime -= Time.deltaTime;
            }
            else
            {
                if (PhotonNetwork.player.ID == 1)
                {
                    WinText.GetComponent<TextMesh>().text = "モグラを叩け！";
                }
                else if (PhotonNetwork.player.ID == 2)
                {
                    WinText.GetComponent<TextMesh>().text = "出ろ！";
                }
            }
        }
    }

    //モグラの勝ち
    public static void MoguraWin()
    {
        //ゲーム終了フラグをtrue
        GameEndFlag = true;
        Debug.Log("モグラの勝ち");
        if (PhotonNetwork.player.ID == 1)
        {
            WinText.GetComponent<TextMesh>().text = "You Lose";
        }
        else if (PhotonNetwork.player.ID == 2)
        {
            WinText.GetComponent<TextMesh>().text = "You Win";
        }

    }

    //ハンマーの勝ち
    public static void HammerWin()
    {
        //ゲーム終了フラグをtrue
        GameEndFlag = true;
        Debug.Log("ハンマーの勝ち");
        if (PhotonNetwork.player.ID == 1)
        {
            WinText.GetComponent<TextMesh>().text = "You Win";
        }
        else if (PhotonNetwork.player.ID == 2)
        {
            WinText.GetComponent<TextMesh>().text = "You Lose";
        }

    }
    
    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {
            stream.SendNext(GameEndFlag);
        }
        else
        {
            GameEndFlag = (bool)stream.ReceiveNext();
        }

    }
    public void Reset()
    {
        Debug.Log("Start Button is pressed");
        SceneManager.LoadScene("SampleScene");
    }

}
