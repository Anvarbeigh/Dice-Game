using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;


public class JoinAndCreateRoom : MonoBehaviourPunCallbacks
{

    [SerializeField]
    private InputField createField, joinField;


    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(createField.text);
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(joinField.text);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Game");
    }
}
