﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraContoller : MonoBehaviour
{
    public GameObject player;
    public GameObject ropeEndRef;
    private Vector3 offset;         //Private variable to store the offset distance between the player and camera

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - ropeEndRef.transform.position;
    }


    void LateUpdate()
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        transform.position = ropeEndRef.transform.position + offset;
    }
}
