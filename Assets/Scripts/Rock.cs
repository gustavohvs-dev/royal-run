using UnityEngine;
using Unity.Cinemachine;

public class Rock : MonoBehaviour
{
    [SerializeField] float shakeModifier = 10f;
    [SerializeField] ParticleSystem collisionParticleSystem;
    [SerializeField] AudioSource rockAudioSource;
    [SerializeField] float collisionCooldown = 1f;
    CinemachineImpulseSource cinemachineImpulseSource;
    float collisionTimer = 1f;

    void Awake()
    {
        cinemachineImpulseSource = GetComponent<CinemachineImpulseSource>();
    }

    void Update()
    {
        collisionTimer += Time.deltaTime;
    }

    void OnCollisionEnter(Collision other)
    {
        if (collisionTimer < collisionCooldown) return;
        collisionTimer = 0;
        ShakeCamera();
        CollisionFX(other);
    }

    private void ShakeCamera()
    {
        float distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        float shakeIntensity = 1f / distance * shakeModifier;
        shakeIntensity = Mathf.Min(shakeIntensity, 1f);
        cinemachineImpulseSource.GenerateImpulse(shakeIntensity);
    }

    void CollisionFX(Collision other)
    {
        ContactPoint contactPoint = other.contacts[0];
        collisionParticleSystem.transform.position = contactPoint.point;
        collisionParticleSystem.Play();
        rockAudioSource.Play();
    }
}
