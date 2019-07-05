using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCol : MonoBehaviour
{

    public Camera camera_object; //カメラを取得
    private RaycastHit hit; //レイキャストが当たったものを取得する入れ物

    //スコア
    public static int Score;
    //スコアテキスト
    public GameObject ScoreText;
    public Vector3 moguraV;

    //モグラたち
    //public GameObject mogura1;
    public GameObject mogura2;
    public GameObject mogura3;
    public GameObject mogura4;
    public GameObject mogura5;
    public GameObject mogura6;
    public GameObject mogura7;
    public GameObject mogura8;

    // Start is called before the first frame update
    void Start()
    {
        
        Score = 0;
        ScoreText = GameObject.Find("Score");
        //mogura1 = GameObject.Find("Mogura (1)");
        mogura2 = GameObject.Find("Mogura (2)");
        mogura3 = GameObject.Find("Mogura (3)");
        mogura4 = GameObject.Find("Mogura (4)");
        mogura5 = GameObject.Find("Mogura (5)");
        mogura6 = GameObject.Find("Mogura (6)");
        mogura7 = GameObject.Find("Mogura (7)");
        mogura8 = GameObject.Find("Mogura (8)");
        //moguraV = GameObject.Find("Mogura (1)").transform.position;    //プレイヤー座標所得
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        // マウスの左クリックを押している間
        if (Input.GetMouseButton(0))
        {
            Ray ray = camera_object.ScreenPointToRay(Input.mousePosition); //マウスのポジションを取得してRayに代入

            if (Physics.Raycast(ray, out hit))  //マウスのポジションからRayを投げて何かに当たったらhitに入れる
            {
                if(hit.collider.gameObject.tag == "mogura")
                {
                    string objectName = hit.collider.gameObject.name; //オブジェクト名を取得して変数に入れる
                    //Debug.Log(objectName); //オブジェクト名をコンソールに表示
                    Destroy(hit.collider.gameObject);
                    Score++;

                }
            }
        }
        */
        ScoreText.GetComponent<Text>().text = "Score:" + Score;
        //mogura1.transform.position.y += 0.05f;
    }
}
