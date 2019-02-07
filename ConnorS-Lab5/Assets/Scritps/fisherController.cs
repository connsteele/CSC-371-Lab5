using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fisherController : MonoBehaviour
{
    public Text scoreString;
    private Rigidbody2D rb2dref;
    public int playerScore;
    public bool canMoveL = true;
    public bool canMoveR = true;
    AudioSource dingSFX;

    // Start is called before the first frame update
    void Start()
    {
        // Get the prefab's instanced components
        rb2dref = GetComponent<Rigidbody2D>();
        playerScore = 0;
        scoreString.text = "Player Score: " + playerScore.ToString();
        dingSFX = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        // Check to see if the position should be updated
        float horzMove = Input.GetAxis("Horizontal");
        float xMove = 5.0f;
        float interpHorzPos;


        if (horzMove > 0 && canMoveR == true) // Positive movement
        {
            if (transform.localScale.x > 0)
            {
                // Flip the sprite direction
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }
            
            // Update the horizontal position in +x direction
            interpHorzPos = Mathf.Lerp(rb2dref.position.x, rb2dref.position.x + xMove, Time.deltaTime * 0.25f);
            rb2dref.position = new Vector2(interpHorzPos, rb2dref.position.y); // update the position to the interpolated one 

        }
        else if (horzMove < 0 && canMoveL == true) // Negative movement
        {
            if (transform.localScale.x < 0)
            {
                // Flip the sprite direction
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }
            // Update the horizontal position in -x direction
            interpHorzPos = Mathf.Lerp(rb2dref.position.x, rb2dref.position.x - xMove, Time.deltaTime * 0.25f);
            rb2dref.position = new Vector2(interpHorzPos, rb2dref.position.y); // update the position to the interpolated one 
        }


    }

    public void updateScoreUI()
    {
        scoreString.text = "Player Score: " + playerScore.ToString();
    }

    public void updateScore(int pts)
    {
        playerScore += pts;
        updateScoreUI();
        Debug.Log("Player Score is: " + playerScore);
        dingSFX.Play();
    }
}
