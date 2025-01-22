using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using UnityEngine.XR.Interaction.Toolkit;
using Random = UnityEngine.Random;

public class Shoot : MonoBehaviour
{

    [SerializeField] public InputActionProperty _Ltrigger;
    [SerializeField] public InputActionProperty _Rtrigger;
    public float _fireRate = 1f;
    private float _shootingTimer = 0.0f;
    [SerializeField] private InputActionProperty _LgripAction;
    [SerializeField] private InputActionProperty _RgripAction;




    //[SerializeField] public InputAction _actionButtonPressed;
    [SerializeField] public Transform crosshair;
    [SerializeField] public GameObject bullet;
    [SerializeField] public float _shootingForce;
    [SerializeField] public int _numberOfBullets;
    [SerializeField] public ParticleSystem _Flash;
    [SerializeField] public float _angle;
    List<Quaternion> bullets;
    bool ispicked = false;
    private XRGrabInteractable interactable;
    [SerializeField] public AudioClip shotgunsound;
    public AudioSource gunshot;
    private void Awake()
    {
        bullets = new List<Quaternion>(_numberOfBullets);
        for (int i = 0; i < _numberOfBullets; i++)
        {
            bullets.Add(Quaternion.Euler(Vector3.zero));
        }
        //_actionButtonPressed.performed += context => shoot(ispicked);

        interactable = GetComponent<XRGrabInteractable>();
        InteractableProcess();
        

    }

    private void InteractableProcess()
    {
        interactable.onSelectEntered.AddListener(PickedUp);
        interactable.onSelectExited.AddListener(Dropped);
        //interactable.onActivate.AddListener(Shooting);
        //interactable.onDeactivate.AddListener(StopShooting);

    }

    private void PickedUp(XRBaseInteractor interactor)
    {
        ispicked = true;
    }

    private void Dropped(XRBaseInteractor interactor)
    {
        ispicked = false;
    }

    void FixedUpdate()
    {
        var Lgripvalue = _LgripAction.action.ReadValue<float>();
        var Rgripvalue = _RgripAction.action.ReadValue<float>();
        var LtriggerValue = _Ltrigger.action.ReadValue<float>();
        var RtriggerValue = _Rtrigger.action.ReadValue<float>();
        if (LtriggerValue != 0 && Time.time > _shootingTimer && ispicked == true && Lgripvalue != 0 && HandDetector.shootingleft == true)
        {
            _shootingTimer = Time.time + _fireRate;
            shoot();
        }
        else if (RtriggerValue != 0 && Time.time > _shootingTimer && ispicked == true && Rgripvalue != 0 && HandDetector.shootingright == true)
        {
            _shootingTimer = Time.time + _fireRate;
            shoot();
        }
    }

    /*
    private void OnEnable()
    {
        _actionButtonPressed.Enable();
    }

    private void OnDisable()
    {
        _actionButtonPressed.Disable();
    }
    */
    private void shoot()
    {
        /*
         for (short i = 0; i < _numberOfBullets; i++)    
         {


             float x = Random.Range(_minRange, _maxRange);
             float y = Random.Range(_minRange, _maxRange);

             Vector3 direction = crosshair.transform.forward + new Vector3(x, y, 0);

             if (Physics.Raycast(crosshair.position, direction, out _hit, _fireRange))
             {
                 Debug.DrawLine(crosshair.position, direction);
                 if(_hit.collider.tag == "Monster") 
                 {
                     Debug.Log("SOSAT");
                 }
                 if(_hit.collider.tag == "bullet")
                 {
                     Debug.Log("BAN");
                 }
             };


             float x = Random.Range(_minRange, _maxRange);
             float y = Random.Range(_minRange, _maxRange);

             Vector3 direction = crosshair.transform.forward + new Vector3(x, y, 0);
             Debug.Log(direction);
             GameObject newBullet = Instantiate(bullet, crosshair.transform.position, Quaternion.Euler(direction));

             //ParticleSystem Flash = Instantiate(_Flash, crosshair.transform.position, crosshair.transform.rotation);
             newBullet.GetComponent<Rigidbody>().AddForce(newBullet.transform.forward * _shootingForce, ForceMode.VelocityChange);
            }   
         */

            gunshot.PlayOneShot(shotgunsound);
            ParticleSystem flash = Instantiate(_Flash, crosshair.position, crosshair.rotation);
            Destroy(flash, 1f);
            Destroy(flash.gameObject, 1f);
            int i = 0;
            foreach (Quaternion q in bullets.ToArray())
            {
                bullets[i] = Random.rotation;
                GameObject bullet1 = Instantiate(bullet, crosshair.position, crosshair.rotation);
                bullet1.transform.rotation = Quaternion.RotateTowards(bullet1.transform.rotation, bullets[i], _angle);
                bullet1.GetComponent<Rigidbody>().AddForce(bullet1.transform.forward * _shootingForce, ForceMode.VelocityChange);
                i++;
            }
        
    }


}


