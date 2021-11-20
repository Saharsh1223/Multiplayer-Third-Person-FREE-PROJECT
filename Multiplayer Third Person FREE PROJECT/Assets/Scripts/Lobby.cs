using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System;
using System.Collections.Generic;
using TMPro;

public class Lobby : MonoBehaviourPunCallbacks
{
    [SerializeField] TMP_InputField createInput;
    [Space]
    [SerializeField] byte maxPlayers = 10;
    [Space]
    [SerializeField] RoomItem roomItemPrefab;
    [SerializeField] Transform contentObject;

    List<RoomItem> roomItemsList = new List<RoomItem>();


    void Start()
    {
        PhotonNetwork.JoinLobby();
    }

    public void CreateRoom()
    {
        if(createInput.text.Length >= 1)
        {
            RoomOptions roomOptions = new RoomOptions();
            roomOptions.IsVisible = true;
            roomOptions.MaxPlayers = maxPlayers;

            PhotonNetwork.CreateRoom(createInput.text, roomOptions);
        }
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Game");
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        UpdateRoomList(roomList);
    }

    void UpdateRoomList(List<RoomInfo> list)
    {
        foreach (RoomItem item in roomItemsList)
        {
            Destroy(item.gameObject);
        }
        roomItemsList.Clear();

        foreach (RoomInfo info in list)
        {
            RoomItem newRoom = Instantiate(roomItemPrefab, contentObject);
            newRoom.SetRoomName(info.Name);
            roomItemsList.Add(newRoom);
        }
    }

    public void JoinRoom(string roomName)
    {
        PhotonNetwork.JoinRoom(roomName);
    }
}
