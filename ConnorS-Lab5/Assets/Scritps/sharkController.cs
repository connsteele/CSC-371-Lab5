using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sharkController : MonoBehaviour
{
    GameObject bobberRef;
    private Rigidbody2D rb2d;
    public bool attachToBob = false;
    float movedir = 1; // either 1 or -1, to flip directions
    private SpriteRenderer sprRndr;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Move new fishes on screen
        float moveSpeed = 2.0f;
        float interpHorzPos = Mathf.Lerp(transform.position.x, transform.position.x + (moveSpeed * movedir), Time.deltaTime);
        rb2d.position = new Vector2(interpHorzPos, transform.position.y);


        if (bobberRef != null && attachToBob == true)
        {
            transform.position = bobberRef.transform.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "bobber")
        {
            bobberRef = collision.gameObject;
            // Only attach to the bobber if nothing else is
            if (bobberRef.GetComponent<bobberController>().fishAttached != true)
            {
                attachToBob = true;
            }
            
            
        }
    }

    // My Funcs

    // Called by bound Controller
    public void flipFishDir()
    {
        movedir *= -1; // flip the movement dir
        sprRndr = GetComponent<SpriteRenderer>();
        sprRndr.flipX = !sprRndr.flipX; // Toggle the flip direction
    }
}
