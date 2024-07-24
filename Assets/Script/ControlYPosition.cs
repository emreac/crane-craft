using UnityEngine;
using UnityEngine.UI;

public class ControlYPosition : MonoBehaviour
{
    public Slider yPositionSlider;    // Reference to the Slider
    public Transform controlledObject; // Reference to the object whose Y position will be controlled

    public float minYPosition = 0f;   // Minimum Y position
    public float maxYPosition = 10f;  // Maximum Y position

    private void Start()
    {
        // Initialize the Slider's value and range
        yPositionSlider.minValue = minYPosition;
        yPositionSlider.maxValue = maxYPosition;
        yPositionSlider.value = controlledObject != null ? controlledObject.position.y : 0f;

        // Add listener for slider value change
        yPositionSlider.onValueChanged.AddListener(UpdateYPosition);
    }

    private void UpdateYPosition(float value)
    {
        if (controlledObject != null)
        {
            Vector3 position = controlledObject.position;
            position.y = value;
            controlledObject.position = position;
        }
    }
}
