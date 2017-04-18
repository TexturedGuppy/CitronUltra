using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/// <summary>
/// Handles what happens when the player dies
/// On death pauses game and gives player choice of restarting or not
/// </summary>
public class deadScript : MonoBehaviour {
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    /// <summary>
    /// if player selects yet
    /// Level restarts
    /// </summary>
    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    /// <summary>
    /// If player selects no
    /// sends player back to title menu
    /// </summary>
    public void noRestart()
    {
        SceneManager.LoadScene("StartScreen");
    }
}
