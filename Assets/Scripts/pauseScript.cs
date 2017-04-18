using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/// <summary>
/// Script to Pause game
/// Handles Menu popping selection and popping up
/// </summary>
public class pauseScript : MonoBehaviour {

    public GameObject player; //player object
    public GameObject pause; //Pause objects
    public Canvas pauseCanvas; //Pause Canvas
    public Button yes; //Button to quit
    public Button no; //Button to resume
    public Image pauseBG; //Menu Background
    public Image pauseMenu; //Menu Background
    private bool isPaused; //Tell the script if its paused or not

	// Use this for initialization
	void Start () {
        isPaused = false;
        pauseCanvas.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
        }

    //Game shows pause menu when when pause bool is true
    if (isPaused)
        {
           
            pauseCanvas.enabled = true;
            player.GetComponent<PlayerShoot>().enabled = false;
            player.GetComponent<Player>().enabled = false;
            //player.active = false;
            Time.timeScale = 0;
        }

    //Otherwise pause menu does not show
    else
        {

            pauseCanvas.enabled = false;

            player.GetComponent<PlayerShoot>().enabled = true;
            player.GetComponent<Player>().enabled = true;
            //player.active = true;
            Time.timeScale = 1;
        }
	}

    //Quits if you select the yes button
   public void Yes()
    {
        Application.Quit();
    }

    //resumes if you press no
    public void No()
    {

        isPaused = false;
    }
}
