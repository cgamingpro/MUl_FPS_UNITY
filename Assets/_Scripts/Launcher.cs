using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using Photon.Realtime;

public class Launcher : MonoBehaviourPunCallbacks
{
    public static Launcher Instance;
    [SerializeField] TMP_InputField RoomNameInputFiled;
    [SerializeField] TMP_Text Error_text;
    [SerializeField] TMP_Text roomName_text;
    [SerializeField] Transform roomList_transform;
    [SerializeField] GameObject roomListcontent_button;
    [SerializeField] Transform PlayerList_transform;
    [SerializeField] GameObject PlayerListcontent_text;
    private void Awake()
    {
        Instance = this;
    }
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
    public void CreateRoom()
    {
        if(string.IsNullOrEmpty(RoomNameInputFiled.text))
        {
            return;
        }
        PhotonNetwork.CreateRoom(RoomNameInputFiled.text);
        MenuMangaer.Instance.OpenMenustr("loading_menu");
    }
    public override void OnJoinedRoom()
    {
        MenuMangaer.Instance.OpenMenustr("room_menu");
        roomName_text.text = PhotonNetwork.CurrentRoom.Name;
        PhotonNetwork.NickName = "cg" + Random.Range(0,123).ToString();

        Player[] playerArray = PhotonNetwork.PlayerList;
        for(int i = 0; i < playerArray.Length; i++)
        {
            Instantiate(PlayerListcontent_text, PlayerList_transform).GetComponent<PlayerListItem>().Setup(playerArray[i]);
        }
    }
    public override void OnCreateRoomFailed(short returnCode, string message)
    {

        MenuMangaer.Instance.OpenMenustr("error_menu");
        Error_text.text = "cretionfail " + message;    
    }
    public void leaveRoom()
    {
        PhotonNetwork.LeaveRoom();
        MenuMangaer.Instance.OpenMenustr("loading_menu");
    }
    public void JoinRoom(RoomInfo info )
    {
        PhotonNetwork.JoinRoom(info.Name);
        MenuMangaer.Instance.OpenMenustr("loading_menu");
    }
    public override void OnLeftRoom()
    {
        MenuMangaer.Instance.OpenMenustr("title_menu");
    }
    public void ApplicationQuit()
    {
        Application.Quit();
    }
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach(Transform t in roomList_transform)
        {
            Destroy(t.gameObject);
        }
        for (int i = 0; i < roomList.Count; i++) 
        {
            Instantiate(roomListcontent_button, roomList_transform).GetComponent<RoomItemButton>().setupRoom(roomList[i]);
        }
    }
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Instantiate(PlayerListcontent_text,PlayerList_transform).GetComponent<PlayerListItem>().Setup(newPlayer);
    }
}
