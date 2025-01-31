using UnityEngine;

public class PreventChildCollisions : MonoBehaviour
{
    public GameObject child1;
    public GameObject child2;

    void Start()
    {
        Collider collider1 = child1.GetComponent<Collider>();
        Collider collider2 = child2.GetComponent<Collider>();

        if (collider1 != null && collider2 != null)
        {
            Physics.IgnoreCollision(collider1, collider2);
        }
    }
}
