using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGunGO : MonoBehaviour {

    public GameObject EnemyBulletGO; 

	// Use this for initialization
	void Start () 
    {
        //fire an enemy bullet after 1 second
      //  Invoke("FireEnemyBullet", 1f);
	}
	
	// Update is called once per frame
	void Update () 
    {
        Invoke("FireEnemyBullet", 30f);
	}

    //Function to fire an enemy bullet
    void FireEnemyBullet()
    {
        //get a reference to the player's
        GameObject playership = GameObject.Find("Player");

        if (playership != null) //if the player is not dead
        {
            GameObject bullet = (GameObject)Instantiate(EnemyBulletGO);

            //set the bullet's initial position
            bullet.transform.position = transform.position;

            //compute the bullet's direction towards the player's ship
            Vector2 direction = playership.transform.position - bullet.transform.position;

            //set the bullet's direction
            bullet.GetComponent<EnemyBullet>().SetDirection(direction);
        }
    }
}
