using UnityEngine;
using System.Collections;

public class Enemy2 : MonoBehaviour {

    public float speed = 50 ;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.Translate(Vector3.back * speed);
	}

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Finish" ) Destroy(gameObject);
        
    }

}
