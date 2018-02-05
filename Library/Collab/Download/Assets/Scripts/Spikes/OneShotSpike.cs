using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneShotSpike : MonoBehaviour
{

    public bool HasEnteredCollider;
    public GameObject Target;
    public GameObject Spike;
    public PlayerController Player;
    private Vector3 _startPosition;

	void Start ()
	{
	    _startPosition = Spike.transform.position;
	}
	
	void Update ()
	{
	    if (HasEnteredCollider)
	        Spike.transform.Translate(new Vector3(-Target.transform.position.x, 0, transform.position.z) * Time.deltaTime * 10f);
        if (!Player.enabled)
        {
            HasEnteredCollider = false;
            Spike.transform.position = _startPosition;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            HasEnteredCollider = true;
        }
    }
}
