using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingOneWaySpikes : MonoBehaviour {

    public bool HasEnteredCollider;

    void Start () {
		
	}
	
	
	void Update () {
	    if (HasEnteredCollider)
	    {
	        transform.Translate(new Vector3(0,-1, 0) * Time.deltaTime * 35f);
	    } 
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
            HasEnteredCollider = true;
    }
}
