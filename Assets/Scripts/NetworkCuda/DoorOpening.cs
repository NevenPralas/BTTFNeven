using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpening : NetworkBehaviour
{
    [SyncVar]
    public bool stisnuo1 = false;
    [SyncVar]
    public bool stisnuo2 = false;


    private void Update()
    {

        CmdDoor();
        

        if (stisnuo1 && stisnuo2)
        {
            Debug.LogError("TELEPORTACIJA");
            GetComponent<Animator>().SetBool("stisnut", true);
        }
    }

    [Command]
    public void CmdDoor()
    {
        Debug.LogError("Dosao");
        GetComponent<Animator>().SetBool("stisnut", true);
    }


    [Command]
    public void CmdPritisni1()
    {
        Debug.LogError("CmdPritisni1");
        RpcPritisni1();
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
        Debug.LogError("CmdOtpusti1");
        RpcOtpusti1();
    }

    [ClientRpc]
    void RpcOtpusti1()
    {
        stisnuo1 = false;
    }

    [Command]
    public void CmdPritisni2()
    {
        Debug.LogError("CmdPritisni2");
        RpcPritisni2();
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
        Debug.LogError("CmdOtpusti1");
        RpcOtpusti2();
    }

    [ClientRpc]
    void RpcOtpusti2()
    {
        stisnuo2 = false;
    }

}
