using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// Handles all the players HP
/// Handles screen flash when taking damage
/// Handles the Healthbar slider moving
/// </summary>
public class PlayerHP : MonoBehaviour {
    public int sHealth = 100; //starting hp
    public int cHealth; //current hp
    public Slider hSlider; //UI slider
    public Image flashImage; //Flashes screen red
    public AudioClip dClip; //sound when player dies
    public float fSpeed = 5f; //How fast the image flashes
    public Color flashColor = new Color(1f, 0f, 0f, 0.1f); //Color and Alpha of flash
    public Canvas deadCanvas; //Death Menu

    private GameObject gameScript; //Global gamescripts
    private GameObject player; //Player object
    private Animator animator; //animator for player
    private AudioSource playerAudio; //Audio for player
    private bool bDead; //Dead boolean for checking
    private bool bDamage; //Boolean for damage checking
	// Use this for initialization
	void Start () {
        gameScript = GameObject.Find("GameScript");
        player = GameObject.Find("Player");
        bDead = false;
        animator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        cHealth = sHealth;
        deadCanvas.enabled = false;

    }

    // Update is called once per frame
    void Update () {
        isPlayerDead(); //Checks every frame to see if the player is dead
       
        if (bDamage)
        {
            flashImage.color = flashColor;
            bDamage = false;
            

        }
        else
        {
            flashImage.color = Color.Lerp(flashImage.color, Color.clear, fSpeed * Time.deltaTime);
        }


        //Debug.Log("bDamage is " + bDamage);
	}

    /// <summary>
    /// Anytime the player takes damage, it is routed through this function
    /// This function takes in the amount of damage
    /// Once the damage makes it through, it lowers the slider by how much specified, plays damage audio
    /// </summary>
    /// <param name="damage"></param>
    public void takeDamage(int damage)
    {
        bDamage = true;

        cHealth -= damage;
        hSlider.value = cHealth;
        playerAudio.Play();
        if (cHealth <= 0 && !bDead)
        {
            PlayerDead();
        }
    }

    /// <summary>
    /// Once player has it 0 or less hp, this function is called,
    /// Sets the death boolean to true
    /// </summary>
    void PlayerDead()
    {
        bDead = true;
        Debug.Log("Player Died!");
        playerAudio.clip = dClip;
        playerAudio.Play();

    }

    /// <summary>
    /// Once Death Boolean is set to true, function is called
    /// stops game completely and brings up menu asking if player wants to restart or not
    /// </summary>
    void isPlayerDead()
    {
        if (cHealth <= 0)
        {
            gameScript.active = false;
            Time.timeScale = 0;
            player.GetComponent<PlayerShoot>().enabled = false;
            player.GetComponent<Player>().enabled = false;
            deadCanvas.enabled = true;
        }
    }
}
