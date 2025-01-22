/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    [SerializeField] private GameObject _replacement;
    [SerializeField] private GameObject _boom;
    //[SerializeField] private float _breakForce = 2;
    [SerializeField] private float _collisionMultiplier = 100;
    public bool _broken;

    void OnCollisionEnter(Collision collision)
    {
        if (_broken) return;
        if (collision.gameObject.CompareTag("Weapon"))
        { 
            _broken = true;
            var replacement = Instantiate(_replacement, transform.position, transform.rotation);

            var rbs = replacement.GetComponentsInChildren<Rigidbody>();
            foreach (var rb in rbs ) 
            {
                rb.AddExplosionForce(_collisionMultiplier, collision.contacts[0].point, 2);
                
            }
            var ab = Instantiate(_boom, transform.position, Quaternion.identity);
            Destroy( ab, 5 );
            Destroy(gameObject);
        }
    }
}
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    [SerializeField] private GameObject _replacement;
    [SerializeField] private GameObject _boom;
    [SerializeField] private float _collisionMultiplier = 100;
    public bool _broken;
    private PumpCount _pumpcount;

    void OnCollisionEnter(Collision collision)
    {
        if (_broken) return;
        if (collision.gameObject.CompareTag("Weapon"))
        {
            _broken = true;

            var replacement = Instantiate(_replacement, transform.position, transform.rotation);

            var rbs = replacement.GetComponentsInChildren<Rigidbody>();
            foreach (var rb in rbs)
            {
                rb.AddExplosionForce(_collisionMultiplier, collision.contacts[0].point, 2);

            }
            var ab = Instantiate(_boom, transform.position, Quaternion.identity);
            Destroy(ab, 5);
            Destroy(gameObject);
            _pumpcount = GameObject.Find("CanvPoint").GetComponent<PumpCount>();
            Debug.Log(_pumpcount);
            _pumpcount.AddPoint();
        }
    }
}
