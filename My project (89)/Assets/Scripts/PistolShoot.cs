using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class PistolShoot : MonoBehaviour
{
    [SerializeField] public InputActionProperty _Ltrigger;
    [SerializeField] public InputActionProperty _Rtrigger;
    public float _fireRate = 1f;
    private float _shootingTimer = 0.0f;
    [SerializeField] private InputActionProperty _LgripAction;
    [SerializeField] private InputActionProperty _RgripAction;


    //[SerializeField] public InputAction _actionButtonPressed;
    [SerializeField] public Transform _crosshair;
    [SerializeField] public GameObject _bullet1;
    [SerializeField] public float _shootingForce;
    [SerializeField] public ParticleSystem _flash;
    [SerializeField] public AudioClip pistolsound;
    private XRGrabInteractable interactable;
    bool ispicked = false;

    public AudioSource gunshot;

    private void Awake()
    {
        //_actionButtonPressed.performed += context => shoot(ispicked);
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



    private void shoot()
    {

            gunshot.PlayOneShot(pistolsound);
            GameObject bullet = Instantiate(_bullet1, _crosshair.transform.position, _crosshair.transform.rotation);
            bullet.GetComponent<Rigidbody>().AddForce(_crosshair.forward * _shootingForce, ForceMode.VelocityChange);

    }


}
