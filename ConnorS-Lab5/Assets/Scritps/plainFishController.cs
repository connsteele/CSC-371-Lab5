using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plainFishController : MonoBehaviour
{
    GameObject bobberRef;
    public bool attachToBob = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (bobberRef != null && attachToBob == true)
        {
            transform.position = bobberRef.transform.position;
        }
    }

    // Called by the bobberController Script
    public void flyUp()
    {
        Debug.Log("Fly up!");
        //transform.position = bobberRef.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("plain fish trigger went off");
        if (collision.gameObject.tag == "bobber")
        {
            Debug.Log("Contacted the bobber");
            attachToBob = true;
            bobberRef = collision.gameObject;
        }
    }
}
