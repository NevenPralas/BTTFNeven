using Mirror;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class PlayerScript : NetworkBehaviour
{
    [SyncVar]
    public bool stisnuo1 = false;
    [SyncVar]
    public bool stisnuo2 = false;

    [SyncVar]
    public bool stisnuo3 = false;

    [SyncVar]
    public bool stisnuo4 = false;

    [SyncVar]
    public bool stisnuo5 = false;

    [SyncVar]
    public bool stisnuo6 = false;
    [SyncVar]
    public bool stisnuo7 = true;

    [SyncVar]
    public bool stisnuoVideo = false;

    public GameObject vrata;
    GameObject vrataObject;

    public GameObject vrata2;
    GameObject vrata2Object;

    public GameObject vrataVelikaSoba;
    GameObject vrataVelikaSobaObject;

    public GameObject videoRecorder;
    GameObject videoRecorderObject;

    bool unspawned = false;

    public GameObject ekran1;
    GameObject ekran1Object;
    public GameObject ekran2;
    GameObject ekran2Object;
    public GameObject ekran3;
    GameObject ekran3Object;

    int k = 0;

    [SyncVar]
    public bool click1 = false;
    [SyncVar]
    public bool click2 = false;

    public GameObject door1;
    GameObject door1Object;

    [SyncVar]
    public bool click3 = false;
    [SyncVar]
    public bool click4 = false;

    private GameObject TMText;
    public string tagTMText = "TMText";

    private GameObject buttonPast;
    private GameObject buttonPresent;
    public string tagButtonPast = "ButtonPast";
    public string tagButtonPresent = "ButtonPresent";

    [SyncVar]
    public bool clickPast = false;
    [SyncVar]
    public bool clickPresent = false;
    [SyncVar]
    public bool clickPocetak = true;

    public string tagPresentText1 = "PresentText1";
    public string tagPresentText2 = "PresentText2";
    public string tagPresentText3 = "PresentText3";
    private GameObject presentText1;
    private GameObject presentText2;
    private GameObject presentText3;

    public string tagPresentImage = "PresentImage";
    private GameObject presentImage;
    public Sprite pastSprite;
    public Sprite presentSprite;

    [SyncVar]
    public bool vrataOtvorena = false;
    [SyncVar]
    public bool vrataOtvorenaPrviPuta = false;
    [SyncVar]
    public bool textPrviPuta = false;
    private GameObject text;
    public string textTag = "Text";
    public string targetText = "aztec";


    private void Start()
    {
        TMText = GameObject.FindGameObjectWithTag(tagTMText);
        buttonPast = GameObject.FindGameObjectWithTag(tagButtonPast);
        buttonPresent = GameObject.FindGameObjectWithTag(tagButtonPresent);
        presentText1 = GameObject.FindGameObjectWithTag(tagPresentText1);
        presentText2 = GameObject.FindGameObjectWithTag(tagPresentText2);
        presentText3 = GameObject.FindGameObjectWithTag(tagPresentText3);

        presentImage = GameObject.FindGameObjectWithTag(tagPresentImage);

        text = GameObject.FindGameObjectWithTag(textTag);
    }

    public override void OnStartServer()
    {
        if (isServer && isLocalPlayer && isOwned)
        {

            //TEST ->  stisnuo2 = true; 
            base.OnStartServer();
            Debug.LogError("Izvrseno");


            vrataObject = Instantiate(vrata);
            NetworkServer.Spawn(vrataObject);

            vrata2Object = Instantiate(vrata2);
            NetworkServer.Spawn(vrata2Object);

            vrataVelikaSobaObject = Instantiate(vrataVelikaSoba);
            NetworkServer.Spawn(vrataVelikaSobaObject);

            door1Object = Instantiate(door1);
            NetworkServer.Spawn(door1Object);

            

        }
    }

    private void Update()
    {
        Text textComponent = text.GetComponent<Text>();

        if (stisnuo1 && stisnuo2)
        {
            if (authority)
            {
                CmdDoor();
            }
        }
        else if(stisnuo5 && stisnuo6 && stisnuo7)
        {
            if (authority)
            {
                
                CmdDoorVelikaSoba();
                CmdStvoriEkrane();
                stisnuo7 = false;
                
            }
        }

        if ((stisnuo3 && !unspawned) || (stisnuo4 && !unspawned)) {
            if (authority)
            {
                CmdDoor2();
                unspawned = true;
            }
        }
        else if ((!stisnuo3 && unspawned && !stisnuo4))
        {
            if (authority)
            {
                CmdDoor2Stvori();
                unspawned = false;
            }
        }
        else if (stisnuoVideo)
        {
            if (authority)
            {
                CmdVideoUnisti();
                CmdVideoStvori();
                stisnuoVideo = false;
            }
        }
        else if(click1 && click2)
        {
            if (authority)
            {
                CmdDoor1Open();
                
            }
            CmdTextOpen();
        }
        else if(click3 && click4)
        {
            if (authority)
            {
                CmdDoor1Close();
                
            }
            CmdTextClosed();
        }
        else if(clickPast && !clickPocetak)
        {
            CmdPastText();
        }
        else if(clickPresent && !clickPocetak)
        {
            CmdPresentText();
        }
        else if (textComponent.text.Equals(targetText, System.StringComparison.OrdinalIgnoreCase) && !textPrviPuta)
        {
            if (authority)
            {
                CmdDoorGore();
                textPrviPuta = true;
            }
        }
        else if (vrataOtvorena && !vrataOtvorenaPrviPuta)
        {
            if (authority)
            {
                CmdDoorGoreNapokon();
                vrataOtvorenaPrviPuta = true;
            }
        }

    }
    [Command]
    private void CmdDoorGore()
    {
        Debug.LogError("CmdDoorGore");
        vrataOtvorena = true;
    }
    [Command]
    private void CmdDoorGoreNapokon()
    {
        Debug.LogError("Gotovo -> Velika soba");
        Animator animator = vrataVelikaSobaObject.GetComponent<Animator>();
        animator.SetBool("stisnut", false);
    }

    [Command]
    public void CmdStvoriEkrane()
    {
        ekran1Object = Instantiate(ekran1);
        NetworkServer.Spawn(ekran1Object);
        ekran2Object = Instantiate(ekran2);
        NetworkServer.Spawn(ekran2Object);
        ekran3Object = Instantiate(ekran3);
        NetworkServer.Spawn(ekran3Object);
    }

    [Command] 
    public void CmdDoorVelikaSoba()
    {
        Debug.LogError("Usao -> Velika soba");
        Animator animator = vrataVelikaSobaObject.GetComponent<Animator>();
        animator.SetBool("stisnut", true);
    }

    [Command]
    public void CmdVideoPritisni()
    {
        stisnuoVideo = true;
        Debug.LogError("StisnuoVideo: " + stisnuoVideo);
    }

    [Command]
    public void CmdVideoUnisti()
    {
        if (videoRecorderObject != null)
            NetworkServer.Destroy(videoRecorderObject);
    }

    [Command]
    public void CmdVideoStvori()
    {
        videoRecorderObject = Instantiate(videoRecorder);
        NetworkServer.Spawn(videoRecorderObject);
    }

    [Command]
    public void CmdDoor()
    {

        Animator animator = vrataObject.GetComponent<Animator>();
        animator.SetBool("press", true);

    }

    [Command]
    public void CmdDoor2()
    {

        Animator animator = vrata2Object.GetComponent<Animator>();
        animator.SetBool("press", true);

    }


    [Command]
    public void CmdDoor2Stvori()
    {

        Animator animator = vrata2Object.GetComponent<Animator>();
        animator.SetBool("press", false);
    }

    [Command]
    public void CmdPritisni()
    {
        stisnuo3 = true;
        Debug.LogError("Stisnuo3: " + stisnuo3);
    }
    [Command]
    public void CmdOtpusti()
    {
        stisnuo3 = false;
        Debug.LogError("Stisnuo3: " + stisnuo3);
    }

    [Command]
    public void CmdPritisniDS()
        {
        stisnuo4 = true;
        Debug.LogError("Stisnuo4:" +stisnuo4);
        }

    [Command]
    public void CmdOtpustiDS()
    {
        stisnuo4 = false;
        Debug.LogError("Stisnuo4:" +stisnuo4);
    }



    [Command]
    public void CmdPritisni1()
    {
        stisnuo1 = true;
        Debug.LogError("Stisnuo1: " + stisnuo1);
        Debug.LogError("Stisnuo2: " + stisnuo2);
    }

    [ClientRpc]
    void RpcPritisni1()
    {
        stisnuo1 = true;
        Debug.LogError("Stisnuo1: " + stisnuo1);
        Debug.LogError("Stisnuo2: " + stisnuo2);
    }

    [Command]
    public void CmdOtpusti1()
    {
        stisnuo1 = false;
    }

    [ClientRpc]
    void RpcOtpusti1()
    {
        stisnuo1 = false;
    }

    [Command]
    public void CmdPritisni2()
    {
        stisnuo2 = true;
        Debug.LogError("Stisnuo1: " + stisnuo1);
        Debug.LogError("Stisnuo2: " + stisnuo2);
    }

    [ClientRpc]
    void RpcPritisni2()
    {
        stisnuo2 = true;
        Debug.LogError("Stisnuo1: " + stisnuo1);
        Debug.LogError("Stisnuo2: " + stisnuo2);
    }

    [Command]
    public void CmdOtpusti2()
    {
        stisnuo2 = false;
    }

    [ClientRpc]
    void RpcOtpusti2()
    {
        stisnuo2 = false;
    }

    [Command]
    public void CmdPritisni5()
    {
        stisnuo5 = true;
    }

    [Command]
    public void CmdPritisni6()
    {
        stisnuo6 = true;
    }

    [Command]
    public void CmdOtpusti5()
    {
        stisnuo5 = false;
    }

    [Command]
    public void CmdOtpusti6()
    {
        stisnuo6 = false;
    }

    [Command]
    public void CmdClick1()
    {
        click1 = true;
    }

    [Command]
    public void CmdClick2()
    {
        click2 = true;
    }

    [Command]
    public void CmdUnclick1()
    {
        click1 = false;
    }

    [Command]
    public void CmdUnclick2()
    {
        click2 = false;
    }

    [Command]
    public void CmdDoor1Open()
    {
        Animator animator = door1Object.GetComponent<Animator>();
        animator.SetBool("press", true);
    }

    [Command]
    public void CmdClick3()
    {
        click3 = true;
    }
    [Command]
    public void CmdClick4()
    {
        click4 = true;
    }
    [Command]
    public void CmdUnclick3()
    {
        click3 = false;
    }
    [Command]
    public void CmdUnclick4()
    {
        click4 = false;
    }
    [Command]
    public void CmdDoor1Close()
    {
        Animator animator = door1Object.GetComponent<Animator>();
        animator.SetBool("press", false);
    }

    [Command(requiresAuthority = false)]
    public void CmdTextOpen()
    {
        RpcTextOpen();
    }
    [Command(requiresAuthority = false)]
    public void CmdTextClosed()
    {
        RpcTextClosed();
    }

    [ClientRpc]
    public void RpcTextOpen()
    {
        TMText.GetComponent<TMP_Text>().text = "Open";
        TMText.GetComponent<TMP_Text>().color = Color.green;

        buttonPresent.GetComponent<MeshRenderer>().enabled = false;
        buttonPast.GetComponent<MeshRenderer>().enabled = false;
        buttonPresent.GetComponent<BoxCollider>().enabled = false;
        buttonPast.GetComponent<BoxCollider>().enabled = false;
    }

    [ClientRpc]
    public void RpcTextClosed()
    {
        TMText.GetComponent<TMP_Text>().text = "Closed";
        TMText.GetComponent<TMP_Text>().color = Color.red;

        buttonPresent.GetComponent<MeshRenderer>().enabled = true;
        buttonPast.GetComponent<MeshRenderer>().enabled = true;
        buttonPresent.GetComponent<BoxCollider>().enabled = true;
        buttonPast.GetComponent<BoxCollider>().enabled = true;
    }

    [Command]
    public void CmdPast()
    {
        clickPocetak = false;
        clickPresent = false;
        clickPast = true;
    }
    [Command]
    public void CmdPresent()
    {
        clickPocetak = false;
        clickPast = false;
        clickPresent = true;
    }

    [Command(requiresAuthority = false)]
    public void CmdPastText()
    {
        RpcPastText();
    }
    [Command(requiresAuthority = false)]
    public void CmdPresentText()
    {
        RpcPresentText();
    }
    [ClientRpc]
    public void RpcPastText()
    {
        presentText1.GetComponent<TMP_Text>().text = "PAST";
        presentText1.GetComponent<TMP_Text>().color = Color.cyan;
        presentText2.GetComponent<TMP_Text>().text = "PAST";
        presentText2.GetComponent<TMP_Text>().color = Color.cyan;
        presentText3.GetComponent<TMP_Text>().text = "PAST";
        presentText3.GetComponent<TMP_Text>().color = Color.cyan;

        presentImage.GetComponent<Image>().sprite = pastSprite;
    }
    [ClientRpc]
    public void RpcPresentText()
    {
        presentText1.GetComponent<TMP_Text>().text = "PRESENT";
        presentText1.GetComponent<TMP_Text>().color = Color.yellow;
        presentText2.GetComponent<TMP_Text>().text = "PRESENT";
        presentText2.GetComponent<TMP_Text>().color = Color.yellow;
        presentText3.GetComponent<TMP_Text>().text = "PRESENT";
        presentText3.GetComponent<TMP_Text>().color = Color.yellow;

        presentImage.GetComponent<Image>().sprite = presentSprite;
    }
}
