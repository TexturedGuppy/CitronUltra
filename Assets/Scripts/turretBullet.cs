using UnityEngine;
using System.Collections;

public class turretBullet : MonoBehaviour {
    public float speed;
    public float lifeTime;
    public int damage;
    GameObject player;
    PlayerHP playerHP;
    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player");
        playerHP = player.GetComponent<PlayerHP>();

    }

    // Update is called once per frame
    void Update () {
        transform.Translate(new Vector3(Time.deltaTime * speed,0 , 0)); //when bullet spawns sends it flying in one direction at specified speed.
	}

    /// <summary>
    /// If bullet collides with the player
    /// player takes specified damage
    /// </summary>
    /// <param name="col"></param>
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            playerHP.takeDamage(damage);
        }
    }
}
