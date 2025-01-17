using BNG;
using JetBrains.Annotations;
using Mirror;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
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

    public string tagPresent = "Present";
    public string tagPast = "Past";
    private GameObject presentObject;
    private GameObject pastObject;


    public Material SkyboxPast;
    public Material SkyboxPresent;

    //PAST -> pocetak

    [SyncVar]
    public bool clickPast1 = false;
    [SyncVar]
    public bool clickPast2 = false;

    private GameObject pastZid11; private GameObject pastZid12; private GameObject pastZid13; private GameObject pastZid14;
    private GameObject pastZid21; private GameObject pastZid22; private GameObject pastZid23; private GameObject pastZid24;

    //PAST -> kraj

    private GameObject snapPoint1;
    private GameObject snapPoint2;
    private GameObject snapPoint3;
    private GameObject cube6;
    private GameObject cube2;
    private GameObject cube4;

    public bool prvi = false;
    public bool drugi = false;
    public bool treci = false;

    public bool prviPrviPuta = false;
    public bool drugiPrviPuta = false;
    public bool treciPrviPuta = false;

    public GameObject leverLijevi;
    private GameObject leverLijeviObject;

    private GameObject snapPoint4;
    private GameObject snapPoint5;
    private GameObject snapPoint6;
    private GameObject cube7R;
    private GameObject cube2R;
    private GameObject cube8R;

    public bool prviR = false;
    public bool drugiR = false;
    public bool treciR = false;

    public bool prviPrviPutaR = false;
    public bool drugiPrviPutaR = false;
    public bool treciPrviPutaR = false;

    public GameObject leverDesni;
    private GameObject leverDesniObject;

    private GameObject beam1;
    private GameObject beam2;
    private GameObject beam3;

    [SyncVar]
    public bool sklopka1 = false;
    [SyncVar]
    public bool sklopka2 = false;

    private GameObject grabPoint1;
    private GameObject grabPoint2;
    private GameObject grabPoint3;
    private GameObject grabPoint4;

    private GameObject[] prepreka1;
    private GameObject[] prepreka2;

    private GameObject svitlo1;
    private GameObject svitlo2;
    private GameObject svitlo3;

    private GameObject ek1;
    private GameObject ek2;
    private GameObject ek3;

    private GameObject[] slika1;
    private GameObject[] slika2;
    private GameObject[] slika3;

    public AudioClip pastZvuk;
    public AudioClip presentZvuk;
    private GameObject zvuk;

    private void Start()
    {

        zvuk = GameObject.FindGameObjectWithTag("Zvuk");

        TMText = GameObject.FindGameObjectWithTag(tagTMText);
        buttonPast = GameObject.FindGameObjectWithTag(tagButtonPast);
        buttonPresent = GameObject.FindGameObjectWithTag(tagButtonPresent);
        presentText1 = GameObject.FindGameObjectWithTag(tagPresentText1);
        presentText2 = GameObject.FindGameObjectWithTag(tagPresentText2);
        presentText3 = GameObject.FindGameObjectWithTag(tagPresentText3);

        presentImage = GameObject.FindGameObjectWithTag(tagPresentImage);

        presentObject = GameObject.FindGameObjectWithTag(tagPresent);
        pastObject = GameObject.FindGameObjectWithTag(tagPast);

        pastZid11 = GameObject.FindGameObjectWithTag("PastZid11");
        pastZid12 = GameObject.FindGameObjectWithTag("PastZid12");
        pastZid13 = GameObject.FindGameObjectWithTag("PastZid13");
        pastZid14 = GameObject.FindGameObjectWithTag("PastZid14");
        pastZid21 = GameObject.FindGameObjectWithTag("PastZid21");
        pastZid22 = GameObject.FindGameObjectWithTag("PastZid22");
        pastZid23 = GameObject.FindGameObjectWithTag("PastZid23");
        pastZid24 = GameObject.FindGameObjectWithTag("PastZid24");


        snapPoint1 = GameObject.FindGameObjectWithTag("SnapPoint1");
        snapPoint2 = GameObject.FindGameObjectWithTag("SnapPoint2");
        snapPoint3 = GameObject.FindGameObjectWithTag("SnapPoint3");

        cube6 = GameObject.FindGameObjectWithTag("Cube6");
        cube2 = GameObject.FindGameObjectWithTag("Cube2");
        cube4 = GameObject.FindGameObjectWithTag("Cube4");

        snapPoint4 = GameObject.FindGameObjectWithTag("SnapPoint4");
        snapPoint5 = GameObject.FindGameObjectWithTag("SnapPoint5");
        snapPoint6 = GameObject.FindGameObjectWithTag("SnapPoint6");

        cube7R = GameObject.FindGameObjectWithTag("Cube7R");
        cube2R = GameObject.FindGameObjectWithTag("Cube2R");
        cube8R = GameObject.FindGameObjectWithTag("Cube8R");

        beam1 = GameObject.FindGameObjectWithTag("Beam1");
        beam2 = GameObject.FindGameObjectWithTag("Beam2");
        beam3 = GameObject.FindGameObjectWithTag("Beam3");

        grabPoint1 = GameObject.FindGameObjectWithTag("GrabPoint1");
        grabPoint2 = GameObject.FindGameObjectWithTag("GrabPoint2");
        grabPoint3 = GameObject.FindGameObjectWithTag("GrabPoint3");
        grabPoint4 = GameObject.FindGameObjectWithTag("GrabPoint4");

        prepreka1 = GameObject.FindGameObjectsWithTag("Prepreka1");
        prepreka2 = GameObject.FindGameObjectsWithTag("Prepreka2");

        svitlo1 = GameObject.FindGameObjectWithTag("PrvoSvitlo");
        svitlo2 = GameObject.FindGameObjectWithTag("DrugoSvitlo");
        svitlo3 = GameObject.FindGameObjectWithTag("TreceSvitlo");
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

        ek1 = GameObject.FindGameObjectWithTag("PrviEkran");
        ek2 = GameObject.FindGameObjectWithTag("DrugiEkran");
        ek3 = GameObject.FindGameObjectWithTag("TreciEkran");

        slika1 = GameObject.FindGameObjectsWithTag("PrvaSlika");
        slika2 = GameObject.FindGameObjectsWithTag("DrugaSlika");
        slika3 = GameObject.FindGameObjectsWithTag("TrecaSlika");

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
        
        if(clickPast1 && clickPast2)
        {
            Debug.LogError("Poziv");
            CmdOtvoriProlaz();
        }

        

            if (snapPoint1.GetComponent<SnapZone>().HeldItem == cube6.GetComponent<Grabbable>() && !prviPrviPuta)
            {

                Debug.LogError("Greska1");
                prviPrviPuta = true;
                prvi = true;


            }
            else if (snapPoint1.GetComponent<SnapZone>().HeldItem != cube6.GetComponent<Grabbable>() && prviPrviPuta)
            {
                Debug.LogError("Super1");
                prviPrviPuta = false;
                prvi = false;
            }

            if (snapPoint2.GetComponent<SnapZone>().HeldItem == cube2.GetComponent<Grabbable>() && !drugiPrviPuta)
            {

                Debug.LogError("Greska2");
                drugiPrviPuta = true;
                drugi = true;

            }
            else if (snapPoint2.GetComponent<SnapZone>().HeldItem != cube2.GetComponent<Grabbable>() && drugiPrviPuta)
            {
                Debug.LogError("Super2");
                drugiPrviPuta = false;
                drugi = false;
            }

            if (snapPoint3.GetComponent<SnapZone>().HeldItem == cube4.GetComponent<Grabbable>() && !treciPrviPuta)
            {

                Debug.LogError("Greska3");
                treciPrviPuta = true;
                treci = true;

            }
            else if (snapPoint3.GetComponent<SnapZone>().HeldItem != cube4.GetComponent<Grabbable>() && treciPrviPuta)
            {
                Debug.LogError("Super3");
                treciPrviPuta = false;
                treci = false;
            }

            if (prvi && drugi && treci)
            {
                prvi = false; drugi = false; treci = false;
                Debug.LogError("TO JE TO!");
                CmdServer();
            }

            if (snapPoint6.GetComponent<SnapZone>().HeldItem == cube7R.GetComponent<Grabbable>() && !prviPrviPutaR)
            {

                Debug.LogError("Greska1");
                prviPrviPutaR = true;
                prviR = true;


            }
            else if (snapPoint6.GetComponent<SnapZone>().HeldItem != cube7R.GetComponent<Grabbable>() && prviPrviPutaR)
            {
                Debug.LogError("Super1");
                prviPrviPutaR = false;
                prviR = false;
            }

            if (snapPoint5.GetComponent<SnapZone>().HeldItem == cube2R.GetComponent<Grabbable>() && !drugiPrviPutaR)
            {

                Debug.LogError("Greska2");
                drugiPrviPutaR = true;
                drugiR = true;

            }
            else if (snapPoint5.GetComponent<SnapZone>().HeldItem != cube2R.GetComponent<Grabbable>() && drugiPrviPutaR)
            {
                Debug.LogError("Super2");
                drugiPrviPutaR = false;
                drugiR = false;
            }

            if (snapPoint4.GetComponent<SnapZone>().HeldItem == cube8R.GetComponent<Grabbable>() && !treciPrviPutaR)
            {

                Debug.LogError("Greska3");
                treciPrviPutaR = true;
                treciR = true;

            }
            else if (snapPoint4.GetComponent<SnapZone>().HeldItem != cube8R.GetComponent<Grabbable>() && treciPrviPutaR)
            {
                Debug.LogError("Super3");
                treciPrviPutaR = false;
                treciR = false;
            }

            if (prviR && drugiR && treciR)
            {
                prviR = false; drugiR = false; treciR = false;
                Debug.LogError("TO JE TO!");
                CmdServerR();
            }

            if (sklopka1)
            {
            Debug.LogError("USAO1");
                CmdMicanjeBeamova();
                
            }

        if (sklopka2)
        {
           
                Debug.LogError("USAO2");
                CmdMicanjeBeamova2();
            
        }
        
    }

    [Command(requiresAuthority = false)]
    private void CmdMicanjeBeamova()
    {
        Debug.LogError("OtisliCmd1");
        RpcMicanjeBeamova();
    }

    [Command(requiresAuthority = false)]
    private void CmdMicanjeBeamova2()
    {
        Debug.LogError("OtisliCmd2");
        RpcMicanjeBeamova2();
    }

    [ClientRpc]
    private void RpcMicanjeBeamova()
    {
        Debug.LogError("OtisliRpc1");
        beam1.GetComponent<MeshRenderer>().enabled = false;
        beam1.GetComponent<MeshCollider>().enabled = false;

        beam2.GetComponent<MeshRenderer>().enabled = false;
        beam2.GetComponent<MeshCollider>().enabled = false;

        grabPoint1.GetComponent<MeshRenderer>().enabled = true;
        grabPoint1.GetComponent<BoxCollider>().enabled = true;
        grabPoint4.GetComponent<MeshRenderer>().enabled = true;
        grabPoint4.GetComponent<BoxCollider>().enabled = true;

        for(int i = 0; i<prepreka1.Length; i++){
            prepreka1[i].GetComponent<BoxCollider>().enabled = false;
        }
    }

    [ClientRpc]
    private void RpcMicanjeBeamova2()
    {
        Debug.LogError("OtisliRpc2");

        beam3.GetComponent<MeshRenderer>().enabled = false;
        beam3.GetComponent<MeshCollider>().enabled = false;

        grabPoint3.GetComponent<MeshRenderer>().enabled = true;
        grabPoint3.GetComponent<BoxCollider>().enabled = true;
        grabPoint2.GetComponent<MeshRenderer>().enabled = true;
        grabPoint2.GetComponent<BoxCollider>().enabled = true;

        for(int i = 0; i<prepreka2.Length; i++){
            prepreka2[i].GetComponent<BoxCollider>().enabled = false;
        }
    }
    [Command]
    public void CmdSklopka1()
    {
        sklopka1 = true;
        Debug.LogError("SKLOPKA1: " + sklopka1);
        Debug.LogError("SKLOPKA2: " + sklopka2);
    }

    [Command]
    public void CmdSklopka2()
    {
        sklopka2 = true;
        Debug.LogError("SKLOPKA1: " + sklopka1);
        Debug.LogError("SKLOPKA2: " + sklopka2);
    }

    [Command]
    private void CmdServer()
    {
        leverLijeviObject = Instantiate(leverLijevi);
        NetworkServer.Spawn(leverLijeviObject);
    }

    [Command]
    private void CmdServerR()
    {
        leverDesniObject = Instantiate(leverDesni);
        NetworkServer.Spawn(leverDesniObject);
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

        RenderSettings.skybox = SkyboxPast;

        presentImage.GetComponent<Image>().sprite = pastSprite;

        for(int i = 0; i<presentObject.transform.childCount; i++)
        {
            Transform child  = presentObject.transform.GetChild(i);
            child.gameObject.SetActive(false);
        }
        for (int i = 0; i < pastObject.transform.childCount; i++)
        {
            Transform child = pastObject.transform.GetChild(i);
            child.gameObject.SetActive(true);
        }
if(svitlo1!=null)
        svitlo1.GetComponent<MeshRenderer>().enabled = false;
if(svitlo2!=null)
        svitlo2.GetComponent<MeshRenderer>().enabled = false;
if(svitlo3!=null)
        svitlo3.GetComponent<MeshRenderer>().enabled = false;

        if (slika1 != null)
        {
            for(int i = 0; i<slika1.Length; i++)
            {
                slika1[i].GetComponent<MeshRenderer>().enabled = false;
            }
        }
        if (slika2 != null)
        {
            for (int i = 0; i < slika2.Length; i++)
            {
                slika2[i].GetComponent<MeshRenderer>().enabled = false;
            }
        }
        if (slika3 != null)
        {
            for (int i = 0; i < slika3.Length; i++)
            {
                slika3[i].GetComponent<MeshRenderer>().enabled = false;
            }
        }
if(ek1!=null){
        Vector3 currentPosition1 = ek1.transform.position;
        currentPosition1.y = 0;
        ek1.transform.position = currentPosition1;
}
if(ek2!=null){
        Vector3 currentPosition2 = ek2.transform.position;
        currentPosition2.y = 0;
        ek2.transform.position = currentPosition2;
}
if(ek3!=null){
Vector3 currentPosition3 = ek3.transform.position;
        currentPosition3.y = 0;
        ek3.transform.position = currentPosition3;
}
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

        RenderSettings.skybox = SkyboxPresent;

        presentImage.GetComponent<Image>().sprite = presentSprite;

        for (int i = 0; i < presentObject.transform.childCount; i++)
        {
            Transform child = presentObject.transform.GetChild(i);
            child.gameObject.SetActive(true);
        }
        for (int i = 0; i < pastObject.transform.childCount; i++)
        {
            Transform child = pastObject.transform.GetChild(i);
            child.gameObject.SetActive(false);
        }
if(svitlo1!=null)
        svitlo1.GetComponent<MeshRenderer>().enabled = true;
if(svitlo2!=null)
        svitlo2.GetComponent<MeshRenderer>().enabled = true;
if(svitlo3!=null)
        svitlo3.GetComponent<MeshRenderer>().enabled = true;

        if (slika1 != null)
        {
            for (int i = 0; i < slika1.Length; i++)
            {
                slika1[i].GetComponent<MeshRenderer>().enabled = true;
            }
        }
        if (slika2 != null)
        {
            for (int i = 0; i < slika2.Length; i++)
            {
                slika2[i].GetComponent<MeshRenderer>().enabled = true;
            }
        }
        if (slika3 != null)
        {
            for (int i = 0; i < slika3.Length; i++)
            {
                slika3[i].GetComponent<MeshRenderer>().enabled = true;
            }
        }

        if (ek1!=null){
        Vector3 currentPosition1 = ek1.transform.position;
        currentPosition1.y = 17.379f;
        ek1.transform.position = currentPosition1;
}
if(ek2!=null){
    Vector3 currentPosition2 = ek2.transform.position;
        currentPosition2.y = 17.379f;
        ek2.transform.position = currentPosition2;
}
if(ek3!=null){
    Vector3 currentPosition3 = ek3.transform.position;
        currentPosition3.y = 17.379f;
        ek3.transform.position = currentPosition3;
}
    }

    // PAST -> pocetak

    [Command]
    public void CmdPritisnuoPast1() {
        clickPast1 = true;
    }

    [Command]
    public void CmdPritisnuoPast2()
    {
        clickPast2 = true;
    }

    [Command]
    public void CmdOtpustioPast1()
    {
        clickPast1 = false;
    }

    [Command]
    public void CmdOtpustioPast2()
    {
        clickPast2 = false;
    }

    [Command]
    public void CmdOtvoriProlaz()

    {
        Debug.LogError("PozivCMD");
        RpcOtvoriProlaz();
    }

    [ClientRpc]
    public void RpcOtvoriProlaz()
    {
        Debug.LogError("PozivRPC");

        pastZid11.GetComponent<MeshRenderer>().enabled = true; pastZid11.GetComponent<BoxCollider>().enabled = true;
        pastZid12.GetComponent<MeshRenderer>().enabled = true; pastZid12.GetComponent<BoxCollider>().enabled = true;
       
    }

    // PAST -> kraj
}
