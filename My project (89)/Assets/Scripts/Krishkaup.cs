using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Krishkaup : MonoBehaviour
{
    public Score _scorescr;
    public int pointsThreshold;
    public float _forcee;
    public AudioClip flySound;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float destroTime;


    private bool hasReachedThreshold = false;

    void Update()
    {
        if (!hasReachedThreshold && _scorescr._score >= pointsThreshold)
        {
            FlyUp();
            hasReachedThreshold = true;
        }
    }

    void FlyUp()
    {
        AudioSource.PlayClipAtPoint(flySound, transform.position);
        _rigidbody.isKinematic = false;
        _rigidbody.AddForce(Vector3.up * _forcee);
        Destroy(gameObject, destroTime);
    }
}
