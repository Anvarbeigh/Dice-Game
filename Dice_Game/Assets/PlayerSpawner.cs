using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class PlayerSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject PlayerPrefab;

    private void Start()
    {
        PhotonNetwork.Instantiate(PlayerPrefab.name, PlayerPrefab.transform.position, PlayerPrefab.transform.rotation);
    }
}
