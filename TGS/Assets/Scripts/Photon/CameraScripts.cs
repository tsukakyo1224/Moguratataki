using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScripts : MonoBehaviour
{
    private PhotonView photonView;
    private PhotonTransformView photonTransformView;

    // Use this for initialization
    void Start()
    {
        photonTransformView = GetComponent<PhotonTransformView>();
        photonView = PhotonView.Get(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.isMine)
        {
            //現在の移動速度
            Vector3 velocity = gameObject.GetComponent<Rigidbody>().velocity;
            //移動速度を指定
            photonTransformView.SetSynchronizedValues(velocity, 0);
        }
    }
}
