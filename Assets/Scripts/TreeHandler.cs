using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TreeHandler : MonoBehaviour
{
    [SerializeField] Transform playerTransform; // our player's transform

    private void Start()
    {
        playerTransform = FindObjectOfType<PlayerController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        // if space is pressed...
        if (Vector2.Distance(playerTransform.position, transform.position) < 2)
        {
            // load the next scene
            SceneManager.LoadScene("StartScene");
        }
    }
}
