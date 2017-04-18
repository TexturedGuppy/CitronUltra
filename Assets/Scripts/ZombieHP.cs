using UnityEngine;
using System.Collections;

/// <summary>
/// This script handles the zombies HP
/// as well as what will actually hurt the zombie
/// as well as the death of the zombie
/// </summary>
public class ZombieHP : MonoBehaviour {

    public int hp;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        isZombieDead();
	}

    /// <summary>
    /// Checks to see if player bullets are hitting it
    /// </summary>
    /// <param name="col"></param>
    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Zombo script knows its being hit");

        if (col.gameObject.tag == "Bullet")
        {
            Debug.Log("Zombo is taking damage from cans");
            hp--;
        }
    }

    /// <summary>
    /// Checks to see if the zombie should be dead yet
    /// I.E. if his HP has hit zero
    /// </summary>
    void isZombieDead()
    {
       // Debug.Log("Zombo is updating yo");
        if (hp <= 0)
        {

            Destroy(gameObject);
        }
    }
}
