using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class PlayerSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject PlayerPrefab;

    private GameObject instance;

    static private int turn = 1;
    private void Start()
    {
        print(turn);
        if(turn == 1)
        {
            instance = PhotonNetwork.Instantiate(PlayerPrefab.name, PlayerPrefab.transform.position, PlayerPrefab.transform.rotation);
            instance.tag = "A";
            turn += 1; 
        }
        else if (turn == 2)
        {
            instance = PhotonNetwork.Instantiate(PlayerPrefab.name, PlayerPrefab.transform.position, PlayerPrefab.transform.rotation);
            instance.tag = "B";
        }
    }
}
