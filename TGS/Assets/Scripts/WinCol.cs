using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCol : MonoBehaviour
{
    [SerializeField]
    public static bool P1_Win = false;
    [SerializeField]
    public static bool P2_Win = false;

    [SerializeField]
    public bool p1win;
    [SerializeField]
    public bool p2win;


    // Start is called before the first frame update
    void Start()
    {
        //今の所prayer1が先行
        P1_Win = false;
        P2_Win = false;
    }

    // Update is called once per frame
    void Update()
    {
        //見えるように
        p1win = P1_Win;
        p2win = P2_Win;

        //プレイヤー1の勝利
        if (P1_Win == true)
        {
            GameManager.HammerWin();
        }
        //プレイヤー2の勝利
        else if (P2_Win == true)
        {
            GameManager.MoguraWin();
        }

    }

    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {
            //データの送信
            stream.SendNext(P1_Win);
            stream.SendNext(P2_Win);
        }
        else
        {
            //データの受信
            P1_Win = (bool)stream.ReceiveNext();
            P2_Win = (bool)stream.ReceiveNext();
        }
    }
}
