using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Goal : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public int score = 0;
    public Transform spawnPoint;
    [SerializeField] private AudioSource SoundEffect;
    public GameObject particleSystem;
    // private int previousScore = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            score++;
            scoreText.text = score.ToString();
            SoundEffect.Play();
            particleSystem.SetActive(true);
            
            Rigidbody ballRb = other.GetComponent<Rigidbody>();
            ballRb.velocity = Vector3.zero;
            ballRb.angularVelocity = Vector3.zero;
            other.gameObject.transform.position = spawnPoint.position;

            // Play the particle system if score increases
            // if (score > previousScore && particleSystem != null)
            // {
            //     particleSystem.Play();
            // }
            
            // previousScore = score;
        }
        //particleSystem.SetActive(false);
    }
}
