using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class GameManager : MonoBehaviour
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

    // Start is called before the first frame update
    void Start()
    {
        anim.enabled = false;
        init_pos_1 = dice_1.position;
        init_pos_2 = dice_2.position;
        view = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if (view.IsMine)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                anim.enabled = true;
                shaking.Play();
                anim.Rebind();
                dice_1.position = init_pos_1;
                dice_2.position = init_pos_2;
                //DiceBoth();
            }
        }
    }

    public void DiceBoth()
    {
        dice_1.gameObject.GetComponent<DiceController>().Dice();
        dice_2.gameObject.GetComponent<DiceController>().Dice();
    }

}
