using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkController : MonoBehaviourPunCallbacks
{
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings(); // connect to photon master servers
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("We are now connected to the "
            + PhotonNetwork.CloudRegion + " server!");
    }
}
