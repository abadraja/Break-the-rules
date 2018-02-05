using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Save : MonoBehaviour
{
    public void SaveCheckPoint()
    {
        Scene scene = SceneManager.GetActiveScene();

        PlayerPrefs.SetFloat("PlayerX", transform.position.x);
        PlayerPrefs.SetFloat("PlayerY", transform.position.y);
        PlayerPrefs.SetString("SceneName", scene.name);
    }

    public void LoadCheckPoint()
    {
        float x = PlayerPrefs.GetFloat("PlayerX");
        float y = PlayerPrefs.GetFloat("PlayerY");

        Debug.Log("X = " + PlayerPrefs.GetFloat("PlayerX"));
        Debug.Log("Y = " + PlayerPrefs.GetFloat("PlayerY"));
        Debug.Log("S = " + PlayerPrefs.GetString("SceneName"));


        if (x == 0 && y == 0)
            Application.LoadLevel("Tutorial");
        else
        {
            Application.LoadLevel(PlayerPrefs.GetString("SceneName"));
            transform.position = new Vector3(x, y, 10);
        }
    }
}
