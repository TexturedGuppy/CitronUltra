using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// Basic score countdown
/// Wanted it to kind of be like the old platformers where you got more points based on time left when completed.
/// </summary>
public class Score : MonoBehaviour {

    public Text scoreText;
    public int score;

	// Use this for initialization
	void Start () {
        score = 6000;
        StartCoroutine("scoreCountdown");
	}
	
	// Update is called once per frame
	void Update () {
        scoreText.text = "Score: " + score;

    }

    /// <summary>
    /// Counts your score down as time moves on
    /// </summary>
    /// <returns></returns>
    public IEnumerator scoreCountdown()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(1);
            if (score > 0)
            {
                score -= 10;
            }

        }
    }
}
