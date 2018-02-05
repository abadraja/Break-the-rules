using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject currentCheckpoint;

    private PlayerController player;

    public GameObject deathParticle;
    public float respawnDelay;

    private float gravityStore;

    private CameraController camera;

	void Start ()
    {
        respawnDelay = 0.4f;
        player = FindObjectOfType<PlayerController>();
        camera = FindObjectOfType<CameraController>();
    }

    public void RespawnPlayer()
    {

        StartCoroutine("RespawnPlayerCor");
    }

    public IEnumerator RespawnPlayerCor()
    {
        GetComponent<AudioSource>().Play();

        Instantiate(deathParticle, player.transform.position, player.transform.rotation);
        player.enabled = false;
        player.moveSpeed = 0;
        player.GetComponent<Renderer>().enabled = false;
        camera.IsFollowing = false;
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero; // to disable after kill movement
        Debug.Log("Saved!");
        yield return new WaitForSeconds(respawnDelay);
        player.transform.position = currentCheckpoint.transform.position;
        Debug.Log("respawn!");
        player.moveSpeed = 5f;
        player.enabled = true;
        camera.IsFollowing = true;
        player.GetComponent<Renderer>().enabled = true;
    }
}
