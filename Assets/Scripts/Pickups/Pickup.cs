using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 100f;
    const string playerStringTag = "Player";

    void Update()
    {
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag(playerStringTag))
        {
            OnPickup();
            Destroy(this.gameObject);
        }
    }

    protected abstract void OnPickup();
}
