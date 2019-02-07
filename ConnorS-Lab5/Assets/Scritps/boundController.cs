using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boundController : MonoBehaviour
{
    GameObject fishRef;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "plainFish")
        {
            fishRef = collision.gameObject;
            // Flip the fishes horziontal move direction
            fishRef.GetComponent<plainFishController>().flipFishDir();
        }
        else if (collision.gameObject.tag == "Shark")
        {
            fishRef = collision.gameObject;
            // Flip the fishes horziontal move direction
            fishRef.GetComponent<sharkController>().flipFishDir();
        }
    }
}
