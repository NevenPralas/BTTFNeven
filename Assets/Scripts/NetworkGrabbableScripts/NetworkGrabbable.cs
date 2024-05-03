using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using BNG;
public class NetworkGrabbable : NetworkBehaviour
{
    // assign rigidbody of grabbable
    public Rigidbody rb;

    // primary grabbable
    public Grabbable grabbable;

    // 2nd hand grabbable if useing 2 handed or a slide weapons
    public Grabbable grabbableTwo;

    // primary hand mesh renderers
    public SkinnedMeshRenderer[] RHImposterRenderers;
    public SkinnedMeshRenderer[] LHImposterRenderers;
    // secondary hand mesh renderers
    public SkinnedMeshRenderer[] RHImposterRenderersTwo;
    public SkinnedMeshRenderer[] LHImposterRenderersTwo;

    // ringhelper canvas
    public Canvas ringCanvas;
    public RingHelper ringHelper;

    [SyncVar(hook = (nameof(UpdateGrabStatus)))]
    public bool holdingStatus = false;
    public void UpdateGrabStatus(bool oldHoldStatus, bool newHoldStatus)
    {
        // enable/ disable the helper ring on grab and release
        if (ringHelper != null)
        {
            ringHelper.enabled = !newHoldStatus;
        }

        if (ringCanvas)
        {
            ringCanvas.enabled = !newHoldStatus;
        }
    }

    // called from the NetworkGrabTrigger component on the RemoteGrabber of the Network Rig
    public void PickUpEvent()
    {
        // if player doesn't own it and no one is holding it, request authority
        if (isOwned == false && holdingStatus == false)
        {
            ResetInteractableVelocity();
            CmdPickup();
        }
    }

    // assign to OnGrab event on the grabbable unity events component on the grabbable
    public void PickUpEventHoldTrue()
    {
        // if called from the host/server no need to call a command, set the hook directly
        if (isServer)
        {
            holdingStatus = true;
        }
        // if called from a client not the host call command to set hold status to true
        else
        {
            CmdSetHoldStatus(true);
        }

        // if grabbing with the right hand, send command to enable the imposter hand on the clients excluding the owner
        if (grabbable.GetPrimaryGrabber().HandSide == ControllerHand.Right)
        {
            CmdRhImposterEnable(true);
        }
        // if grabbing with the left hand, send command to enable the imposter hand on the clients excluding the owner
        if (grabbable.GetPrimaryGrabber().HandSide == ControllerHand.Left)
        {
            CmdLhImposterEnable(true);
        }

    }

    // assing to ondrop event on the grabbable unity events on the grabbable
    public void DropEventHoldFalse()
    {
        // if called from the host/server, no need to send a command to set holding status, set it directly
        if (isServer)
        {
            holdingStatus = false;
        }
        // if called from a client not the host send a command to set the hold status false
        else
        {
            CmdSetHoldStatus(false);
        }

        // disable the imposter hands on drop
        CmdRhImposterEnable(false);
        CmdLhImposterEnable(false);

    }



    // command to set holding status, true if being held, false if not being held
    [Command(requiresAuthority = false)]
    public void CmdSetHoldStatus(bool status)
    {
        holdingStatus = status;
    }

    // command to request object authority if we don't already own it
    [Command(requiresAuthority = false)]
    public void CmdPickup(NetworkConnectionToClient sender = null)
    {
        ResetInteractableVelocity();

        if (sender != netIdentity.connectionToClient)
        {
            netIdentity.RemoveClientAuthority();
            netIdentity.AssignClientAuthority(sender);
        }
    }

    // command to server enable /  disable rightimposter hand
    [Command(requiresAuthority = false, channel = 0)]
    public void CmdRhImposterEnable(bool imposterBool)
    {
        RpcRhImposterEnable(imposterBool);
    }
    // rpc to clients to enable/disable right imposter hand
    [ClientRpc(includeOwner = false, channel = 0)]
    public void RpcRhImposterEnable(bool imposterBool)
    {
        foreach (SkinnedMeshRenderer renderer in RHImposterRenderers)
        {
            renderer.enabled = imposterBool;
        }

    }
    // command to server enable /  disable left imposter hand
    [Command(requiresAuthority = false, channel = 0)]
    public void CmdLhImposterEnable(bool imposterBool)
    {
        RpcLhImposterEnable(imposterBool);
    }
    // rpc to clients to enable/disable left imposter hand
    [ClientRpc(includeOwner = false, channel = 0)]
    public void RpcLhImposterEnable(bool imposterBool)
    {
        foreach (SkinnedMeshRenderer renderer in LHImposterRenderers)
        {
            renderer.enabled = imposterBool;
        }
    }

    /// <summary>
    /// if using a 2nd hand grab like a gun slide
    /// </summary> 
    // command to server enable /  disable rightimposter hand
    public void SecondHandGrab()
    {
        // if grabbing with the right hand, send command to enable the imposter hand on the clients excluding the owner
        if (grabbableTwo.GetPrimaryGrabber().HandSide == ControllerHand.Right)
        {
            CmdRhImposterEnableTwo(true);
        }
        // if grabbing with the left hand, send command to enable the imposter hand on the clients excluding the owner
        if (grabbableTwo.GetPrimaryGrabber().HandSide == ControllerHand.Left)
        {
            CmdLhImposterEnableTwo(true);
        }
    }

    public void SecondHandDrop()
    {
        CmdRhImposterEnableTwo(false);
        CmdLhImposterEnableTwo(false);
    }

    [Command(requiresAuthority = false, channel = 0)]
    public void CmdRhImposterEnableTwo(bool imposterBool)
    {
        RpcRhImposterEnableTwo(imposterBool);
    }
    // rpc to clients to enable/disable right imposter hand
    [ClientRpc(includeOwner = false, channel = 0)]
    public void RpcRhImposterEnableTwo(bool imposterBool)
    {
        foreach (SkinnedMeshRenderer renderer in RHImposterRenderersTwo)
        {
            renderer.enabled = imposterBool;
        }

    }
    // command to server enable /  disable left imposter hand
    [Command(requiresAuthority = false, channel = 0)]
    public void CmdLhImposterEnableTwo(bool imposterBool)
    {
        RpcLhImposterEnableTwo(imposterBool);
    }
    // rpc to clients to enable/disable left imposter hand
    [ClientRpc(includeOwner = false, channel = 0)]
    public void RpcLhImposterEnableTwo(bool imposterBool)
    {
        foreach (SkinnedMeshRenderer renderer in LHImposterRenderersTwo)
        {
            renderer.enabled = imposterBool;
        }
    }


    // reset the velocity to zero on drop
    private void ResetInteractableVelocity()
    {
        // Unitys interactable types need some adjustments to stop them behaving weird over network
        // Without this you may notice some pickups rapidly fall through the floor
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }
}
