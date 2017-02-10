using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    private Rigidbody rb;
    public float speed = 1000;
    public GameObject bullet;
    public float health = 2;
    public bool arOrientation;
    public int scoreValue = 10;
    private Vector3 direction;
    public ParticleSystem explosion;

	// Use this for initialization
	void Start () {
        if (arOrientation) direction = Vector3.down;
        else direction = Vector3.back + new Vector3(Random.Range(-1,1),0,0);
        rb = GetComponent<Rigidbody>();
        rb.AddForce(direction * speed);
    }
	 
	// Update is called once per frame
	void Update () {
	    
	}

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Finish" || col.gameObject.tag == "Player") Die(false);
        else if (col.gameObject.tag == "Bullet") Damage();
    }

    void Die(bool diedByPlayer)
    {
        GameObject player = GameObject.FindGameObjectsWithTag("Player")[0];
        if (diedByPlayer) player.GetComponent<PlayerScore>().increaseScore(scoreValue);
        ParticleSystem tempExplosion =  (ParticleSystem)Instantiate(explosion,transform.position,Quaternion.identity);
        Destroy(tempExplosion, tempExplosion.duration);
        Destroy(gameObject);
    }

    public void Damage()
    {
        health--;
        if (health == 0) Die(true);
    }

    
}
