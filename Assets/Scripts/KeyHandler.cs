using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeyHandler : MonoBehaviour
{
    public UnityEvent KeyPickup; // our key pickup event
    [SerializeField] Transform playerTransform; // the transform of our player
    [SerializeField] float interactionDistance = 1;

    // Start is called before the first frame update
    void Start()
    {
        // setup our event
        if (KeyPickup == null) KeyPickup = new UnityEvent();
        // get our player
        playerTransform = FindObjectOfType<PlayerController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform == null) return;

        // when we're close, fire the event and destroy this object
        if (Mathf.Abs(Vector2.Distance(transform.position, playerTransform.position)) < interactionDistance)
        {
            Debug.Log("player hit! " + Vector2.Distance(transform.position, playerTransform.position));
            KeyPickup.Invoke();
            Destroy(gameObject);
        }
    }
}
