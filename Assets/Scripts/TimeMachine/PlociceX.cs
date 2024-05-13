using BNG;
using Mirror;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking;

public class PlociceX : NetworkBehaviour
{

    public float speed = 10;
    [SyncVar]
    public bool usao = false;

    private void Update()
    {
        if (usao)
        {
            this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            StartCoroutine(MoveBack());
        }
        else
        {
            StartCoroutine(MoveBack());
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        usao = true;

        Vector3 normal = collision.contacts[0].normal;

        Vector3 reverseDirection = Vector3.Reflect(transform.forward, normal);

        GetComponent<Rigidbody>().velocity = reverseDirection * speed;
    }

    private void OnCollisionExit(Collision collision)
    {
        usao = false;
    }

    IEnumerator MoveBack()
    {
        yield return new WaitForSeconds(1f);
        this.GetComponent<Rigidbody>().constraints = ~RigidbodyConstraints.FreezePositionX;
    }

}
