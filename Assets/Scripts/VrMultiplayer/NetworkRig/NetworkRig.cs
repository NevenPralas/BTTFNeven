using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class NetworkRig : NetworkBehaviour
{
    public HardwareRig hardwareRig;

    public NetworkHand leftNetworkHand;
    public NetworkHand rightNetworkHand;
    public NetworkHead networkHead;

    private void Start()
    {
        if(!isOwned)
        {
            return;
        }

        if (isOwned)
        {
            hardwareRig = HardwareRig.Instance;
        }
    }

    private void LateUpdate()
    {
        if (isOwned)
        {
            UpdateRigTransforms();
        }

        
    }

    void UpdateRigTransforms()
    {
        transform.SetPositionAndRotation(hardwareRig.transform.position, hardwareRig.transform.rotation);
        leftNetworkHand.transform.SetPositionAndRotation(hardwareRig.leftHand.transform.position, hardwareRig.leftHand.transform.rotation);
        rightNetworkHand.transform.SetPositionAndRotation(hardwareRig.rightHand.transform.position, hardwareRig.rightHand.transform.rotation);
        networkHead.transform.SetPositionAndRotation(hardwareRig.headSet.transform.position, hardwareRig.headSet.transform.rotation);
    }
}
