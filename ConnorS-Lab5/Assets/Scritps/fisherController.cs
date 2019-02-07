using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fisherController : MonoBehaviour
{
    private Rigidbody2D rb2dref;

    // Start is called before the first frame update
    void Start()
    {
        // Get the prefab's instanced components
        rb2dref = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        // Check to see if the position should be updated
        float horzMove = Input.GetAxis("Horizontal");
        float xMove = 2.0f;
        if (horzMove > 0) // Positive movement
        {
            //Vector2 moveForce = new Vector2(xMove, 0);
            //rb2dref.AddForce(moveForce);
            float interpHorzPos = Mathf.Lerp(rb2dref.position.x, rb2dref.position.x + xMove, Time.deltaTime);
            rb2dref.position = new Vector2(interpHorzPos, rb2dref.position.y); // update the position to the interpolated one 

        }
        else if (horzMove < 0) // Negative movement
        {
            //Vector2 moveForce = new Vector2(-xMove, 0);
            //rb2dref.AddForce(moveForce);
            rb2dref.position = new Vector2(rb2dref.position.x - xMove, rb2dref.position.y); // update the position
        }
        //Vector2 moveForce = new Vector2(xMove, 0);
        //rb2dref.velocity = Vector2.zero;
        //rb2dref.AddForce(moveForce);

    }
}
