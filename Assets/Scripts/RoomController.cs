using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private int multiplayerSceneIndex; // num for build index to scene

    public override void OnEnable() // trigerred on LobbyController
    {
        PhotonNetwork.AddCallbackTarget(this);
    }

    public override void OnDisable()
    {
        PhotonNetwork.RemoveCallbackTarget(this);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined room");
        StartGame();
    }

    private void StartGame() // loads into multiplayer scene
    {
        if (PhotonNetwork.IsMasterClient)
        {
            Debug.Log("Starting game");
            // because of AutomaticallySyncScene = true in Lobby, we load this scene
            PhotonNetwork.LoadLevel(multiplayerSceneIndex);
        }
    }
}
