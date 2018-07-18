using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBullet : MonoBehaviour {
    public Timer timer;
    public GameObject Player;
    public bool enableSpawn = true;
    public GameObject Enemy;
    public Rigidbody rb;
    public int radius;

    void SpawnEnemy()
    {
        float speedConstant = Mathf.Pow(1.03f, timer.timeCount);
        float randomMode = Random.Range(0, 4f);
        float randomSpeed = Random.Range(1 * speedConstant, 2f * speedConstant)*20;

        float randomTheta = Random.Range(0, 1f);
        float randomPi = Random.Range(0, 2f);
        float sinTheta = Mathf.Sin(randomTheta * 3.14f);
        float cosTheta = Mathf.Cos(randomTheta * 3.14f);
        float cosPi = Mathf.Cos(randomPi * 3.14f);
        float sinPi = Mathf.Sin(randomPi * 3.14f);

        float alpha = Random.Range(-1f, 1f);
        float beta = Random.Range(-1f, 1f);
        float gamma = Random.Range(-1f, 1f);
        //float randomBeta = Random.Range(0, 1f);
        //float theta = 0.25f;

        //Debug.Log("spawn");
        //랜덤한 위치와, 화면 제일 위에서 Enemy를 하나 생성해줍니다.  
        Enemy = (GameObject)Instantiate(Resources.Load("Prefab/Enemy"), new Vector3(sinTheta * cosPi, cosTheta, sinTheta * sinPi) * radius, Quaternion.identity);
  
        rb = Enemy.GetComponent<Rigidbody>();

        if (randomMode < 3f)
        {
            rb.velocity = (new Vector3(Player.transform.position.x - rb.position.x, Player.transform.position.y - rb.position.y, Player.transform.position.z - rb.position.z) + (new Vector3(alpha, beta, gamma)*5)).normalized * randomSpeed;
        }
        else
        {
            float a = sinTheta * cosPi;
            float b = cosTheta;
            float c = sinTheta * sinPi;
            //float p = Mathf.Pow((b/c), 2) + 1f;
            //float q = (2*a*b*alpha)/Mathf.Pow(c, 2);
            //float r = Mathf.Pow(alpha, 2)*(1f+ Mathf.Pow((a / c), 2))-1f;
            //float beta;
            //float gamma;
            /*
            float x = Mathf.Pow(randomAlpha, 2) + Mathf.Pow(randomBeta, 2);
            float y = Mathf.Pow(Mathf.Cos(theta * 3.14f), 2);
            float z = (-sinTheta * cosPi) * randomAlpha + (-cosTheta) * randomBeta;
            float c = -sinTheta * sinPi;
            float c3;
            
            if (randomMode < 3f)
            {
                //beta = (-q + Mathf.Sqrt(Mathf.Pow(q, 2) - 4 * p * r)) / (2 * p);
                //gamma = -(a * alpha) / c - (b * beta) / c;
                //Debug.Log(Mathf.Pow(c * z, 2) - Mathf.Pow(c, 2) * x * y + x * Mathf.Pow(y, 2));
                //c3 = (-2 * c * z - 2 * Mathf.Sqrt(Mathf.Pow(c * z, 2) - Mathf.Pow(c, 2) * x * y + x * Mathf.Pow(y, 2))) / (2 * Mathf.Pow(c, 2) - 2 * y);
            }
            else
            {
                //beta = (-q - Mathf.Sqrt(Mathf.Pow(q, 2) - 4 * p * r)) / (2 * p);
                //gamma = -(a * alpha) / c - (b * beta) / c;
                //c3 = (-2 * c * z + 2 * Mathf.Sqrt(Mathf.Pow(c * z, 2) - Mathf.Pow(c, 2) * x * y + x * Mathf.Pow(y, 2))) / (2 * Mathf.Pow(c, 2) - 2 * y);
            }
            //Debug.Log(c3);
            */
            rb.velocity = ((new Vector3(-a, -b, -c))+(new Vector3(alpha, beta, gamma)/3)).normalized * randomSpeed; //vector > 1 크기
            //rb.velocity = (new Vector3(a, b, c) * (-randomSpeed)) * 10;
        }
        
    }

    // Use this for initialization
    void Start () {
        timer = GameObject.Find("Canvas").GetComponent<Timer>();
        GameObject.Find("Canvas").transform.FindChild("GameOverPanel").gameObject.SetActive(false);
        Enemy = GameObject.FindGameObjectWithTag("Enemy"); //Prefab을 받을 public 변수 입니다.
        InvokeRepeating("SpawnEnemy", 2, 0.05f);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        //gameover
    }
}
