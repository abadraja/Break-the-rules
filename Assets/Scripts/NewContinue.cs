﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewContinue : MonoBehaviour {

    public void changemenuscene(string scenename)
    {
        Application.LoadLevel(scenename);
    }


}
