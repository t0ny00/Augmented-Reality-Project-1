using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public int health = 3;
    public GameObject cannon1, cannon2;
    public GameObject bullet;
    private Renderer render;
    public bool invulnerable;
    public int fire_rate = 10;
    private int fire_timer = 0;

	// Use this for initialization
	void Start () {
        render = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("space"))
        {
            if (fire_timer >= fire_rate)
            {
                Shoot();
                fire_timer = 0;
            }
        }
        fire_timer++;
        if (fire_timer == fire_rate + 1) fire_timer = 0;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Enemy" && !invulnerable)
        {
            health--;
            invulnerable = true;
            if (health == 0) Die();
            else
            {
                
                StartCoroutine("Flash");
                
            }
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    void Shoot()
    {
        Instantiate(bullet, cannon1.transform.position,new  Quaternion(0,0,0,0),transform.parent);
        Instantiate(bullet, cannon2.transform.position, new Quaternion(0, 0, 0, 0), transform.parent);
        
    }

    IEnumerator Flash()
    {
        GetComponent<Collider>().enabled = false;
        for (int i = 0; i < 5; i++)
        {
            render.enabled = false;
            yield return new WaitForSecondsRealtime(0.3f);
            render.enabled = true;
            yield return new WaitForSecondsRealtime(0.3f);
        }
        invulnerable = false;
        GetComponent<Collider>().enabled = true;
    }
}
