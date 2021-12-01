using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class C_connectToServer : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    public void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void OnConnectedToMaster()
    {
        //PhotonNetwork.JoinLobby();
        //print("connected");

    }

    public override void OnJoinedLobby()
    {
        SceneManager.LoadScene("Lobby");
    }

}
