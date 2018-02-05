using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleShotsSpike : MonoBehaviour {

    public bool HasEnteredCollider;
    public GameObject Target;
    public GameObject Spike;
    private Vector3 _startPosition;

    public float FireRate = 0.002F;
    private float _nextFire = 0.0F;

    void Start ()
    {
        _startPosition = Spike.transform.position;
    }
	
	
	void Update ()
    {
        if (Time.time > _nextFire)
        {
            if (HasEnteredCollider)
	        Spike.transform.Translate(new Vector3(
                Target.transform.position.x, 0, 
                transform.position.z) * 
                Time.deltaTime * 1f);
	        else
	        {
	            Spike.transform.position = _startPosition;
            }
            _nextFire = Time.time + FireRate;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
            HasEnteredCollider = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Player")
            HasEnteredCollider = false;
    }
}
