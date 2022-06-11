using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class GameManager : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Animator anim;
    [SerializeField]
    private string state;

    private Vector3 init_pos_1, init_pos_2;
    [SerializeField]
    private Transform dice_1, dice_2;

    [SerializeField]
    private AudioSource shaking;

    private PhotonView view;

    private const byte DICE_COMMAND_EVENT = 0;

    private int should_dice = 0;

    // Start is called before the first frame update
    void Start()
    {
        anim.enabled = false;
        init_pos_1 = dice_1.position;
        init_pos_2 = dice_2.position;
        SetDices(false);
        view = GetComponent<PhotonView>();
        PhotonNetwork.NetworkingClient.EventReceived += NetworkingClient_EventReceived;
    }

    private void NetworkingClient_EventReceived(ExitGames.Client.Photon.EventData obj)
    {
        if ( obj.Code == DICE_COMMAND_EVENT)
        {
            object[] datas = (object[])obj.CustomData;
            if((int)datas[0] == 1)
            {
                DiceMechanicImplementation();
                object[] data = new object[] { 0 };
                PhotonNetwork.RaiseEvent(DICE_COMMAND_EVENT, data, Photon.Realtime.RaiseEventOptions.Default, ExitGames.Client.Photon.SendOptions.SendUnreliable);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (view.IsMine)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                object[] data = new object[] { 1 };
                PhotonNetwork.RaiseEvent(DICE_COMMAND_EVENT, data, Photon.Realtime.RaiseEventOptions.Default, ExitGames.Client.Photon.SendOptions.SendUnreliable);
                DiceMechanicImplementation();
            }
        }
    }


    private void DiceMechanicImplementation()
    {
        if(view.IsMine)
        {
            anim.enabled = true;
            anim.Rebind();
        }
        SetDices(false);
        shaking.Play();
        dice_1.position = init_pos_1;
        dice_2.position = init_pos_2;
        StartCoroutine(TimeIEnumerator());
    }



    public void DiceBoth()
    {
        dice_1.gameObject.GetComponent<DiceController>().Dice();
        dice_2.gameObject.GetComponent<DiceController>().Dice();
    }

    private IEnumerator TimeIEnumerator()
    {
        yield return new WaitForSeconds(1.25f);
        SetDices(true);
        if (view.IsMine)
        {
            DiceBoth();
        }
        StopAllCoroutines();
    }


    public void SetDices(bool value)
    {
        dice_1.gameObject.SetActive(value);
        dice_2.gameObject.SetActive(value);
    }

}
