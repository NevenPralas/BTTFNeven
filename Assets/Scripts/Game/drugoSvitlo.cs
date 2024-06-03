using BNG;
using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drugoSvitlo : NetworkBehaviour
{
    private GameObject prvoSvitlo;
    private GameObject treceSvitlo;

    public string prvoSvitloTag = "PrvoSvitlo";
    public string treceSvitloTag = "TreceSvitlo";

    public GameObject slika2;
    private GameObject slika2Object;

    [SyncVar]
    public bool prviPuta = true;

    public string objekt;
    private GameObject objektObject;

    private void Start()
    {
        prvoSvitlo = GameObject.FindGameObjectWithTag(prvoSvitloTag);
        treceSvitlo = GameObject.FindGameObjectWithTag(treceSvitloTag);

        objektObject = GameObject.FindGameObjectWithTag(objekt);

        if (prvoSvitlo == null || treceSvitlo == null)
        {
            Debug.LogError("References to prvoSvitlo or treceSvitlo are null.");
        }
    }

    private void Update()
    {
        if (gameObject.TryGetComponent<MeshRenderer>(out MeshRenderer renderer) && renderer.sharedMaterials.Length > 0 &&
            prvoSvitlo != null && treceSvitlo != null && prviPuta)
        {
            if (renderer.sharedMaterials[0].name.Contains("Zelena"))
            {
                if (prvoSvitlo.GetComponent<MeshRenderer>().sharedMaterials[0].name.Contains("Zelena") &&
                    treceSvitlo.GetComponent<MeshRenderer>().sharedMaterials[0].name.Contains("Red") && prviPuta)
                {
                    CmdStvori();
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
        if (slika2 != null)
        {
            slika2Object = Instantiate(slika2);
            NetworkServer.Spawn(slika2Object);

            RpcFreezeX();

            prviPuta = false;
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
            rigidbody.constraints |= RigidbodyConstraints.FreezePositionX;
            objektObject.GetComponent<Grabbable>().enabled = false;
        }
    }
}
