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
        //z軸が320度未満または、20度以上で、ハンマー叩く
        if (transform.localEulerAngles.z > 320 ||
            transform.localEulerAngles.z < 20)
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
            //z軸が330度未満または、30度以上で、ハンマー戻す
            if (transform.localEulerAngles.z > 330 ||
            transform.localEulerAngles.z < 30)
            {
                transform.Rotate(0, 0, -5);
            }
        }
    }

    private void OnTriggerEnter(Collider hit)
    {
        if (hit.CompareTag("mogura"))
        {
            MoguraCol.Score++;
            Debug.Log(MoguraCol.Score);
        }
    }

}
