using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using Photon.Realtime;

public class RoomItemButton : MonoBehaviourPunCallbacks
{

    [SerializeField] TMP_Text roomNameText;
    RoomInfo info;
    
    public void setupRoom(RoomInfo _info)
    {
        info = _info;
        roomNameText.text  = info.Name;
    }
    public void OnClick()
    {
        Launcher.Instance.JoinRoom(info);
    }
}

