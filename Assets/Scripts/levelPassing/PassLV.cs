using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassLV : MonoBehaviour
{

    private bool _playerInZone;

    public string levelToLoad;

    void Start()
    {
        _playerInZone = false;
    }

    void Update()
    {
        if (_playerInZone)
        {
            Application.LoadLevel(levelToLoad);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            _playerInZone = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            _playerInZone = false;
        }
    }
}
