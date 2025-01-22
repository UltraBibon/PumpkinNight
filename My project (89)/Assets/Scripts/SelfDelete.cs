using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDelete : MonoBehaviour
{
    public float destroyTime = 3f; // Time in seconds before the object is destroyed

    void Start()
    {
        Destroy(gameObject, destroyTime);
    }
}