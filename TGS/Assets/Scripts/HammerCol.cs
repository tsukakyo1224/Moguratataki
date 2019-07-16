using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerCol : MonoBehaviour
{

    public static bool flag;
    // Start is called before the first frame update
    void Start()
    {
        flag = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Spaceを一回押したら
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //叩くフラグを付ける
            flag = true;
        }
        //ハンマーのz軸の表示
        //Debug.Log(transform.localEulerAngles.z);
        //z軸が320度未満または、40度以上で、ハンマー叩く
        if (transform.localEulerAngles.z > 350 ||
            transform.localEulerAngles.z < 40)
        {
            if (flag == true)
            {
                transform.Rotate(0, 0, 5);
            }
        }
        else
        {
            //ハンマー戻す判定
            flag = false;
        }
        if (flag == false)
        {
            //z軸が330度未満または、0度以上で、ハンマー戻す
            if (transform.localEulerAngles.z >= 360 ||
            transform.localEulerAngles.z < 50)
            {
                transform.Rotate(0, 0, -5);
            }
        }
    }

    void OnTriggerEnter(Collider hit)
    {
        if (hit.CompareTag("mogura") && GameManager.GameEndFlag==false)
        {
            Debug.Log("Win");
            GameManager.HammerWin();

        }
    }

    

}
