using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControll : MonoBehaviour
{
    [SerializeField] float movementSpeed = 50f;
    [SerializeField] float turnSpeed = 60f;
    Collider[] colls;
    Transform skillEffect;

    public Image skillFilter;
    public Text coolTimeCounter; //남은 쿨타임을 표시할 텍스트

    public float coolTime;

    private float currentCoolTime; //남은 쿨타임을 추적 할 변수

    private bool canUseSkill = true; //스킬을 사용할 수 있는지 확인하는 변수

    Transform myT;
    private float skillArea = 30.0f;
    private int flag = 0;
    public AudioClip audioClip;
    public AudioSource audioSource;
    public AudioClip audioClip1;
    public AudioSource audioSource1;

    private int soundcount;

    public Text score;
    public Timer timer;
    public GameObject canvas;


    private void Awake()
    {
        myT = transform;
    }

    // Use this for initialization
    void Start()
    {
        canvas = GameObject.Find("Canvas");
        timer = canvas.GetComponent<Timer>();

        Debug.Log("Transform get child count : " + transform.childCount);
        Debug.Log("GetSiblingIndex1 : " + transform.Find("PS_OrbElectric").GetSiblingIndex().ToString());
        Debug.Log("GetSiblingIndex2 : " + transform.GetChild(1).name);
        skillFilter.fillAmount = 0;
        skillEffect = transform.GetChild(1);
        audioSource.clip = audioClip;
        audioSource1.clip = audioClip1;
        soundcount = 0;

    }

    // Update is called once per frame
    void Update()
    {
        Turn();
        Thrust();

        if (!Input.GetKey(KeyCode.Q))
        {
            //skillEffect.gameObject.SetActive(false);
        }
        if(Input.GetKeyDown(KeyCode.Q)&&canUseSkill)
        {
            audioSource1.Play();
        }
        if(Input.GetKeyDown(KeyCode.Q))
        {
            skillEffect.gameObject.SetActive(true);
            UseSkill();
        }

        if (flag == 1)
        {
            flag = 0;
            Time.timeScale = 1.0f;
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            audioSource.Play();
        }
        if (Input.GetKey(KeyCode.Tab))
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

    void SkillEffectOff()
    {
        if (skillEffect.gameObject.activeSelf == true)
        {
            skillEffect.gameObject.SetActive(false);
        }
    }

    public void UseSkill()
    {
        if (canUseSkill)
        {
            Debug.Log("Use Skill");
            Debug.Log("PlayerController Skill!!!");

            colls = Physics.OverlapSphere(transform.position, skillArea);
            foreach (Collider coll in colls)
            {
                coll.isTrigger = false;
            }
            Invoke("SkillEffectOff", 2.0f);

            skillFilter.fillAmount = 1; //스킬 버튼을 가림
            StartCoroutine("Cooltime");

            currentCoolTime = coolTime;
            if (currentCoolTime != 0f)
            {
                coolTimeCounter.text = "" + currentCoolTime;
            }
            else
            {
                coolTimeCounter.text = "";
            }

            StartCoroutine("CoolTimeCounter");

            canUseSkill = false; //스킬을 사용하면 사용할 수 없는 상태로 바꿈
        }
        else
        {
            Debug.Log("아직 스킬을 사용할 수 없습니다.");
        }
    }

    IEnumerator Cooltime()
    {
        while (skillFilter.fillAmount > 0)
        {
            //Debug.Log("##################################");
            skillFilter.fillAmount -= 1 * Time.smoothDeltaTime / coolTime;
            Debug.Log(skillFilter.fillAmount);
            yield return null;
        }

        canUseSkill = true; //스킬 쿨타임이 끝나면 스킬을 사용할 수 있는 상태로 바꿈

        yield break;
    }

    //남은 쿨타임을 계산할 코르틴을 만들어줍니다.
    IEnumerator CoolTimeCounter()
    {
        while (currentCoolTime > 0)
        {
            yield return new WaitForSeconds(1.0f);

            currentCoolTime -= 1.0f;
            coolTimeCounter.text = "" + currentCoolTime;
        }

        yield break;
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Enemy, onTriggerEnter : "+ other.gameObject.name);
        // if other.gameObject.name = Game Over
        if (other.gameObject.tag.Equals("Enemy"))
        {
            Time.timeScale = 0;
            GameObject.Find("Canvas").transform.FindChild("GameOverPanel").gameObject.SetActive(true);
            Debug.Log(timer.score);
            score.text = timer.score;
        }

    }
}
