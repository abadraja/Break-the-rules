using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangingGravity : MonoBehaviour {

    float _gravity = -0.01f;
    public bool IsNormalGravity;

    void Update()
    {
        if (!IsNormalGravity)
            transform.position += new Vector3(-0.2f, 0, 0);
        else
        {
            transform.position += new Vector3(0, -0.2f, 0);
        }
    }
}
