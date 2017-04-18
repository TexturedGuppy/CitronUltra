using UnityEngine;
using System.Collections;

/// <summary>
/// Handles the player shooting the cans of monster at his enemies!
/// </summary>
public class PlayerShoot : MonoBehaviour {
    public GameObject[] monsters; //Handles all the different types of monster
    public GameObject leftCannon; //Location of end of gun when facing left.
    public GameObject rightCannon; //Location of the end of gun when facing right.
    public float canPower; //Power of can being fired
    public float canTorque; //Torque on the can
    public float canDestroyT; //Time before can disappears

    private SpriteRenderer sp;
	// Use this for initialization
	void Start () {
        sp = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
    /// <summary>
    /// Handles the flipping of sprites and shooting the cans
    /// each can comes out with a random torque to promote maximum can bouncing
    /// </summary>
	void Update () {
	if (Input.GetMouseButtonDown(0))
        {
            if (sp.flipX)
            {
                GameObject monsterFire = (GameObject)Instantiate(monsters[Random.Range(0, 4)], rightCannon.transform.position, transform.rotation);
                monsterFire.GetComponent<Rigidbody2D>().AddForce(new Vector2(canPower,0));
                monsterFire.GetComponent<Rigidbody2D>().AddTorque(Random.Range(-canTorque,canTorque));
                DestroyObject(monsterFire, canDestroyT);

            }
            else
            {
                GameObject monsterFire = (GameObject)Instantiate(monsters[Random.Range(0, 4)], leftCannon.transform.position, transform.rotation);
                monsterFire.GetComponent<Rigidbody2D>().AddForce(new Vector2(-canPower, 0));
                DestroyObject(monsterFire, canDestroyT);

            }


        }
	}

    
}
