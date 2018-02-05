using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorPlatforms : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            Destroy(gameObject);
        }
    }
}
