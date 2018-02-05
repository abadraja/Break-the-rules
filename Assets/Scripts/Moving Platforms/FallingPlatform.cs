using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    public bool isFalling;
    public Vector3 MaxHeight;

    void Update ()
    {
        if (transform.position.y < MaxHeight.y && !isFalling)
        {
            transform.Translate(new Vector3(0, MaxHeight.y, transform.position.z) * Time.deltaTime * 0.3f);
        }

        if (isFalling)
        {
            transform.Translate(new Vector3(0, -1, transform.position.z) * Time.deltaTime * 4f);
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            isFalling = true;
//            transform.Translate(new Vector3(transform.position.x, 0, transform.position.z) * Time.deltaTime);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        isFalling = false;
    }
}
