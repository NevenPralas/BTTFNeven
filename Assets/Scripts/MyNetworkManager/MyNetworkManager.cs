using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class MyNetworkManager : NetworkManager
{

    public override void OnClientConnect()
    {
        // OnClientConnect by default calls AddPlayer but it should not do
        // that when we have online/offline scenes. so we need the
        // clientLoadedScene flag to prevent it.
        if (!clientLoadedScene)
        {
            // Ready/AddPlayer is usually triggered by a scene load completing.
            // if no scene was loaded, then Ready/AddPlayer it here instead.
            if (!NetworkClient.ready)
                NetworkClient.Ready();

            if (autoCreatePlayer)
                NetworkClient.AddPlayer();
        }
    }
}
