using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class C_createandjoinrooms : MonoBehaviourPunCallbacks
{

    public InputField createInput;
    public InputField joinInput;
    public GameObject waitbanner,roomfull;
    GameObject player1, player2;
    public static int ismultiplayer;


    public void Start()
    {
        waitbanner.SetActive(false);
        roomfull.SetActive(false);
        ismultiplayer = 0;
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        //PhotonNetwork.JoinLobby();
        //print("connected");

    }

    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(createInput.text);
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(joinInput.text);
    }

    public override void OnJoinedRoom()
    {
        /*if(PhotonNetwork.CurrentRoom.PlayerCount==1)
        {
            waitbanner.SetActive(true);
        }
        else 
        */
        if(PhotonNetwork.CurrentRoom.PlayerCount >2)
        {
            roomfull.SetActive(true);
        }
        else
        {
            ismultiplayer = 1;
            waitbanner.SetActive(false);
            roomfull.SetActive(false);
            
            PhotonNetwork.LoadLevel("MainGame");
        }
        
    }

    public void m_loadscene()
    {
        PhotonNetwork.Disconnect();
        ismultiplayer = 0;
        SceneManager.LoadScene("StartGame");
    }

    public void m_playerturns()
    {
        
    }

}
