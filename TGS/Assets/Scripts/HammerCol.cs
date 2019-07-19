using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class HammerCol : MonoBehaviour
{

    public static bool flag;
    public static bool HammerFlag;

    Vector3 a;
    float acceleration;


    // Start is called before the first frame update
    void Start()
    {
        flag = false;
        HammerFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        VelocityEstimator VE = GetComponent<VelocityEstimator>();
        //a = VE.GetAccelerationEstimate();
        Debug.Log(VE.GetAccelerationEstimate());
        //Spaceを一回押したら
        if (Input.GetKeyDown(KeyCode.Space) && HammerFlag == false && GameManager.GamestartFlag == true)
        {
            //叩くフラグを付ける
            flag = true;
            HammerFlag = true;
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
        if (hit.CompareTag("mogura") && GameManager.GameEndFlag==false && GameManager.GamestartFlag == true)
        {

            
            Debug.Log("Win");
            GameManager.HammerWin();
        }
    }

    

}
