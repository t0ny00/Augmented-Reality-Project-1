using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScore : MonoBehaviour {

    private int score = 0;
    public Text countText;
    public GameObject myCanvas;
    

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void increaseScore(int value)
    {
        score += value;
        countText.text = "Score: " + score.ToString();
    }
}
