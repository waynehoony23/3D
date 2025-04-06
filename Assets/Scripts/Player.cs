using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f; 

    void Start()
    {
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal"); 
        float moveZ = Input.GetAxis("Vertical");   

        Vector3 movement = new Vector3(moveX, 0, moveZ);

        if (movement.magnitude > 1)
            movement = movement.normalized;

        movement *= speed * Time.deltaTime;

        transform.Translate(movement, Space.World);
    }
}