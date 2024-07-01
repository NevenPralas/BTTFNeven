using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using BNG;

public class PrvoSvitlo : NetworkBehaviour
{
    private GameObject drugoSvitlo;
    private GameObject treceSvitlo;

    public string drugoSvitloTag = "DrugoSvitlo";
    public string treceSvitloTag = "TreceSvitlo";

    public GameObject slika1;
    private GameObject slika1Object;

    [SyncVar]
    public bool prviPuta = true;

    public string objekt;
    private GameObject objektObject;

    private void Start()
    {
        drugoSvitlo = GameObject.FindGameObjectWithTag(drugoSvitloTag);
        treceSvitlo = GameObject.FindGameObjectWithTag(treceSvitloTag);

        objektObject = GameObject.FindGameObjectWithTag(objekt);

        if (drugoSvitlo == null || treceSvitlo == null)
        {
            Debug.LogError("References to drugoSvitlo or treceSvitlo are null.");
        }
    }

    private void Update()
    {
        if (gameObject.TryGetComponent<MeshRenderer>(out MeshRenderer renderer) && renderer.sharedMaterials.Length > 0 &&
            drugoSvitlo != null && treceSvitlo != null && prviPuta)
        {
            if (renderer.sharedMaterials[0].name.Contains("Zelena"))
            {
                if (drugoSvitlo.GetComponent<MeshRenderer>().sharedMaterials[0].name.Contains("Red") &&
                    treceSvitlo.GetComponent<MeshRenderer>().sharedMaterials[0].name.Contains("Red") && prviPuta)
                {
                    CmdStvori();
                    prviPuta = false;
                }
            }
        }
        else
        {
            Debug.LogWarning("One or more references are missing or null.");
        }
    }

    [Command(requiresAuthority = false)]
    private void CmdStvori()
    {
        if (slika1 != null)
        {
            prviPuta = false;
            slika1Object = Instantiate(slika1);
            NetworkServer.Spawn(slika1Object);

            RpcFreezeX();

            
        }
        else
        {
            Debug.LogError("Prefab reference slika1 is null.");
        }
    }

    [ClientRpc]
    private void RpcFreezeX()
    {
        if (objektObject != null && objektObject.TryGetComponent<Rigidbody>(out Rigidbody rigidbody))
        {
            objektObject.GetComponent<Rigidbody>().constraints |= RigidbodyConstraints.FreezeRotationX;
            objektObject.GetComponent<Grabbable>().enabled = false;
    }
}
}