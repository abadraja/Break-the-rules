using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorIsLava : MonoBehaviour {

    public float DisapearTime = 2F;
    public float AirTime = 0.5F;
    private float _countDown1 = 0.2F;
    private float _countDown2 = 0.5F;     // hui znaet ce fac valorile astea, dar o data la 3 secunde dispare pe o secunda :)
    public Vector3 InitialCoordinates;

    void Start ()
    {
		
	}
	
	void Update ()
    {
        if (Time.time > _countDown1)
        {
            transform.position = new Vector3(-110, -100, 0);
            _countDown1 = Time.time + DisapearTime;
        }
        if (Time.time > _countDown2)
        {
            transform.position = InitialCoordinates;
            _countDown2 = Time.time + AirTime;
        }
    }
}
