using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class GoalMP : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public int score = 0;
    public Transform spawnPoint;
    public GameObject ConfettiParticleEffect;
    public GameObject EtherealHitParticleEffect;

    [SerializeField] private AudioSource SoundEffect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            score++;
            scoreText.text = score.ToString();
            StartCoroutine(goalParticleEffect());

            Rigidbody ballRb = other.GetComponent<Rigidbody>();
            ballRb.velocity = Vector3.zero;
            ballRb.angularVelocity = Vector3.zero;
            other.gameObject.transform.position = spawnPoint.position;
        }
    }

    private IEnumerator goalParticleEffect()
    {
        SoundEffect.Play();
        ConfettiParticleEffect.SetActive(true);
        EtherealHitParticleEffect.SetActive(true);
        yield return new WaitForSeconds(2);
        ConfettiParticleEffect.SetActive(false);
        EtherealHitParticleEffect.SetActive(false);
    }
}
