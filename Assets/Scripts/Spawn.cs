using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {
    public GameObject[] enemy;
    public float spawn_time;
    public int max_waves = 1;
    public GameObject limit_left;
    public GameObject limit_right;
    public GameObject limit_height;

    // Use this for initialization
    void Start () {
        
        InvokeRepeating("SpawnEnemy", 2, spawn_time);
	}
	
	// Update is called once per frame
	void Update () {
	}

    void SpawnEnemy()
    {
        float minX = limit_left.transform.position.x;
        float maxX = limit_right.transform.position.x;
        float height = limit_height.transform.TransformPoint( transform.position).y;
        int waves = Random.Range(0, max_waves);
        GameObject enemy_temp;
        Vector3 spawnPosition;
        int enemyNumber;

        float prob = Random.value;

        if (prob < 0.5) enemyNumber = 0;
        else if (prob < 0.7) enemyNumber = 1;
        else enemyNumber = 2;

        for (int i = 0; i <= waves; i++)
        {

            if (enemyNumber == 0) spawnPosition.x = transform.position.x + Random.Range(minX, maxX);
            else spawnPosition.x = transform.position.x + Random.Range(minX + 10, maxX - 10);
            spawnPosition.y = height;
            spawnPosition.z = limit_height.transform.position.z;


            enemy_temp = (GameObject)Instantiate(enemy[enemyNumber], spawnPosition, new Quaternion(0,0,0,0),transform.parent);
            enemy_temp.layer = gameObject.layer;
            if (enemyNumber == 1) break;
        }
    }
}

