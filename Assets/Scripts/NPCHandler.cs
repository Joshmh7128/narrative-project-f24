using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Handles NPCs who stand and say things when we press space near them
/// </summary>
public class NPCHandler : MonoBehaviour
{
    [SerializeField] float interactionDistance; // how close does the player have to be in order for us to talk
    [SerializeField] string currentWords, words, newWords; // what are we saying? then, what are we saying when we get the key?
    [SerializeField] TextMeshProUGUI wordText; // the actualy words we are displaying
    [SerializeField] GameObject textParent; // the parent object of our text
    [SerializeField] KeyHandler keyHandler; // the handler for the key

    bool isTalking; // are we talking right now?

    Transform playerTransform;

    private void Start()
    {
        // get our player's transform to be used later
        playerTransform = FindObjectOfType<PlayerController>().transform;   
        // get our key handler
        keyHandler = FindObjectOfType<KeyHandler>();
        keyHandler.KeyPickup.AddListener(UpdateText);
        // setup the first thing we're saying
        currentWords = words;
    }

    private void FixedUpdate()
    {
        ProcessCheckTalk();
    }

    // run this to show text
    IEnumerator ProcessTalk()
    {
        isTalking = true;
        wordText.text = currentWords;
        textParent.SetActive(true);
        yield return new WaitForSeconds(5);
        textParent.SetActive(false);
        isTalking = false;
    }

    // runs every frame to check if we can talk
    void ProcessCheckTalk()
    {
        // check the distance from us to the player and talk if we can
        if ((Input.GetKey(KeyCode.Space)) && Mathf.Abs(Vector2.Distance(playerTransform.position, transform.position)) < interactionDistance && !isTalking)
        {
            StartCoroutine(ProcessTalk());
        }
    }

    void UpdateText()
    {
        // update what we're currently saying so that it reflects the changes from the key
        currentWords = newWords;
    }
}
