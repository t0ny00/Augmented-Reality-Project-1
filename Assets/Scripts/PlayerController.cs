using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public int health = 3;
    public GameObject cannon1, cannon2;
    public GameObject bullet;
    private Renderer render;
    public bool invulnerable;
    public int fire_rate = 10;
    private int fire_timer = 0;
    public float speed = 50f;
    public int numBullets = 15;
    private int bulletCounter;
    public Text lifeText;
    public Text bulletCounterText;
    public float reloadSpeed = 5;
    private float timeSinceLastShot;
	// Use this for initialization
	void Start () {
        render = GetComponent<Renderer>();
        bulletCounter = numBullets;
        lifeText.text = "Lifes: " + health.ToString();
        bulletCounterText.text = "Bullets: " + bulletCounter.ToString();
    }
	
	// Update is called once per frame
	void Update () {

        var x = Input.GetAxis("Horizontal") * Time.deltaTime *speed;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        transform.Translate(x, 0, z);


        if (Input.GetKey("space"))
        {
            if (fire_timer >= fire_rate && bulletCounter > 0) 
            {
                Shoot();
                fire_timer = 0;
                bulletCounter--;
                bulletCounterText.text = "Bullets: " + bulletCounter.ToString();
                timeSinceLastShot = Time.time;
            }
            else if (bulletCounter == 0) StartCoroutine("Reload",reloadSpeed);
        }

        if (Time.time - timeSinceLastShot > 1.5 && bulletCounter > 0) StartCoroutine("Reload", 0);

        fire_timer++;
        if (fire_timer == fire_rate + 1) fire_timer = 0;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Enemy" && !invulnerable)
        {
            health--;
            lifeText.text = "Lifes: " + health.ToString();
            invulnerable = true;
            if (health == 0) Die();
            else
            {
                
                StartCoroutine("Flash");
                
            }
        }
    }

    public void Die()
    {
        gameObject.SetActive(false);
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
    IEnumerator Reload(float reloadSpeed)
    {
        yield return new WaitForSecondsRealtime(reloadSpeed);
        bulletCounter = numBullets;
        bulletCounterText.text = "Bullets: " + bulletCounter.ToString();
    }
}
