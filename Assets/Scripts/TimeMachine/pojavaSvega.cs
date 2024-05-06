using Mirror;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class pojavaSvega : NetworkBehaviour
{
    private GameObject text;
    public string textTag = "Text";
    public string targetText = "aztec";

    public string targetLampa1 = "Lampa1";
    public string targetLampa2 = "Lampa2";
    public string targetLampa3 = "Lampa3";

    private GameObject lampa1;
    private GameObject lampa2;
    private GameObject lampa3;

    public string targetButton1 = "Button1";
    public string targetButton2 = "Button2";

    private GameObject button1;
    private GameObject button2;

    private void Start()
    {
        text = GameObject.FindGameObjectWithTag(textTag);
        lampa1 = GameObject.FindGameObjectWithTag(targetLampa1);
        lampa2 = GameObject.FindGameObjectWithTag(targetLampa2);
        lampa3 = GameObject.FindGameObjectWithTag(targetLampa3);
        button1 = GameObject.FindGameObjectWithTag(targetButton1);
        button2 = GameObject.FindGameObjectWithTag(targetButton2);


        if (text == null)
        {
            Debug.LogError("References to drugoSvitlo or treceSvitlo are null.");
        }
    }

    private void Update()
    {
        Text textComponent = text.GetComponent<Text>();
        if (textComponent.text.Equals(targetText, System.StringComparison.OrdinalIgnoreCase))
        {
            CmdStvori();
        }
    }

    [Command(requiresAuthority =false)]
    private void CmdStvori()
    {
        RpcStvori();
    }

    [ClientRpc]
    private void RpcStvori()
    {
        this.gameObject.GetComponent<TMP_Text>().enabled = true;
        lampa1.GetComponent<MeshRenderer>().enabled = true;
        lampa2.GetComponent<MeshRenderer>().enabled = true;
        lampa3.GetComponent<MeshRenderer>().enabled = true;
        button1.GetComponent<MeshRenderer>().enabled = true;
        button2.GetComponent<MeshRenderer>().enabled = true;
    }
}
