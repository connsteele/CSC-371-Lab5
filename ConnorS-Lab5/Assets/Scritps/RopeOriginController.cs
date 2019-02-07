using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeOriginController : MonoBehaviour
{
    private float minYScale, maxYScale;
    float scaleRopeInc;
    Vector3 locSc;

    // Move to player
    public GameObject player;
    private Vector3 offset;
    public GameObject bobberRef;

    // Start is called before the first frame update
    void Start()
    {
        minYScale = 0.2f;
        maxYScale = 10.0f;
        scaleRopeInc = 0.025f;
        Vector3 locSc = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        /// Check to see if there's a fish on the line

        Vector3 locSc = transform.localScale;
        // Check to see if rope should go down
        float vertMove = Input.GetAxis("Vertical");
        if (vertMove > 0 && locSc.y >= minYScale)
        {
            transform.localScale = new Vector3(locSc.x, locSc.y - scaleRopeInc, locSc.z);
        }
        else if ((vertMove < 0) && (locSc.y <= maxYScale)) // Scale down
        {
            // Scale the parent object so the rope decends
            transform.localScale = new Vector3(locSc.x, locSc.y + scaleRopeInc, locSc.z);
        }
        
    }
}
