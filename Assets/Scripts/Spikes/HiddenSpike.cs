using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenSpike : MonoBehaviour
{

    public bool IsForeverInvisible;

    void Start()
    {
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player" && !IsForeverInvisible)
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        }
    }
}
