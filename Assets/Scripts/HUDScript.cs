using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUDScript : MonoBehaviour
{

    private CanvasRenderer pauseScreen;
    private CanvasRenderer gameOverScreen;
    private bool gameover = false;


    // Use this for initialization
    void Start()
    {
        pauseScreen = transform.FindChild("PauseScreen").gameObject.GetComponent<CanvasRenderer>();
        pauseScreen.SetAlpha(0);

        gameOverScreen = transform.FindChild("GameOverScreen").gameObject.GetComponent<CanvasRenderer>();
        gameOverScreen.SetAlpha(0);
    }

    public void gameOver()
    {
        gameOverScreen.SetAlpha(1);
        gameOverScreen.GetComponent<AudioSource>().Play();
        Time.timeScale = 0;
        gameover = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            if (gameover)
            {
                Time.timeScale = 1;
                pauseScreen.SetAlpha(0);
                gameOverScreen.SetAlpha(0);
                gameover = false;
                UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
            }
            else
            {
                if (Time.timeScale > 0)
                {
                    Time.timeScale = 0;
                    pauseScreen.SetAlpha(1);
                }

                else
                {
                    Time.timeScale = 1;
                    pauseScreen.SetAlpha(0);
                }
            }
        }
    }
}
