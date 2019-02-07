using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bobberController : MonoBehaviour
{
    public GameObject ropeEndRef;
    public GameObject ropeOriginRef;
    public GameObject playerRef;
    public GameObject fishSpawnerRef;
    public AudioClip onNoClip;
    public AudioClip ohYeahClip;
    AudioSource audSource;
    GameObject attachedFishRef;
    private Vector3 offset;
    public bool fishAttached;

    int plainFishScore = 5;
    int sharkScore = 15;
    int radScore = -5;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Bobber Created");
        // Calculate offset
        offset = transform.position - ropeEndRef.transform.position;
        fishAttached = false;
        audSource = GetComponent<AudioSource>();
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
            fishSpawnerRef.GetComponent<fishSpawnControl>().currentSpawns -= 1; // Subtract 1 from current spawned
            if (attachedFishRef != null && attachedFishRef.tag == "plainFish")
            {
                // Turn the fish off
                attachedFishRef.SetActive(false);
                // Increment Player Score
                playerRef.GetComponent<fisherController>().updateScore(plainFishScore);

            }
            else if (attachedFishRef != null && attachedFishRef.tag == "Shark")
            {
                //ohYeahSource.Play();
                audSource.clip = ohYeahClip;
                audSource.Play(); // Oh Yea
                // Turn the fish off
                attachedFishRef.SetActive(false);
                // Increment Player Score
                playerRef.GetComponent<fisherController>().updateScore(sharkScore);

            }
            else if (attachedFishRef != null && attachedFishRef.tag == "radiation")
            {
                audSource.clip = onNoClip;
                audSource.Play(); // Oh Yea
                // Turn the fish off
                attachedFishRef.SetActive(false);
                // Increment Player Score
                playerRef.GetComponent<fisherController>().updateScore(radScore);

            }

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Bobber Hit Something!");
        if (fishAttached != true) // If there is already a fish attached don't get another
        {
            attachedFishRef = collision.gameObject;
            if (collision.gameObject.tag == "plainFish")
            {
                //attachedFishRef = collision.gameObject;
                Debug.Log("Fish Hit");
                fishAttached = true;
            }
            if (collision.gameObject.tag == "Shark")
            {
                //attachedFishRef = collision.gameObject;
                Debug.Log("Shark hit");
                fishAttached = true;
            }
            if (collision.gameObject.tag == "radiation")
            {
                //attachedFishRef = collision.gameObject;
                Debug.Log("Radiation hit");
                fishAttached = true;
            }
        }
    }
}
