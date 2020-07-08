using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyController : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private GameObject startButton; // create and/or join game

    [SerializeField]
    private GameObject cancelButton; // stop searing for a game to join

    [SerializeField]
    private int RoomSize; // number of players

    public override void OnConnectedToMaster()
    {
        // automatically sync network when scene is opened
        PhotonNetwork.AutomaticallySyncScene = true;
        startButton.SetActive(true);
    }

    public void GameStart() // start btn
    {
        startButton.SetActive(false);
        cancelButton.SetActive(true);
        PhotonNetwork.JoinRandomRoom(); // try to join existing room
        Debug.Log("Start game");
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Failed to join a room");
        CreateRoom();
    }

    void CreateRoom() // try to create my room
    {
        Debug.Log("Creating room");
        int randomRoomNum = Random.Range(0, 10000);

        RoomOptions roomOps = new RoomOptions()
        {
            IsVisible = true,
            IsOpen = true,
            MaxPlayers = (byte)RoomSize
        };

        // try to create room, if fails go to OnCreateRoomFailed
        PhotonNetwork.CreateRoom("Room" + randomRoomNum, roomOps);
        Debug.Log(randomRoomNum);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Failed to create room... Retrying");
        CreateRoom();
    }

    public void GameCancel() // cancel btn
    {
        cancelButton.SetActive(false);
        startButton.SetActive(true);
        PhotonNetwork.LeaveRoom();
    }
}
