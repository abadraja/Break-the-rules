using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteInstatiatingSpikes : MonoBehaviour
{
    public GameObject SpikeGameObject;
    public List<GameObject> ListOfSpikes;

    public float MinimalDelay;
    public float MaximumDelay;

    private float _nextFire = 0.0F;

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	    var fireRate = Random.Range(MinimalDelay, MaximumDelay);

        if (Time.time > _nextFire)
	    {

            foreach (var l in ListOfSpikes)
	        {
                Instantiate(SpikeGameObject, l.transform.position,
                    l.transform.rotation);
	        }
	        _nextFire = Time.time + fireRate;
	    }
    }
}
