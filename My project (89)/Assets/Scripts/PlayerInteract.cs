using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using Unity.VisualScripting;

public class PlayerInteract : MonoBehaviour
{
    public InputAction _actionButtonPressed;

    private void Awake()
    {
        _actionButtonPressed.performed += context => DialogueOn();
    }

    private void OnEnable()
    {
        _actionButtonPressed.Enable();
    }

    private void OnDisable()
    {
        _actionButtonPressed.Disable();
    }

    private void DialogueOn()
    {
        float interactRange = 2f;
        Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
        foreach (Collider collider in colliderArray)
        {
            if (collider.TryGetComponent(out CatDialogue catinteract))
            {
                catinteract.Interact(); 
            }
        }
    }
}


/*

//Enabled Disableed
[SerializeField] private InputActionProperty _triggerL;

private void Update()
{
    var triggerLValue = _triggerL.action.ReadValue<float>();
    if (triggerLValue > 0.0)
    {
        float interactRange = 2f;
        Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
        foreach (Collider collider in colliderArray)
        {
            if (collider.TryGetComponent(out CatDialogue catinteract))
            {
                catinteract.Interact();
            }
        }
    }
}

}
*/

