using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoguraControl : MonoBehaviour
{

    public static GameObject Camera;
    public static GameObject RightContoroller;
    public static GameObject LeftContoroller;
    public GameObject CameraRig;

    public GameObject Mogura;
    public static Vector3 mogura_pos;
    private float heikin;

    // Start is called before the first frame update
    void Start()
    {
        CameraRig = GameObject.Find("[CameraRig]");
        Camera = GameObject.Find("Camera");
        RightContoroller = GameObject.Find("Controller (right)");
        LeftContoroller = GameObject.Find("Controller (left)");
        Mogura = GameObject.Find("Teddy");
        mogura_pos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        heikin = ((RightContoroller.transform.localPosition.y + LeftContoroller.transform.localPosition.y) / 2.0f)*3.0f;
        heikin = Camera.transform.localPosition.y - heikin;
        //Debug.Log((RightContoroller.transform.position.y + LeftContoroller.transform.position.y) / 2.0f);
        
        Debug.Log(heikin);
        Mogura.transform.position = new Vector3(this.transform.position.x, heikin+1.0f, this.transform.position.z);
        CameraRig.transform.position = Mogura.transform.position;


    }
}
