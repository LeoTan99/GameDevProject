using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Goal : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI pointText;
    public int score = 0;
    public int point = 0;

    public Transform spawnPoint;
    [SerializeField] private AudioSource soundEffect;
    public GameObject particleSystem;

    public float speed = 5f;
    bool moveKrabbyPatty;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            score++;
            point += 10;
            scoreText.text = score.ToString();
            pointText.text = point.ToString();
            soundEffect.Play();
            StartCoroutine(ActivateParticleSystem());

            Rigidbody ballRb = other.GetComponent<Rigidbody>();
            ballRb.velocity = Vector3.zero;
            ballRb.angularVelocity = Vector3.zero;
            other.gameObject.transform.position = spawnPoint.position;
        }

        // Save the points value
        PlayerPrefs.SetInt("Points", point);
        PlayerPrefs.Save();
    }

    private System.Collections.IEnumerator ActivateParticleSystem()
    {
        particleSystem.SetActive(true);

        yield return new WaitForSeconds(3f);

        particleSystem.SetActive(false);
    }
}
