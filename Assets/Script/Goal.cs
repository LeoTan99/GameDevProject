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
    [SerializeField] private AudioSource SoundEffect;
    public GameObject particleSystem;

    public float speed = 5f;
    bool moveKrabbyPatty;
    public GameObject target;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("toKrabbyPatty");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            score++;
            point = point + 10;
            scoreText.text = score.ToString();
            pointText.text = point.ToString();
            SoundEffect.Play();
            particleSystem.SetActive(true);
            moveKrabbyPatty = true;
            
            Rigidbody ballRb = other.GetComponent<Rigidbody>();
            ballRb.velocity = Vector3.zero;
            ballRb.angularVelocity = Vector3.zero;
            other.gameObject.transform.position = spawnPoint.position;

        }
    }

    void Update()
    {
        if(moveKrabbyPatty)
        {
            transform.position = Vector3.Lerp(transform.position, target.transform.position, speed * Time.deltaTime);
        }
    }
}
