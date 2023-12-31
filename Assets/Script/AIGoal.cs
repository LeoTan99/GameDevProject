using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AIGoal : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI pointText;
    public int score = 0;
    public int point = 0;

    public int aiScore = 0;

    public Transform spawnPoint;
    [SerializeField] private AudioSource soundEffect;
    public GameObject particleSystem;

    public float speed = 5f;
    bool moveKrabbyPatty;

    private void OnTriggerEnter(Collider other)
    {
        GetBallMP[] getAllObject = FindObjectsOfType<GetBallMP>();

        foreach (GetBallMP item in getAllObject)
        {
            item.isStickToPlayer = false;
        }

        if (other.gameObject.CompareTag("Ball"))
        {
            score++;
            aiScore++;
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
    }

    private System.Collections.IEnumerator ActivateParticleSystem()
    {
        particleSystem.SetActive(true);

        yield return new WaitForSeconds(3f);

        particleSystem.SetActive(false);
    }
}
