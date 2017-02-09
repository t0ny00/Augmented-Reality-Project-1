using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    private Rigidbody rb;
    public float speed;
    public GameObject bullet;
    public float health = 2;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.down * speed);
	}
	 
	// Update is called once per frame
	void Update () {
	    
	}

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Finish" || col.gameObject.tag == "Player") Die();
        else if (col.gameObject.tag == "Bullet") Damage();
    }

    void Die()
    {
        Destroy(gameObject);
    }

    public void Damage()
    {
        health--;
        if (health == 0) Die();
    }

    
}
