using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treceSvitlo : NetworkBehaviour
{
    private GameObject prvoSvitlo;
    private GameObject drugoSvitlo;

    public string prvoSvitloTag = "PrvoSvitlo";
    public string drugoSvitloTag = "DrugoSvitlo";

    public GameObject slika3;
    private GameObject slika3Object;

    [SyncVar]
    public bool prviPuta = true;

    public string objekt;
    private GameObject objektObject;

    private void Start()
    {
        prvoSvitlo = GameObject.FindGameObjectWithTag(prvoSvitloTag);
        drugoSvitlo = GameObject.FindGameObjectWithTag(drugoSvitloTag);

        objektObject = GameObject.FindGameObjectWithTag(objekt);

        if (prvoSvitlo == null || drugoSvitlo == null)
        {
            Debug.LogError("References to prvoSvitlo or drugoSvitlo are null.");
        }
    }

    private void Update()
    {
        if (gameObject.TryGetComponent<MeshRenderer>(out MeshRenderer renderer) && renderer.sharedMaterials.Length > 0 &&
            prvoSvitlo != null && drugoSvitlo != null && prviPuta)
        {
            if (renderer.sharedMaterials[0].name.Contains("Zelena"))
            {
                if (prvoSvitlo.GetComponent<MeshRenderer>().sharedMaterials[0].name.Contains("Zelena") &&
                    drugoSvitlo.GetComponent<MeshRenderer>().sharedMaterials[0].name.Contains("Zelena") && prviPuta)
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
        if (slika3 != null)
        {
            slika3Object = Instantiate(slika3);
            NetworkServer.Spawn(slika3Object);

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
        }
    }
}
