using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stopMoveL : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<fisherController>().canMoveL = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<fisherController>().canMoveL = true;
        }
    }
}
