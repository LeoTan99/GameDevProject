using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class Goal : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI pointText;
    public int score = 0;
    public int point = 0;

    public int playerScore = 0;

    public Transform spawnPoint;
    [SerializeField] private AudioSource SoundEffect;
    public GameObject particleEffect;

    public float speed = 5f;
    bool moveKrabbyPatty;
    // public GameObject target;

    // void Start()
    // {
    //     target = GameObject.FindGameObjectWithTag("toKrabbyPatty");
    // }

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
            playerScore++;
            point = point + 10;
            scoreText.text = score.ToString();
            pointText.text = point.ToString();
            //SoundEffect.Play();
            //particleEffect.SetActive(true);
            // moveKrabbyPatty = true;
            StartCoroutine(goalParticleEffect());
            
            Rigidbody ballRb = other.GetComponent<Rigidbody>();
            ballRb.velocity = Vector3.zero;
            ballRb.angularVelocity = Vector3.zero;
            other.gameObject.transform.position = spawnPoint.position;
        }

        // Save the points value
        PlayerPrefs.SetInt("Points", point);
        PlayerPrefs.Save();
    }

    // void Update()
    // {
    //     if(moveKrabbyPatty)
    //     {
    //         transform.position = Vector3.Lerp(transform.position, target.transform.position, speed * Time.deltaTime);
    //     }
    // }

    private IEnumerator goalParticleEffect()
    {
        SoundEffect.Play();
        particleEffect.SetActive(true);
        yield return new WaitForSeconds(2);
        particleEffect.SetActive(false);
    }
}
