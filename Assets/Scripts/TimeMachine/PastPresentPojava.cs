using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class PastPresentPojava : NetworkBehaviour
{
    public string targetButton1 = "ButtonPast";
    public string targetButton2 = "ButtonPresent";

    private GameObject buttonPast;
    private GameObject buttonPresent;

    private void Start()
    {
        buttonPast = GameObject.FindGameObjectWithTag(targetButton1);
        buttonPresent = GameObject.FindGameObjectWithTag(targetButton2);


        if (buttonPast == null || buttonPresent == null)
        {
            Debug.LogError("References to drugoSvitlo or treceSvitlo are null.");
        }
    }
}
