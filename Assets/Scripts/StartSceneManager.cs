using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// handles our start scene, so that when we press the space bar we load the next scene
public class StartSceneManager : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // if space is pressed...
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // load the next scene
            SceneManager.LoadScene("PlayScene");
        }
    }
}
