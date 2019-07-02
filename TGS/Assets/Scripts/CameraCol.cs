using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCol : MonoBehaviour
{

    public GameObject targetObj;
    public Vector3 targetPos;



    void Start()
    {

        targetObj = GameObject.Find("Main Camera");
        targetPos = targetObj.transform.position;
    }

    void Update()
    {
        
        // targetの移動量分、自分（カメラ）も移動する
        targetPos = targetObj.transform.position;
        transform.position += targetObj.transform.position - targetPos;
        //矢印を押したぶんカメラを回す
        transform.RotateAround(targetPos, Vector3.up, (Input.GetAxis("Horizontal")) * Time.deltaTime * 200f);
        

    }
}