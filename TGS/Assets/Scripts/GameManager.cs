using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        if(PhotonNetwork.player.ID == 1)
        {
            WinText.GetComponent<TextMesh>().text = "モグラが潜ったらゲームスタート！";
        }else if(PhotonNetwork.player.ID == 2)
        {
            WinText.GetComponent<TextMesh>().text = "準備できたら潜ってスタート";
        }
        //ゲームエンドフラグをfalseに設定
        GamestartFlag = false;
        GameEndFlag = false;
        MoguraFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GamestartFlag == true)
        {
            if (startTime >= 0)
            {
                WinText.GetComponent<TextMesh>().text = "ゲームスタート！！";
            }
            else
            {
                if (PhotonNetwork.player.ID == 1)
                {

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
        WinText.GetComponent<TextMesh>().text = "You Win";
        WinText.SetActive(true);

    }

    //ハンマーの勝ち
    public static void HammerWin()
    {
        //ゲーム終了フラグをtrue
        GameEndFlag = true;
        Debug.Log("ハンマーの勝ち");
        WinText.GetComponent<TextMesh>().text = "You Lose";
        WinText.SetActive(true);

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

}
