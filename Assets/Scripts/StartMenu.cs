using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


//Script Handling the open the scene of the game
//Tutorial given by Xenosmash Games
//https://www.youtube.com/watch?v=pT4uca2bSgc

/// <summary>
/// Handles all the functionality of the start screen
/// </summary>
public class StartMenu : MonoBehaviour {
    //Variables
    public Canvas quitMenu;
    public Button startText;
    public Button exitText;
    public string levelSelect;

	// Use this for initialization
	void Start ()
    {
        quitMenu = quitMenu.GetComponent<Canvas>();
        startText = startText.GetComponent<Button>();
        exitText = exitText.GetComponent<Button>();

        quitMenu.enabled = false;
	}
	// Update is called once per frame
	void Update () {
	
	}

    //Method for the exit button once you press it
    //Makes sure little window asking are you sure works properly with other buttons
    public void ExitPress()
    {
        quitMenu.enabled = true;
        startText.enabled = false;
        exitText.enabled = false;
    }

    //Method for the little menu to interact properly
    public void NoPress()
    {
        quitMenu.enabled = false;
        startText.enabled = true;
        exitText.enabled = true;
    }

    //Starts the first level of the game once you press start
    public void StartLevel()
    {
      
        SceneManager.LoadScene(levelSelect);
    }

    //Once you press quit, and then press that you're sure, will exit the game.
    public void ExitGame()
    {
        Application.Quit();
    }
}
