using UnityEngine;
using System.Collections;

public class CanvasScript : MonoBehaviour {

    public GameObject player;

    private Animator anim;
	
    // Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (player.GetComponent<PlayerController>().health == 0)
        {
            anim.SetTrigger("GameOverCover");
        }
	
	}
}
