using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndLevel : MonoBehaviour {

    public string nextLevel; //Ease of use level naming for moving on to next level
    public float fadeSpeed; //Speed of fading out
    public Image blackFader; //Image that covers view screen
    Color temp; //Temporary color that allows you to change the color of a UI image (unity doesnt allow it directly?)
	// Use this for initialization
	void Start () {
        temp = blackFader.color;
        temp.a = 0;

        
	}
	
	// Update is called once per frame
	void Update () {
        blackFader.color = temp;
	}

    /// <summary>
    /// Trigger collider that starts coroutine
    /// </summary>
    /// <param name="col"></param>
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
            StartCoroutine(Fade());
    }

    /// <summary>
    /// Coroutine to fade screen out to black
    /// </summary>
    /// <returns></returns>
    IEnumerator Fade()
    {
        while (temp.a < 1)
        {
            temp.a += fadeSpeed;
            

            yield return null;//loop again the next frame

        }
        SceneManager.LoadScene(nextLevel);
    }

}
