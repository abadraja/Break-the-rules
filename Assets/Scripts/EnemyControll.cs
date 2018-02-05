using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControll : MonoBehaviour
{

    public float MoveSpeed;

    public bool MoveRight;

    public Transform WallCheck;
    public float WallCheckRadius;
    public LayerMask WhatIsWall;
    private bool _hittingWall;

    private bool _atEdge;
    public Transform EdgeCheck;
 
    void Start ()
	{
	    MoveSpeed = 3f;
	    MoveRight = true;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    _hittingWall = Physics2D.OverlapCircle(WallCheck.position, WallCheckRadius, WhatIsWall);

        _atEdge = Physics2D.OverlapCircle(EdgeCheck.position, WallCheckRadius, WhatIsWall);

        if (_hittingWall || !_atEdge)
	        MoveRight = !MoveRight;

	    if (MoveRight)
	    {
            transform.localScale = new Vector3(-1f,1f,1f);
	        GetComponent<Rigidbody2D>().velocity = new Vector2(MoveSpeed, GetComponent<Rigidbody2D>().velocity.y);
	    }
	    else
	    {
	        transform.localScale = new Vector3(1f, 1f, 1f);
            GetComponent<Rigidbody2D>().velocity = new Vector2(-MoveSpeed, GetComponent<Rigidbody2D>().velocity.y);
	    }
	}
}
