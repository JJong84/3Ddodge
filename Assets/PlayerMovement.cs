using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [SerializeField] float movementSpeed = 50f;
    [SerializeField] float turnSpeed = 60f;

    Transform myT;

    private void Awake()
    {
        myT = transform;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Turn();
        Thrust();
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
