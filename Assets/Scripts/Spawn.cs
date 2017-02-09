using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {
    public GameObject enemy;
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
        if (Input.GetKey("w")) Debug.Log("holaaa");
	}

    void SpawnEnemy()
    {
        int waves = Random.Range(0, max_waves);
        GameObject enemy_temp;
        for (int i = 0; i <= waves; i++)
        {
           
            enemy_temp = (GameObject)Instantiate(enemy, new Vector3(transform.position.x + Random.Range(limit_left.transform.position.x, limit_right.transform.position.x), 
                                                 limit_height.transform.position.y, transform.position.z), new Quaternion(0,0,0,0),transform.parent);
            enemy_temp.layer = gameObject.layer;
            
        }
    }
}

