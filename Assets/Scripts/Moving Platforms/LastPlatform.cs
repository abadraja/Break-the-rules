using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastPlatform : MonoBehaviour {

    public float moveSpeed;
    public bool isPlayer;
    public GameObject Target;
    public GameObject Platform;

    void Start ()
    {
        isPlayer = false;
    }

    void Update()
    {
        if (isPlayer)
            Platform.transform.position =
            Vector3.MoveTowards(Platform.transform.position, Target.transform.position, Time.deltaTime * moveSpeed);
    
}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
            isPlayer = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        isPlayer = false;
    }

}
