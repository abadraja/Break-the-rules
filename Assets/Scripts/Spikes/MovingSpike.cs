using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingSpikes : MonoBehaviour
{
    public GameObject SpikeGameObject;
    public Transform TargetToStop;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            Instantiate(SpikeGameObject, TargetToStop.position,
                TargetToStop.rotation);
        }
    }
}
