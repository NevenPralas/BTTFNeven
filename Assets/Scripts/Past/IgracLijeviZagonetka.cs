using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using BNG;

public class IgracLijeviZagonetka : NetworkBehaviour
{
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

   


    private void Start()
    {
        snapPoint1 = GameObject.FindGameObjectWithTag("SnapPoint1");
        snapPoint2 = GameObject.FindGameObjectWithTag("SnapPoint2");
        snapPoint3 = GameObject.FindGameObjectWithTag("SnapPoint3");

        cube6 = GameObject.FindGameObjectWithTag("Cube6");
        cube2 = GameObject.FindGameObjectWithTag("Cube2");
        cube4 = GameObject.FindGameObjectWithTag("Cube4");

        
        
        
    }

    private void Update()
    {

        if (snapPoint1.GetComponent<SnapZone>().HeldItem == cube6.GetComponent<Grabbable>() && !prviPrviPuta)
        {

            Debug.LogError("Greska1");
            prviPrviPuta = true;
            prvi = true;


        }
        else if(snapPoint1.GetComponent<SnapZone>().HeldItem != cube6.GetComponent<Grabbable>() && prviPrviPuta)
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
        else if(snapPoint2.GetComponent<SnapZone>().HeldItem != cube2.GetComponent<Grabbable>() && drugiPrviPuta)
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
        else if(snapPoint3.GetComponent<SnapZone>().HeldItem != cube4.GetComponent<Grabbable>() && treciPrviPuta)
        {
            Debug.LogError("Super3");
            treciPrviPuta = false;
            treci = false;
        }
        
        if (prvi && drugi && treci)
        {
            Debug.LogError("TO JE TO!");
            CmdServer();
        }




    }
   [Command(requiresAuthority = false)]
   private void CmdServer()
    {
        RpcServer();
    }

    [ClientRpc]
    private void RpcServer()
    {
        prvi = false; drugi = false; treci = false;
        leverLijeviObject = Instantiate(leverLijevi);
        NetworkServer.Spawn(leverLijeviObject);
    }


    [Command(requiresAuthority = false)]
    private void CmdPrviPrviPuta()
    {
        RpcPrviPrviPuta();
    }

    [ClientRpc]
    private void RpcPrviPrviPuta()
    {
        Debug.LogError("Greska1");
        prviPrviPuta = true;
        prvi = true;
    }


    [Command(requiresAuthority = false)]
    private void CmdDrugiPrviPuta()
    {
        RpcDrugiPrviPuta();
    }
    [ClientRpc]
    private void RpcDrugiPrviPuta()
    {
        Debug.LogError("Greska2");
        drugiPrviPuta = true;
        drugi = true;
    }

    [Command(requiresAuthority = false)]
    private void CmdTreciPrviPuta()
    {
        RpcTreciPrviPuta();
    }
    [ClientRpc]
    private void RpcTreciPrviPuta()
    {
        Debug.LogError("Greska3");
        treciPrviPuta = true;
        treci = true;
    }

    [Command(requiresAuthority = false)]
    private void CmdPrviPrviPutaFalse()
    {
        RpcPrviPrviPutaFalse();
    }
    [ClientRpc]
    private void RpcPrviPrviPutaFalse()
    {
        Debug.LogError("Super1");
        prviPrviPuta = false;
        prvi = false;
    }
    [Command(requiresAuthority = false)]
    private void CmdDrugiPrviPutaFalse()
    {
        RpcDrugiPrviPutaFalse();
    }
    [ClientRpc]
    private void RpcDrugiPrviPutaFalse()
    {
        Debug.LogError("Super2");
        drugiPrviPuta = false;
        drugi = false;
    }
    [Command(requiresAuthority = false)]
    private void CmdTreciPrviPutaFalse()
    {
        RpcTreciPrviPutaFalse();
    }

    [ClientRpc]
    private void RpcTreciPrviPutaFalse()
    {
        Debug.LogError("Super3");
        treciPrviPuta = false;
        treci = false;
    }


}
