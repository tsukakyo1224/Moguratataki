using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerCol : MonoBehaviour
{
    public static GameObject RightContoroller;
    Quaternion angle;
    Vector3 V3_angle;
    Vector3 V3_localAngle;
    float tmp;
    // Start is called before the first frame update
    void Start()
    {
        
        RightContoroller = GameObject.Find("Controller (right)");
    }

    // Update is called once per frame
    void Update()
    {

        V3_localAngle = new Vector3(0f, 90f, 0f);
        //VIVEコントローラーの位置をハンマーに代入
        this.transform.position = RightContoroller.transform.position;

        
        //VIVEコントローラーの角度をハンマーに代入
        angle = RightContoroller.transform.rotation;
        //Quaternionをオイラー角Vecter3に変換
        V3_angle = angle.eulerAngles;
        /*
        V3_angle.x += 90f;
        V3_angle.y += 0f;
        V3_angle.z += 0f;*/
        //tmp = V3_angle.x;
        //V3_angle.x = -V3_angle.z;
        //V3_angle.z = tmp;

        //オイラー角Vecter3をQuaternionに変換(戻す)
        //angle = Quaternion.AngleAxis(90, -Vector3.forward);
        angle = Quaternion.Euler(V3_angle);

        this.transform.rotation = angle;
    }
}
