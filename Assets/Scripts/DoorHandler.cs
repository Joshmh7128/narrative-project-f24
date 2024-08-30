using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoorHandler : MonoBehaviour
{
    KeyHandler keyHandler; // our key handler
    bool isUnlocked = false; // is the door unlocked?
    public UnityEvent doorOpened; // our door opening event

    // Start is called before the first frame update
    void Start()
    {
        // get our key handler
        keyHandler = FindObjectOfType<KeyHandler>();
        keyHandler.KeyPickup.AddListener(() => isUnlocked = true);

        // make our event
        if (doorOpened == null) doorOpened = new UnityEvent();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isUnlocked) 
        { 
            doorOpened.Invoke();
            Destroy(gameObject); 
        }
    }
}
