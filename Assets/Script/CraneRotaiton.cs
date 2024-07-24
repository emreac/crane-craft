using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CraneRotaiton : MonoBehaviour
{
    public VariableJoystick joystick;
    public CharacterController controller;

    public Canvas inputCanvas;
    public bool isJoystick;
    public float movementSpeed;
    public float rotationSpeed;
    public bool walking;


    private void Start()
    {   
        EnableJoystickInput();
    }

    public void EnableJoystickInput()
    {
        isJoystick = true;
        inputCanvas.gameObject.SetActive(true);
    }

    private void Update()
    {
        if (isJoystick)
        {
            var movementDirection = new Vector3(joystick.Direction.x, 0f, joystick.Direction.y);
            var movement = movementDirection * movementSpeed * Time.deltaTime;

            // Move the character controller
            controller.Move(movement);

            if (movementDirection.sqrMagnitude <= 0)
            {
                walking = false;
                return;
            }

            walking = true;
            var targetDirection = Vector3.RotateTowards(controller.transform.forward, movementDirection, rotationSpeed * Time.deltaTime, 0f);
            controller.transform.rotation = Quaternion.LookRotation(targetDirection);
        }
    }




}
