using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    public float speed;
    private Rigidbody rb;
    

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        rb.AddRelativeForce(Vector3.forward * speed);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            col.gameObject.GetComponent<Enemy>().Damage();
            Destroy(gameObject);
        }
        else if (col.gameObject.tag == "Respawn") Destroy(gameObject); 
    }
}
