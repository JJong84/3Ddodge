using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    [SerializeField] float movementSpeed = 50f;
    [SerializeField] float turnSpeed = 60f;
    Collider[] colls;

    Transform myT;

    private void Awake()
    {
        myT = transform;
    }

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Turn();
        Thrust();

        if (Input.GetKey(KeyCode.Q))
        {          
            Debug.Log("PlayerController Skill!!!");            

            colls = Physics.OverlapSphere(transform.position, 20.0f);
            foreach (Collider coll in colls)
            {
                coll.isTrigger = false;
            }

        }

    }

    void Turn()
    {
        myT.position += myT.right * movementSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
    }

    void Thrust()
    {
        myT.position += myT.forward * movementSpeed * Time.deltaTime * Input.GetAxis("Vertical");
    }
}
