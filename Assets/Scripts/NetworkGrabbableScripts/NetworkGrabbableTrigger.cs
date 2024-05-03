using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;
public class NetworkGrabbableTrigger : MonoBehaviour
{
    public NetworkGrabbable nGrabbable;
    public Grabber grabber;

    [SerializeField] int grabbableLayer = 10; //  grabbale layer for VRIF is 10 by default, change if needed
    public void Start()
    {
        // make sure nGrabble is null on start
        nGrabbable = null;
    }
    private void OnTriggerStay(Collider other)
    {
        // if the object in the trigger is on the grabbable layer
        if (other.gameObject.layer == grabbableLayer)
        {
            nGrabbable = other.GetComponent<NetworkGrabbable>();
        }

        if (nGrabbable != null)
        {
            // change this inputbridge check to suit your needs
            if (grabber.HandSide == ControllerHand.Right && InputBridge.Instance.RightGripDown || grabber.HandSide == ControllerHand.Left && InputBridge.Instance.LeftGripDown)
            {
                nGrabbable.PickUpEvent();
            }
        }
    }
}
