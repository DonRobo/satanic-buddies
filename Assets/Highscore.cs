using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Highscore : MonoBehaviour {

    public int highscore = 0;
    public Text highscoreText;
	
	// Update is called once per frame
	void Update () {
        highscoreText.text = "Enemies killed: " + highscore;
	}
}
