using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f; // Speed of the object
    private Vector3 randomDirection; // Direction to move

    private void OnEnable()
    {
      InvokeRepeating(nameof(RandomDirection), 0f, 1f);
 
    }

    private void Update()
    {
        // Move the object
        transform.Translate(randomDirection * moveSpeed * Time.deltaTime, Space.World);

        // Ensure position stays within bounds
        ConstrainPosition();
    }
    private void RandomDirection()
    {
       
        randomDirection = new Vector3(
            Random.Range(-1f, 1f),
            0f, // Keep Y fixed
            Random.Range(-1f, 1f)
        ).normalized; // Normalize to ensure consistent speed
    }
    private void ConstrainPosition()
    {
        Vector3 position = transform.position;

        // Clamp X and Z to ensure absolute values are less than 10
        position.x = Mathf.Clamp(position.x, -10f, 10f);
        position.z = Mathf.Clamp(position.z, -10f, 10f);

        // Update the position to the constrained values
        transform.position = position;
    }
}
