using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
    [SerializeField] float moveSpeed = 12f;
    Rigidbody rb;

    private void Start() 
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() {
        Vector3 currentPosition = rb.position;
        Vector3 moveDirection = new Vector3(0f, 0f, -1f);
        Vector3 newPosition = currentPosition + moveDirection * (moveSpeed * Time.fixedDeltaTime);
        rb.MovePosition(newPosition);
    }
}
