using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject PlayerPrefab;

    private GameObject instance;

    static private int turn = 1;
    private void Start()
    {
        WriteToLog("Entered " + turn.ToString() + " Player");
        print(turn);
        turn += 1;
        //if(turn == 1)
        //{
        //    instance = PhotonNetwork.Instantiate(PlayerPrefab.name, PlayerPrefab.transform.position, PlayerPrefab.transform.rotation);
        //    instance.name = "a";
        //    turn += 1; 
        //}
        //else if (turn == 2)
        //{
        //    instance = PhotonNetwork.Instantiate(PlayerPrefab.name, PlayerPrefab.transform.position, PlayerPrefab.transform.rotation);
        //    instance.tag = "B";
        //}
    }



    [SerializeField]
    private Text LogText;
    public void WriteToLog(string text)
    {
        LogText.text += "\n" + text;
    }



}
