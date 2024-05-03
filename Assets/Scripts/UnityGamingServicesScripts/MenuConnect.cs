using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Services.Authentication;
using Unity.Services.Core;
using Utp;

public class MenuConnect : MonoBehaviour
{
    public RelayNetworkManager relayNetworkManager;
    public int numberOfPlayers = 2;
    public string region;

    private async void Awake()
    {
        await UnityServices.InitializeAsync();
        await AuthenticationService.Instance.SignInAnonymouslyAsync();
    }

    public void CreateGame()
    {
        relayNetworkManager.StartRelayHost(numberOfPlayers, region);
    }

    public void JointGame()
    {
        relayNetworkManager.JoinRelayServer();
    }
}
