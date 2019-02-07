using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bobberController : MonoBehaviour
{
    public GameObject ropeEndRef;
    public GameObject ropeOriginRef;
    public GameObject playerRef;
    AudioSource ohYeahSource;
    GameObject attachedFishRef;
    private Vector3 offset;
    public bool fishAttached;

    int plainFishScore = 5;
    int sharkScore = 15;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Bobber Created");
        // Calculate offset
        offset = transform.position - ropeEndRef.transform.position;
        fishAttached = false;
        ohYeahSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //Set to the rope's end point
        transform.position = ropeEndRef.transform.position + offset;

        // If you are holding a fish and reel it up
        if ((ropeOriginRef.transform.localScale.y < 0.4f) && (fishAttached == true))
        {
            fishAttached = false;
            if (attachedFishRef != null && attachedFishRef.tag == "plainFish")
            {
                // Turn the fish off
                attachedFishRef.SetActive(false);
                // Increment Player Score
                playerRef.GetComponent<fisherController>().updateScore(plainFishScore);

            }
            else if (attachedFishRef != null && attachedFishRef.tag == "Shark")
            {
                ohYeahSource.Play();
                // Turn the fish off
                attachedFishRef.SetActive(false);
                // Increment Player Score
                playerRef.GetComponent<fisherController>().updateScore(sharkScore);

            }

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Bobber Hit Something!");
        if (fishAttached != true) // If there is already a fish attached don't get another
        { 
            if (collision.gameObject.tag == "plainFish")
            {
                attachedFishRef = collision.gameObject;
                Debug.Log("Fish Hit");
                fishAttached = true;
            }
            if (collision.gameObject.tag == "Shark")
            {
                attachedFishRef = collision.gameObject;
                Debug.Log("Shark hit");
                fishAttached = true;
            }
        }
    }
}
