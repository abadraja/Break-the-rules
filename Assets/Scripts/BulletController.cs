using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    public float Speed;

    public PlayerController Player;
    public GameObject EnemyDeathEffect;
    public GameObject ImpactEffect;

	void Start ()
	{
	    Speed = 8f;
        Player = FindObjectOfType<PlayerController>();

	    if (Player.transform.localScale.x < 0)
	        Speed = -Speed;

	}
	
	
	void Update ()
	{
	    GetComponent<Rigidbody2D>().velocity = new Vector2(Speed, GetComponent<Rigidbody2D>().velocity.y);
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Instantiate(EnemyDeathEffect, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);
        }
        Instantiate(ImpactEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
