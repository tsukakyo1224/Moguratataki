using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{


    //プレイヤー1はハンマー
    //プレイヤー2はモグラ

    public static GameObject Mogura_WinText;
    public static GameObject Hammer_WinText;

    public static bool GamestartFlag;
    public static bool GameEndFlag;
    public static bool MoguraFlag;


    // Start is called before the first frame update
    void Start()
    {
        //勝敗テキストをお互い非表示に設定
        Mogura_WinText = GameObject.Find("Mogura_Win");
        Mogura_WinText.SetActive(false);
        //ゲームエンドフラグをfalseに設定
        GamestartFlag = false;
        GameEndFlag = false;
        MoguraFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //モグラの勝ち
    public static void MoguraWin()
    {
        //ゲーム終了フラグをtrue
        GameEndFlag = true;
        Debug.Log("モグラの勝ち");
        Mogura_WinText.GetComponent<TextMesh>().text = "You Win";
        //Hammer_WinText.GetComponent<Text>().text = "You Lose";
        Mogura_WinText.SetActive(true);
        //Hammer_WinText.SetActive(true);

    }

    //ハンマーの勝ち
    public static void HammerWin()
    {
        //ゲーム終了フラグをtrue
        GameEndFlag = true;
        Debug.Log("ハンマーの勝ち");
        Mogura_WinText.GetComponent<TextMesh>().text = "You Lose";
        Mogura_WinText.SetActive(true);

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
