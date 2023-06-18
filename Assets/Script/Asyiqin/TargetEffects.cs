using UnityEngine;
using System.Collections;

public class TargetEffects : MonoBehaviour
{
    public float shakeDuration = 0.5f;
    public float shakeIntensity = 0.2f;

    private Vector3 initialPosition;
    private bool isShaking = false;

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("VenomProjectile"))
        {
            if (!isShaking)
            {
                isShaking = true;
                StartCoroutine(ShakeTarget());
            }
        }
    }

    private IEnumerator ShakeTarget()
    {
        float elapsedTime = 0f;

        while (elapsedTime < shakeDuration)
        {
            Vector3 shakeOffset = Random.insideUnitSphere * shakeIntensity;
            transform.position = initialPosition + shakeOffset;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = initialPosition;
        isShaking = false;
    }
}
