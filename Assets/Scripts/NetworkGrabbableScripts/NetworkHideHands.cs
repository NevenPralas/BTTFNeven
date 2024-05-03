using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class NetworkHideHands : NetworkBehaviour
{
    // skinned mesh renderers of the players hand / lefthand if on the left hand and right hand GFX if on the right hand
    public SkinnedMeshRenderer[] handRenderes;

    //enable the hand skinned mesh renderers
    public void ShowHandGFX()
    {
        CmdEnableHandgfx(true);
    }

    // disable the hand skinned mesh renderers
    public void HideHandGFX()
    {
        CmdEnableHandgfx(false);
    }

    [Command(requiresAuthority = false)]
    public void CmdEnableHandgfx(bool visible)
    {
        RpcEnableHandGfx(visible);
    }

    // exclude the owner as we don't want to hide and show the local gfx
    [ClientRpc(includeOwner = false)]
    public void RpcEnableHandGfx(bool visible)
    {
        foreach (SkinnedMeshRenderer render in handRenderes)
        {
            render.enabled = visible;
        }
    }
}
