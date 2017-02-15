using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour {

    public AudioSource theme;
    public GameObject scene;
    private bool playingMusic = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
            if (Input.GetKeyDown("r"))  SceneManager.LoadScene(SceneManager.GetActiveScene().name);

            if (!playingMusic && scene.activeInHierarchy)
            {
                theme.Play();
                playingMusic = true;
            }
            else if (playingMusic && !scene.activeInHierarchy)
            {
            theme.Pause();
            playingMusic = false;
        }
    }
}
