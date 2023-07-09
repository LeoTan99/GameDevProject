using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class GoalBonus : MonoBehaviour
{
    public TextMeshProUGUI pointText;
    public TextMeshProUGUI pointWinText;
    public int playerScore = 0;

    public Transform spawnPoint;
    [SerializeField] private AudioSource SoundEffect;
    public GameObject particleEffect;

    public float speed = 5f;
    bool moveKrabbyPatty;

    private void Start()
    {
       

        // Retrieve the saved point value from PlayerPrefs
        if (PlayerPrefs.HasKey("Points"))
        {
            int savedPoints = PlayerPrefs.GetInt("Points");
            PointManager.instance.point = savedPoints;
            pointText.text = savedPoints.ToString();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        GetBallMP[] getAllObject = FindObjectsOfType<GetBallMP>();

        foreach (GetBallMP item in getAllObject)
        {
            item.isStickToPlayer = false;
        }

        if (other.gameObject.CompareTag("Ball"))
        {
            PointManager.instance.point += 10;

            pointText.text = PointManager.instance.point.ToString();
            pointWinText.text = PointManager.instance.point.ToString();
            StartCoroutine(goalParticleEffect());

            Rigidbody ballRb = other.GetComponent<Rigidbody>();
            ballRb.velocity = Vector3.zero;
            ballRb.angularVelocity = Vector3.zero;
            other.gameObject.transform.position = spawnPoint.position;

            //Animation reset
            FindAnyObjectByType<plakGoalKeeper>().resetAnimation();
        }

        // Save the points value
        PlayerPrefs.SetInt("Points", PointManager.instance.point);
        PlayerPrefs.Save();
    }

    private IEnumerator goalParticleEffect()
    {
        SoundEffect.Play();
        particleEffect.SetActive(true);
        yield return new WaitForSeconds(2);
        particleEffect.SetActive(false);
    }
}
