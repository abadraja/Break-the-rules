using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingSpike : MonoBehaviour
{
    public GameObject SpikeGameObject;
    public Transform TargetToStop;
    public bool IsOneWay;
    public bool IsMoving;

    public float moveSpeed;

    private void Update()
    {
        if (IsMoving)
            SpikeGameObject.transform.position =
                Vector3.MoveTowards(TargetToStop.transform.position, transform.position, Time.deltaTime * moveSpeed);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player" && !IsOneWay)
        {
            Instantiate(SpikeGameObject, TargetToStop.position,
                TargetToStop.rotation);
            IsMoving = true;
        }
    }
}
