using BNG;
using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kraj : NetworkBehaviour
{
    private GameObject snapPresent;
    private GameObject totem;

    public GameObject vatra1;
    public GameObject vatra2;
    // Start is called before the first frame update
    void Start()
    {
        snapPresent = GameObject.FindGameObjectWithTag("SnapPresent");
        totem = GameObject.FindGameObjectWithTag("Totem");
    }

    // Update is called once per frame
    void Update()
    {
        if (snapPresent.GetComponent<SnapZone>().HeldItem == totem.GetComponent<Grabbable>())
        {
            Debug.LogError("Poziv");
            CmdKraj();

        }
    }

    [Command(requiresAuthority = false)]
    private void CmdKraj()
    {
        RpcKraj();
    }

    [ClientRpc]
    private void RpcKraj()
    {
        Debug.LogError("Kraj RPC");
        vatra1.SetActive(true);
        vatra2.SetActive(true);
    }
}
