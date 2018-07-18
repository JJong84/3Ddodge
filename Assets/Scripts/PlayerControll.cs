using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    [SerializeField] float movementSpeed = 50f;
    [SerializeField] float turnSpeed = 60f;
    Collider[] colls;
    Transform skillEffect;
    Transform boostEffect;
    public ParticleSystem ps;
    public ParticleSystem ps2;
    public ParticleSystem pschild;
    public ParticleSystem ps2child;

    Transform myT;
    private float skillArea = 30.0f;
    private int flag = 0;
    public AudioClip audioClip;
    public AudioSource audioSource;
    public AudioClip audioClip1;
    public AudioSource audioSource1;
    private int soundcount;


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
        boostEffect = transform.GetChild(3);
        audioSource.clip = audioClip;
        audioSource1.clip = audioClip1;
        soundcount = 0;
        boostEffect.gameObject.SetActive(false);



    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            boostEffect.gameObject.SetActive(true);
            ps.Play();
            ps.loop = true;
            ps2.Play();
            ps2.loop = true;
            pschild.Play();
            pschild.loop = true;
            ps2child.Play();
            ps2child.loop = true;
        }
        if (!Input.GetKey(KeyCode.W))
        {
            ps.loop = false;
            ps2.loop = false;
            pschild.loop = false;
            ps2child.loop = false;
        }
        Turn();
        Thrust();


        if (!Input.GetKey(KeyCode.Q))
        {
            skillEffect.gameObject.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("QQQ");
            audioSource1.Play();
            skillEffect.gameObject.SetActive(true);
        }
       
        if (Input.GetKey(KeyCode.Q))
        {           
            colls = Physics.OverlapSphere(transform.position, skillArea);
            foreach (Collider coll in colls)
            {
                coll.isTrigger = false;
            }
        }

        if (flag == 1)
        {
            flag = 0;
            Time.timeScale = 1.0f;
        }
        if (Input.GetKeyDown(KeyCode.Tab)){
            audioSource.Play();
        }

        if(Input.GetKey(KeyCode.Tab))
        {
            flag = 1;
            Time.timeScale = 0.3f;
        }
        if (!Input.GetKey(KeyCode.Tab))
        {
            audioSource.Stop();
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

