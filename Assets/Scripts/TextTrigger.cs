using UnityEngine;
using System.Collections;

/// <summary>
/// Handles my basic chat bubbles when player gets in range of NPCs
/// </summary>
public class TextTrigger : MonoBehaviour {

    Canvas chatText;

	// Use this for initialization
	void Start () {
        chatText = GetComponentInChildren<Canvas>();
        chatText.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    /// <summary>
    /// Turns on chat bubble
    /// </summary>
    /// <param name="col"></param>
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        chatText.enabled = true;
    }
    /// <summary>
    /// Turns off chat bubble
    /// </summary>
    /// <param name="col"></param>
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        chatText.enabled = false;
    }
}

