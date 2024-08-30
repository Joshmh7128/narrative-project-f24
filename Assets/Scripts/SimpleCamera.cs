using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCamera : MonoBehaviour
{
    [SerializeField] public Transform follow;


    // Update is called once per frame
    void Update()
    {
        Vector3 pos = new Vector3(follow.position.x, follow.position.y, -10);
        transform.position = pos;
    }
}
