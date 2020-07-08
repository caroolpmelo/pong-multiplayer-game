using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


// add this script to any multiplayer scene
public class GameSetupController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CreatePlayer();
    }

    // creates networked player obj for every player in the multip. scene
    private void CreatePlayer()
    {
        Debug.Log("Creating player");
        PhotonNetwork.Instantiate(
            Path.Combine("PhotonPrefabs", "Paddle"),
            Vector2.zero,
            Quaternion.identity
        );
    }
}
