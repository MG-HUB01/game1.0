using UnityEngine;

public class ObjectCollector : MonoBehaviour
{
    public Camera playerCamera;  
    public float baseCollectionDistance = 2f;  
    public float distancePerLevel = 2f; 
    public int playerLevel = 1;  
    int layerToIgnore = 2;


public int layerMask ;
     void Start()
     {
        layerMask = ~(1 << layerToIgnore);
     }
    void Update()

    {
        
        if (playerCamera == null)
        {
            Debug.LogError("Player Camera is not assigned.");
            return;
        }

        float maxDistance = baseCollectionDistance + (distancePerLevel * (playerLevel - 1));

        if (Input.GetKeyDown(KeyCode.P))  // When the "P" key is pressed
        {
            Debug.Log("P key pressed");
            AttemptCollection(maxDistance);
        }
    }

    void AttemptCollection(float maxDistance)
    {
        Ray ray = playerCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;

        Debug.DrawRay(ray.origin, ray.direction * maxDistance, Color.red, 1f);

        if (Physics.Raycast(ray, out hit, maxDistance,layerMask))
        {
            Debug.Log($"Ray hit: {hit.collider.name}");

            // Check if the hit object has the "TARGET" tag
            if (hit.collider.CompareTag("TARGET"))
            {
                CollectObject(hit.collider.gameObject);
            }
            else
            {
                Debug.Log("Hit object is not a collectible.");
            }
        }
        else
        {
            Debug.Log("Ray did not hit anything.");
        }
    }

    void CollectObject(GameObject collectible)
    {
        // Perform collection logic here (e.g., add to inventory, play a sound, etc.)
        Debug.Log($"Collected: {collectible.name}");
        
        // Destroy the object to simulate collection
        Destroy(collectible);  
    }
}
