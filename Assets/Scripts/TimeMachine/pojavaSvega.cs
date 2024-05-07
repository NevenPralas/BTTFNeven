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
    public string targetButton3 = "Button3";
    public string targetButton4 = "Button4";

    private GameObject button1;
    private GameObject button2;
    private GameObject button3;
    private GameObject button4;

    public string tagDoorGore = "DoorGore";
    private GameObject doorGore;

    Animator animator;


    private void Start()
    {
        text = GameObject.FindGameObjectWithTag(textTag);
        lampa1 = GameObject.FindGameObjectWithTag(targetLampa1);
        lampa2 = GameObject.FindGameObjectWithTag(targetLampa2);
        lampa3 = GameObject.FindGameObjectWithTag(targetLampa3);
        button1 = GameObject.FindGameObjectWithTag(targetButton1);
        button2 = GameObject.FindGameObjectWithTag(targetButton2);
        button3 = GameObject.FindGameObjectWithTag(targetButton3);
        button4 = GameObject.FindGameObjectWithTag(targetButton4);

        doorGore = GameObject.FindGameObjectWithTag(tagDoorGore);

        animator = doorGore.GetComponent<Animator>();
        animator.SetBool("stisnut", true);



        if (text == null || lampa1 == null || lampa2 == null || lampa3 == null 
            || button1 == null || button2 == null || button3 == null || button4 == null || doorGore == null)
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
        button1.GetComponent<BoxCollider>().enabled = true;
        button2.GetComponent<BoxCollider>().enabled = true;
        button3.GetComponent<MeshRenderer>().enabled = true;
        button4.GetComponent<MeshRenderer>().enabled = true;
        button3.GetComponent<BoxCollider>().enabled = true;
        button4.GetComponent<BoxCollider>().enabled = true;

        // Animator animator = doorGore.GetComponent<Animator>();
        animator.SetBool("stisnut", false);
    }
}
