using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBullet : MonoBehaviour {
    public bool enableSpawn = true;
    public GameObject Enemy;
    public Rigidbody rb;
    public int r = 47;

    void SpawnEnemy()
    {
        Debug.Log("in");
        float randomTheta = Random.Range(0, 1f);
        float randomPi = Random.Range(0, 2f);
        float sinTheta = Mathf.Sin(randomTheta * 3.14f);
        float cosTheta = Mathf.Cos(randomTheta * 3.14f);
        float cosPi = Mathf.Cos(randomPi * 3.14f);
        float sinPi = Mathf.Sin(randomPi * 3.14f);

        Debug.Log("spawn");
        GameObject enemy = (GameObject)Instantiate(Enemy, new Vector3(sinTheta*cosPi, cosTheta, sinTheta *sinPi)*r, Quaternion.identity); //랜덤한 위치와, 화면 제일 위에서 Enemy를 하나 생성해줍니다.
        Debug.Log("axis");
        Debug.Log(sinTheta * cosPi * r);
        Debug.Log(sinTheta * sinPi*r);
        rb = enemy.GetComponent<Rigidbody>();
        rb.velocity = new Vector3(sinTheta * cosPi, cosTheta, sinTheta * sinPi)*(-3);
    }

    // Use this for initialization
    void Start () {
        Enemy = GameObject.FindGameObjectWithTag("Enemy"); //Prefab을 받을 public 변수 입니다.
    InvokeRepeating("SpawnEnemy", 3, 0.1f);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        //gameover
    }
}
