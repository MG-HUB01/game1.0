using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    public float speed = 6f;
    public float turnSmoothTime = 0.1f;

    private float turnSmoothVelocity;

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            // Calculate the target angle based on input and camera orientation
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;

            // Smoothly rotate the player towards the target angle
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            // Move the character in the rotated forward direction
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }

        // Apply vertical movement (e.g., jump)
        if (Input.GetKey(KeyCode.Space))
        {
            controller.Move(new Vector3(0, 20f * Time.deltaTime, 0));
        }

        // Optional: Constrain the position if needed
        ConstrainPosition();
    }

    private void ConstrainPosition()
    {
        Vector3 position = transform.position;

        // Clamp X and Z positions to avoid moving out of bounds
        position.x = Mathf.Clamp(position.x, -10f, 10f);
        position.z = Mathf.Clamp(position.z, -10f, 10f);

        // Update the position to the constrained values
        transform.position = position;
    }
}
