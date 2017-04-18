using UnityEngine;
using System.Collections;

/// <summary>
/// Simple killzone script that will kill player if they jump off the map
/// </summary>
public class Killzone : MonoBehaviour {
    int damage;
    GameObject player;
    PlayerHP playerHP;
	// Use this for initialization
	void Start () {
        damage = 1000; //set high to instantly kill player
        player = GameObject.Find("Player");
        playerHP = player.GetComponent<PlayerHP>();


    }

    // Update is called once per frame
    void Update () {
	
	}

    /// <summary>
    /// when the killzone and player collide it kills the player immediately
    /// </summary>
    /// <param name="col"></param>
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            playerHP.takeDamage(damage);
        }
    }
}
