using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceController : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField]
    private float range, downForce, forwardForce;

    private Vector3 initial_pos;
    private Quaternion initial_rot;

    [SerializeField]
    private Transform[] points;

    [SerializeField]
    private AudioSource colliding_with_ground;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        initial_pos = transform.position;
        initial_rot = transform.rotation;
        //Dice();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    Dice();
        //}

        if(is_grounded)
        {
            max_y = -10;
            if (rb.angularVelocity == Vector3.zero && rb.velocity == Vector3.zero)
            {
                for (int i = 0; i < points.Length; i++)
                {
                    if (points[i].position.y > max_y)
                    {
                        max_y = points[i].position.y;
                        number = points[i].gameObject.name;
                    }
                }
            }
        }
    }

    public void Dice()
    {
        transform.position = initial_pos;
        transform.rotation = initial_rot;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.AddTorque(new Vector3(Random.Range(-range, range), Random.Range(-range, range), Random.Range(-range, range)), ForceMode.Impulse);
        rb.AddForce(transform.forward * forwardForce - transform.up * downForce, ForceMode.Impulse);
    }


    float max_y;
    [SerializeField]
    public string number;
    private bool is_grounded;

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.gameObject.CompareTag("Ground"))
        {
            colliding_with_ground.Play();
            is_grounded = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("Ground"))
        {
            is_grounded = false;
        }
    }
}
