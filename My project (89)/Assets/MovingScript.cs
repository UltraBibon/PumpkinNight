using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    Test inputActions;
    Vector2 move;


    private void Awake()
    {
        inputActions = new Test();

        inputActions.PlayerController.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        inputActions.PlayerController.Move.canceled += ctx => move = Vector2.zero;
    }

    void Update()
    {
        Vector2 m = new Vector2(-move.x, move.y) * Time.deltaTime;
        transform.Translate(move, Space.World);
    }


    private void OnEnable()
    {
        inputActions.PlayerController.Enable();
    }

    private void OnDisable()
    {
        inputActions.PlayerController.Disable();
    }
}
