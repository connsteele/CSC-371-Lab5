﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishSpawnControl : MonoBehaviour
{
    public GameObject plainFishRef, radiationRef;
    public GameObject sharkRef;
    private BoxCollider2D colldr;
    public float spawnRateplainFish, nextPF;
    public float spawnRateSharks, nextShark;
    public float spawnRateRad, nextRad;
    Vector2 locSpawn;
    float randY;
    

    // Start is called before the first frame update
    void Start()
    {
        nextPF = 0f; // Get ready to spawn an enemy
        nextShark = 3f;
        nextRad = 0f;
        spawnRateplainFish = 5.0f; // How long to wait between spawns
        spawnRateRad = 6.0f; //How long to wait for next rad
        spawnRateSharks = 12.0f;
        colldr = GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 spawnPos;
        // Spawn Fish and Radiation
        if (Time.time > nextPF)
        {
            nextPF = Time.time + spawnRateplainFish;
            spawnPos = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            spawnPos = transform.TransformPoint(spawnPos * 0.5f);
            Instantiate(plainFishRef, spawnPos, transform.rotation);

        }
        if (Time.time > nextShark)
        {
            nextShark = Time.time + spawnRateSharks;
            spawnPos = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            spawnPos = transform.TransformPoint(spawnPos * 0.5f);
            Instantiate(sharkRef, spawnPos, transform.rotation);
        }
        if (Time.time > nextRad)
        {
            nextRad = Time.time + spawnRateRad;
            spawnPos = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            spawnPos = transform.TransformPoint(spawnPos * 0.5f);
            Instantiate(radiationRef, spawnPos, transform.rotation);

        }
    }
}
