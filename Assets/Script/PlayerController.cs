using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public VariableJoystick joystick;
    public CharacterController controller;

    public Canvas inputCanvas;
    public bool isJoystick;
    public float movementSpeed;
    public float rotationSpeed;
    public bool walking;

    public Slider yPositionSlider; // Reference to the Slider
    public float minYPosition = 0f; // Minimum Y position
    public float maxYPosition = 10f; // Maximum Y position

    private void Start()
    {
        Time.timeScale = 1f;
        EnableJoystickInput();

        // Initialize the Slider's value and range
        yPositionSlider.minValue = minYPosition;
        yPositionSlider.maxValue = maxYPosition;
        yPositionSlider.value = transform.position.y;

        // Add listener for slider value change
        yPositionSlider.onValueChanged.AddListener(UpdateYPosition);
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

            // Update the Y position based on the slider's value
            movement.y = yPositionSlider.value - transform.position.y;

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

    private void UpdateYPosition(float value)
    {
        // Move the character controller vertically
        var movement = new Vector3(0, value - transform.position.y, 0);
        controller.Move(movement);
    }
}

