using UnityEngine;
using Photon.Pun;
using TMPro;

public class RoomItem : MonoBehaviour
{
    [SerializeField] TMP_Text buttonText;

    Lobby lobby;

    void Start()
    {
        lobby = FindObjectOfType<Lobby>();
    }

    public void SetRoomName(string roomName)
    {
        buttonText.text = roomName;
    }

    public void JoinRoomClick()
    {
        lobby.JoinRoom(buttonText.text);
    }
}
