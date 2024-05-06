using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class TileCollider : NetworkBehaviour
{
    public GameObject pocetna; // Prefab
    public GameObject svjetlo; // Prefab
    private GameObject svjetloObject;

    public Material greenMaterial;
    public Material redMaterial;

    // Potpis koji odgovara očekivanjima Mirror-a
    [SyncVar(hook = nameof(OnSvjetloObjectChanged))]
    private NetworkIdentity svjetloObjectIdentity;

    public override void OnStartServer()
    {
        // Samo server instancira i spawnuje objekte
        svjetloObject = Instantiate(svjetlo);
        NetworkServer.Spawn(svjetloObject);

        // Sinhronizacija NetworkIdentity
        svjetloObjectIdentity = svjetloObject.GetComponent<NetworkIdentity>();
    }

    public override void OnStartClient()
    {
        if (svjetloObjectIdentity != null)
        {
            svjetloObject = svjetloObjectIdentity.gameObject;
        }
    }

    // Ispravljen potpis za hook metodu
    private void OnSvjetloObjectChanged(NetworkIdentity oldIdentity, NetworkIdentity newIdentity)
    {
        svjetloObject = newIdentity?.gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == pocetna.gameObject.name)
        {
            CmdChangeColorToGreen();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == pocetna.gameObject.name)
        {
            CmdChangeColorToRed();
        }
    }

    [Command(requiresAuthority = false)]
    private void CmdChangeColorToGreen()
    {
        if (svjetloObject != null)
        {
            RpcChangeColorToGreen();
        }
    }

    [Command(requiresAuthority = false)]
    private void CmdChangeColorToRed()
    {
        if (svjetloObject != null)
        {
            RpcChangeColorToRed();
        }
    }

    [ClientRpc]
    private void RpcChangeColorToGreen()
    {
        if (svjetloObject == null)
        {
            Debug.LogWarning("svjetloObject is null");
            return;
        }

        Material[] materials = svjetloObject.GetComponent<MeshRenderer>().sharedMaterials;
        materials[0] = greenMaterial;
        svjetloObject.GetComponent<MeshRenderer>().sharedMaterials = materials;
    }

    [ClientRpc]
    private void RpcChangeColorToRed()
    {
        if (svjetloObject == null)
        {
            Debug.LogWarning("svjetloObject is null");
            return;
        }

        Material[] materials = svjetloObject.GetComponent<MeshRenderer>().sharedMaterials;
        materials[0] = redMaterial;
        svjetloObject.GetComponent<MeshRenderer>().sharedMaterials = materials;
    }
}