using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class RifleShoot : MonoBehaviour
{
    [SerializeField] public InputActionProperty _Ltrigger;
    [SerializeField] public InputActionProperty _Rtrigger;
    //[SerializeField] public InputActionProperty _triggerAction;
    public float _fireRate = 0.5f;
    [SerializeField] public ParticleSystem _muzzleFlash;
    [SerializeField] public GameObject _bullet;
    [SerializeField] public Transform _crosshair;
    [SerializeField] public float _shootingForce;
    private float _shootingTimer = 0.0f;
    [SerializeField] private InputActionProperty _LgripAction;
    [SerializeField] private InputActionProperty _RgripAction;
    [SerializeField] public AudioClip riflesound;
    public AudioSource gunshot;
    bool ispicked = false;
    private XRGrabInteractable interactable;

    private void Awake()
    {
        interactable = GetComponent<XRGrabInteractable>();
        InteractableProcess();
    }
    private void InteractableProcess()
    {
        interactable.onSelectEntered.AddListener(PickedUp);
        interactable.onSelectExited.AddListener(Dropped);
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
        if (LtriggerValue != 0 && Time.time > _shootingTimer && ispicked==true && Lgripvalue!=0 && HandDetector.shootingleft ==true)
        {
            _shootingTimer = Time.time + _fireRate;
            Shoot();
        }
        else if (RtriggerValue !=0 && Time.time > _shootingTimer && ispicked == true && Rgripvalue != 0 && HandDetector.shootingright == true)
        {
            _shootingTimer = Time.time + _fireRate;
            Shoot();
        }
    }

    private void Shoot()
    {
        gunshot.PlayOneShot(riflesound);
        GameObject bullet = Instantiate(_bullet, _crosshair.transform.position, _crosshair.rotation);
        bullet.transform.Rotate(90, 0, 0);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(_crosshair.forward*_shootingForce, ForceMode.VelocityChange);
    }

}
