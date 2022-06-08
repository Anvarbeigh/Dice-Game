using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class PlayerSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject PlayerPrefab;

    private GameObject a, b;

    private static int turn = 1;

    private void Start()
    {
        if(turn == 1)
        {
            a = PhotonNetwork.Instantiate(PlayerPrefab.name, PlayerPrefab.transform.position, PlayerPrefab.transform.rotation);
            a.tag = "A";
            turn++;
        }
        else if(turn == 2)
        {
            b = PhotonNetwork.Instantiate(PlayerPrefab.name, PlayerPrefab.transform.position, PlayerPrefab.transform.rotation);
            b.tag = "B";

        }
    }
}
