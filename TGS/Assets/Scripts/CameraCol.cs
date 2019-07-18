using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCol : MonoBehaviour
{


    Quaternion angle;
    Vector3 V3_angle;
    float tmp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PhotonNetwork.player.ID == 1)
        {
            //VIVEコントローラーの角度をハンマーに代入
            angle = this.transform.rotation;
            //Quaternionをオイラー角Vecter3に変換
            V3_angle = angle.eulerAngles;
            V3_angle.y = 180f;

        //ハンマー側
        if (PhotonNetwork.player.ID == 1)
        {

            //VIVEコントローラーの角度をハンマーに代入
            angle = this.transform.rotation;
            //Quaternionをオイラー角Vecter3に変換
            V3_angle = angle.eulerAngles;
            V3_angle.y = 180f;

            angle = Quaternion.Euler(V3_angle);

            this.transform.rotation = angle;
            this.transform.position = new Vector3(0.0f, 1.0f, 3.5f);
            //Debug.Log("aa");
        }
        
    }
}
