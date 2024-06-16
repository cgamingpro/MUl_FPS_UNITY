using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Launcher : MonoBehaviourPunCallbacks
{
    
    void Start()
    {
        Debug.Log("joigin master");
        PhotonNetwork.ConnectUsingSettings();   
    }
    public override void OnConnectedToMaster()
    {
        Debug.Log("joingin lobby");
        PhotonNetwork.JoinLobby();
    }
    public override void OnJoinedLobby()
    {
        MenuMangaer.Instance.OpenMenustr("title_menu");
        Debug.Log("joinedlobbu");
    }

   
    void Update()
    {
        
    }
}
