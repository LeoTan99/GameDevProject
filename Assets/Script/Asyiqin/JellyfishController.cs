using UnityEngine;
using System.Collections;

public class JellyfishController : MonoBehaviour
{
    public float movementSpeed = 3f;
    public float minMovementTime = 1f;
    public float maxMovementTime = 5f;
    public float floatAmplitude = 1f; // Maximum distance to float from the starting position
    public float floatFrequency = 1f; // Frequency of the floating movement
    public GameObject venomPrefab;
    public float venomForce = 5f;
    public float minVenomInterval = 2f;
    public float maxVenomInterval = 5f;
    public float venomLifetime = 3f; // Lifetime of the venom projectile

    private Rigidbody rb;
    private Coroutine movementCoroutine;
    private Coroutine venomCoroutine;
    private Vector3 startingPosition;
    private Transform target; // The object to follow and shoot at

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        startingPosition = transform.position;
    }

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Target").transform; // Assuming the target object has a tag "Target"
        StartRandomMovement();
        StartRandomVenomShooting();
    }

    private void StartRandomMovement()
    {
        if (movementCoroutine != null)
        {
            StopCoroutine(movementCoroutine);
        }

        movementCoroutine = StartCoroutine(RandomMovement());
    }

    private void StartRandomVenomShooting()
    {
        if (venomCoroutine != null)
        {
            StopCoroutine(venomCoroutine);
        }

        venomCoroutine = StartCoroutine(RandomVenomShooting());
    }

    private IEnumerator RandomMovement()
    {
        while (true)
        {
            // Calculate the direction to the target
            Vector3 targetDirection = (target.position - transform.position).normalized;

            // Rotate towards the target
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
            rb.MoveRotation(targetRotation);

            // Move towards the target
            rb.velocity = targetDirection * movementSpeed;

            float randomMovementTime = Random.Range(minMovementTime, maxMovementTime);
            yield return new WaitForSeconds(randomMovementTime);
        }
    }

    private IEnumerator RandomVenomShooting()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minVenomInterval, maxVenomInterval));

            GameObject venom = Instantiate(venomPrefab, transform.position, Quaternion.identity);
            Rigidbody venomRb = venom.GetComponent<Rigidbody>();

            Vector3 shootingDirection = (target.position - transform.position).normalized;

            venomRb.velocity = shootingDirection * venomForce;

            Destroy(venom, venomLifetime);
        }
    }

    private void FixedUpdate()
    {
        // Calculate the floating movement based on sine wave
        float floatY = startingPosition.y + Mathf.Sin(Time.time * floatFrequency) * floatAmplitude;
        Vector3 floatPosition = new Vector3(transform.position.x, floatY, transform.position.z);

        // Move the jellyfish to the float position
        rb.MovePosition(floatPosition);
    }
}
