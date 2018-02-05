using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public PlayerController Player;

    public bool IsFollowing;

    public float XoffSet;
    public float YoffSet;

    void Start ()
    {
        XoffSet = 0;
        YoffSet = 2;

	    Player = FindObjectOfType<PlayerController>();

	    IsFollowing = true;
	}
	
	
	void Update ()
    {
		if (IsFollowing)
            transform.position = new Vector3(Player.transform.position.x + XoffSet, Player.transform.position.y + YoffSet, transform.position.z);    
    }
}
