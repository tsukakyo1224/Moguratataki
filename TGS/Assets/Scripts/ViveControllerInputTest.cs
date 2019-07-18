using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;


public class ViveControllerInputTest : MonoBehaviour
{

    public SteamVR_Input_Sources hand;
    public SteamVR_Action_Boolean triggerAction;

    void Awake()
    {
        
    }

    void Update()
    {

        if (triggerAction.GetState(hand))
        {
            //Debug.Log("aa");
        }

    }
}