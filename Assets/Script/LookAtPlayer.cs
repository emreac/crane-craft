using UnityEngine;

public class LookAtPlayerYOffset : MonoBehaviour
{
    public Transform playerTransform; // Reference to the player's Transform
    public float rotationSpeed = 5f;  // Speed of rotation
    public float yOffset = 1f;        // Offset value for Y position

    void Update()
    {
        if (playerTransform != null)
        {
            // Calculate the direction from the GameObject to the player
            Vector3 targetPosition = playerTransform.position;
            targetPosition.y += yOffset; // Apply the Y offset
            Vector3 direction = targetPosition - transform.position;
            direction.y = 0; // Ignore the Y axis for rotation

            // Calculate the rotation required to look at the player
            Quaternion targetRotation = Quaternion.LookRotation(direction);

            // Smoothly rotate towards the player on the Y axis only
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
