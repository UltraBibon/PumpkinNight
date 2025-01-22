/*

using UnityEngine;

public class ButtonInteraction : MonoBehaviour
{
    public float cooldownTime = 2f;
    private bool canInteract = true;

    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))

        {
            Interact();
            StartCoroutine(ActivateCooldown());
        }
    }

    void Interact()
    {
        // Code for interaction goes here 
    }

    System.Collections.IEnumerator ActivateCooldown()
    {
        canInteract = false;
        yield return new WaitForSeconds(cooldownTime);
        canInteract = true;
    }
}
*/