using UnityEngine;

public class RectangularMovement : MonoBehaviour
{
    public float width = 5f;          // Width of the rectangle
    public float height = 5f;         // Height of the rectangle
    public float speed = 2f;          // Speed of the movement
    public float yOffset = 2f;        // Y position offset
    public Vector3 rectangleCenter = Vector3.zero; // Center position of the rectangle

    private float perimeter;
    private float currentDistance;    // Current distance traveled along the rectangle's perimeter

    void Start()
    {
        // Calculate the perimeter of the rectangle
        perimeter = 2 * (width + height);

        // Initialize the position
        transform.position = rectangleCenter + new Vector3(-width / 2, yOffset, -height / 2);
        currentDistance = 0f;
    }

    void Update()
    {
        // Increment the distance based on the speed
        currentDistance += speed * Time.deltaTime;
        currentDistance = currentDistance % perimeter; // Loop around the perimeter

        // Determine the position based on currentDistance
        Vector3 newPosition = CalculatePosition(currentDistance);

        // Update the position of the GameObject
        transform.position = newPosition;

        // Optional: update rotation to face direction of movement
        // Find next position ahead for smooth rotation
        Vector3 nextPosition = CalculatePosition(currentDistance + 0.1f);
        Vector3 direction = nextPosition - newPosition;
        if (direction != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(direction);
        }
    }

    Vector3 CalculatePosition(float distance)
    {
        float x = 0, z = 0;

        // Calculate current segment and position in that segment
        if (distance < width) // Bottom side
        {
            x = -width / 2 + distance;
            z = -height / 2;
        }
        else if (distance < width + height) // Right side
        {
            x = width / 2;
            z = -height / 2 + (distance - width);
        }
        else if (distance < 2 * width + height) // Top side
        {
            x = width / 2 - (distance - (width + height));
            z = height / 2;
        }
        else // Left side
        {
            x = -width / 2;
            z = height / 2 - (distance - (2 * width + height));
        }

        return rectangleCenter + new Vector3(x, yOffset, z);
    }
}
