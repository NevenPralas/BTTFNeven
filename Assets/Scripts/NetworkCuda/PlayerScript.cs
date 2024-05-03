using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

        }
    }

    private void Update()
    {

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
}
