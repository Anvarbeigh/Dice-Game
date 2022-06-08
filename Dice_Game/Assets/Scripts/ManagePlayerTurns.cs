using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class ManagePlayerTurns : MonoBehaviour
{
    public static int turn = 1;

    private GameObject a, b;

    private void Start()
    {
        if (turn == 1)
        {
            a = GameObject.FindGameObjectWithTag("A");
            turn++;
        }
        else
        b = GameObject.FindGameObjectWithTag("B");
    }
    public void Update()
    {
       
    }
}
