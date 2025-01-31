using UnityEngine;

public class playermovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    // Update is called once per frame
    void Update()
    {
        // if key a is pressed move in negative x direction by 2 units
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-4f * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(4f * Time.deltaTime, 0, 0);
        }
if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, 0, 4f * Time.deltaTime);
        }
if (Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0, 0, -4f * Time.deltaTime);
        }
if(Input.GetKey(KeyCode.Space))
{
transform.position += new Vector3(0, 20f * Time.deltaTime, 0);
        ConstrainPosition();


 }
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