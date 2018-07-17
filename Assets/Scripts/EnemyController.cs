using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public float distance;

    Collider m_ObjectCollider;
    private int timeManager;
    float TimeFloat;
    int TimeInt;
    float DelayTime;
    float RepeatingTime = 2.0f;

    PlayerControll playerControll;




    void IsTriggerOnAndOff()
    {
        if (m_ObjectCollider.isTrigger == false)
        {
            m_ObjectCollider.isTrigger = true;
        }
        else
        {
            m_ObjectCollider.isTrigger = false;
        }
        
        /*

        if(m_ObjectCollider.isTrigger == false)
        {
            m_ObjectCollider.isTrigger = true;
        }
        else
        {
            m_ObjectCollider.isTrigger = false;
        }

        */

        //Debug.Log("istTrigger set to true , "+Time.time +"/" + gameObject.name);
        //m_ObjectCollider.isTrigger = false;

    }

    void TriggerCheck()
    {
        if (m_ObjectCollider.isTrigger == false)
        {
            m_ObjectCollider.isTrigger = true;
        }
    }


    // Use this for initialization
    void Start()
    {
        playerControll = GameObject.Find("Player").GetComponent<PlayerControll>();

        TimeFloat = Mathf.Floor(Time.time * 100) * 0.01f;
        TimeInt = (int)TimeFloat;
        DelayTime = (TimeInt / 5 + 1) * 5 - TimeFloat;

        //Debug.Log("EnenmyController, count : " + GameObject.FindGameObjectsWithTag("Enemy").Length);
        //Debug.Log("EnenmyController, time : " + (int) Time.time);
        //  Debug.Log("EnenmyController, time : " + Time.time);
        //Debug.Log("EnenmyController, time : " + Mathf.Floor(Time.time*100));
        //Debug.Log("EnenmyController, float - int : " + (Time.time - Mathf.Floor(Time.time)));
        //Debug.Log("EnemyController, int : " + TimeInt);

        /*
        Debug.Log("EnenmyController, start time : " + Time.time);
        Debug.Log("EnemyController, second float : " + TimeFloat);
        
        Debug.Log("EnemyCOntroller, DelayTime : " + DelayTime);
        Debug.Log("EnenmyController, end time : " + Time.time);
        */


        m_ObjectCollider = GetComponent<Collider>();

        //InvokeRepeating("IsTriggerOnAndOff", DelayTime, RepeatingTime);
        //InvokeRepeating("IsTriggerOnAndOff", DelayTime, RepeatingTime+0.1f);
        InvokeRepeating("TriggerCheck", DelayTime, 0.5f);




    }

    // Update is called once per frame
    void Update()
    {

        /*
        if (playerControll.skill)
        {         
            IsTriggerOnAndOff();
            Invoke("IsTriggerOnAndOff", 0.1f);
        }
        */



        if (m_ObjectCollider.isTrigger == false)
        {
            // m_ObjectCollider.isTrigger = false;
            //m_ObjectCollider.isTrigger = true;
            //   Debug.Log("isTrigger set to false");
        }

        //Debug.Log("enemey position : "+transform.position.x +" / "+transform.position.y+" / "+transform.position.z);

        distance = Mathf.Sqrt(transform.position.x * transform.position.x + transform.position.y * transform.position.y + transform.position.z * transform.position.z);
        if (distance > 50)
        {
            //Debug.Log("enemy destroyed");
            Destroy(gameObject);
        }


    }


    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Enemy, on Collision Enter");
        // Debug.Log("Collision with "+collision.gameObject.name);
    }

    private void OnTriggerEnter(Collider other)
    {
        //   Debug.Log("Enemy, onTriggerEnter");
    }



}
