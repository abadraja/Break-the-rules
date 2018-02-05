using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigTunnelOfSpikes : MonoBehaviour
{
    public bool _playerEntered;
    public GameObject SpikeGameObject;
    public GameObject Target;

    public float FireRate = 0.5F;
    private float _nextFire = 0.0F;

    void Update ()
    {
        if(Time.time > _nextFire)
        {
            if (_playerEntered)
	        {
	            Instantiate(SpikeGameObject, Target.transform.position +
                    new Vector3(0f, Mathf.RoundToInt(Random.Range(-1f,1f)), 0f),
	                Target.transform.rotation);
            }
            _nextFire = Time.time + FireRate;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        { _playerEntered = true; }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Player")
            _playerEntered = false;
    }
}
