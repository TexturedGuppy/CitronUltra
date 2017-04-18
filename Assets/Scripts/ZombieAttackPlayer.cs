using UnityEngine;
using System.Collections;

/// <summary>
/// Script that handles the zombie's attacking of the player
/// Also handles the zombie moving towards the player
/// </summary>
public class ZombieAttackPlayer : MonoBehaviour {
    private GameObject player;
    public float speed;
    public int attack = 10;
    public float jump = 5f;


    private Vector3 leftRight;
    private Animator animator;
    private Rigidbody2D rb;
    private PlayerHP  playerHP;
    private Rigidbody2D playerRB;

    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player");
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        playerHP = player.GetComponent<PlayerHP>();
        playerRB = player.GetComponent<Rigidbody2D>();


    }

    // Update is called once per frame
    void Update () {
        //target = target.position;
        float step = speed * Time.deltaTime; //Zombie Run Speed
        if (Vector3.Distance(transform.position, player.transform.position) < 3f)
        {
            leftRight = transform.position - player.transform.position; //Finds where player is according to zombie

            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step); //Tells zombie to move toward player

            //All the animation controls
            animator.SetBool("isWalking", true);
           
            if(leftRight.y < -.8)
            {
            rb.AddForce(new Vector2(0,jump));
                animator.SetBool("isJumping", true);
            }
            else
                animator.SetBool("isJumping", false);
            if (leftRight.x > 0)
            {
                GetComponent<SpriteRenderer>().flipX = true;

            }
            else
            {

                GetComponent<SpriteRenderer>().flipX = false;
            }



        }
        else
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("isJumping", false);
        }


        //Debug.Log(player.transform.position);

	}

    /// <summary>
    /// If the zombie runs into the player, it attacks him
    /// </summary>
    /// <param name="col"></param>
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {

            
            playerHP.takeDamage(attack);
        }
    }
}
