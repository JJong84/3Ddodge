using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    [SerializeField] float movementSpeed = 50f;
    [SerializeField] float turnSpeed = 60f;
    Collider[] colls;
    Transform skillEffect;

    Transform myT;
    private float skillArea = 30.0f;

    private void Awake()
    {
        myT = transform;
    }

    // Use this for initialization
    void Start()
    {
        Debug.Log("Transform get child count : " + transform.childCount);
        Debug.Log("GetSiblingIndex1 : " + transform.Find("PS_OrbElectric").GetSiblingIndex().ToString());
        Debug.Log("GetSiblingIndex2 : " + transform.GetChild(1).name);
        skillEffect = transform.GetChild(1);

    }

    // Update is called once per frame
    void Update()
    {
        Turn();
        Thrust();

        


        if (Input.GetKey(KeyCode.Q))
        {
            skillEffect.gameObject.SetActive(true);
            Debug.Log("PlayerController Skill!!!");            

            colls = Physics.OverlapSphere(transform.position, skillArea);
            foreach (Collider coll in colls)
            {
                coll.isTrigger = false;
            }
            Invoke("SkillEffectOff", 2.0f);
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

    void SkillEffectOff()
    {
        if (skillEffect.gameObject.activeSelf == true)
        {
            skillEffect.gameObject.SetActive(false);
        }
    }
}
