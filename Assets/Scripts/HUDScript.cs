using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUDScript : MonoBehaviour
{

    private CanvasRenderer pauseScreen;

    // Use this for initialization
    void Start()
    {
        pauseScreen = transform.FindChild("PauseScreen").gameObject.GetComponent<CanvasRenderer>();
        pauseScreen.SetAlpha(0);

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Pause"))
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
