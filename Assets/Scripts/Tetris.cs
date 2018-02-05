using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Tetris : MonoBehaviour
{
    public GameObject[] Tetrimons = new GameObject[5];
    public Vector3[] StartTetrimonsPosition = new Vector3[5];
    public PlayerController Player;

    public float FireRate = 0.2F;
    private float _nextFire = 0.0F;

    public bool PlayerDetected;

    void Start ()
    {
        var i = 0;
        while (i < Tetrimons.Length)
        {
            StartTetrimonsPosition[i] = Tetrimons[i].transform.position;
            i++;
        }
    }
	
	void Update ()
    {
        if (PlayerDetected)
        {
            var i = 0;
            while (i < Tetrimons.Length)
            {
                Tetrimons[i].GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX;
                Tetrimons[i].GetComponent<Rigidbody2D>().gravityScale = 1f;
                i++;
            }
        }
        else
        {
            var i = 0;
            while (i < Tetrimons.Length)
            {
                Tetrimons[i].transform.position = StartTetrimonsPosition[i];
                i++;
            }
        }

        if (!Player.enabled)
        {
            var i = 0;
            while (i < Tetrimons.Length)
            {
                Tetrimons[i].transform.position = StartTetrimonsPosition[i];
                Tetrimons[i].GetComponent<Rigidbody2D>().gravityScale = 0f;
                Tetrimons[i].GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                PlayerDetected = false;
                i++;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
            PlayerDetected = true;
    }
}
