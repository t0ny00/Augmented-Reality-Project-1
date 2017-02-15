using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    private Rigidbody rb;
    public bool invulnerable;
    public float speed = 1000;
    public GameObject bullet;
    public float health = 2;
    public bool arOrientation;
    public int scoreValue = 10;
    private Vector3 direction;
    public ParticleSystem explosion;
    public bool randomDirection;
  

	// Use this for initialization
	void Start () {
        if (arOrientation) direction = Vector3.down;
        else direction = Vector3.back;
        if (randomDirection) direction += new Vector3(Random.Range(-0.5f, 0.5f), 0, 0);
        rb = GetComponent<Rigidbody>();
        rb.AddForce(direction * speed);
        

    }
	 
	// Update is called once per frame
	void Update () {
	    
	}

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Finish" || col.gameObject.tag == "Player") Die(false);
        else if ((col.gameObject.tag == "Bullet") && !invulnerable) Damage();
    }

    void Die(bool diedByPlayer)
    {
        GameObject[] player = GameObject.FindGameObjectsWithTag("Player");
        if (diedByPlayer && player.Length > 0) player[0].GetComponent<PlayerScore>().increaseScore(scoreValue);
        ParticleSystem tempExplosion =  (ParticleSystem)Instantiate(explosion,transform.position,Quaternion.identity,transform.parent);
        //Destroy(tempExplosion, tempExplosion.duration);
        Destroy(gameObject);
    }

    public void Damage()
    {
        health--;
        if (health == 0) Die(true);
    }

    
}
