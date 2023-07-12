using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;
using Photon.Pun;

public class GoalMP : MonoBehaviourPunCallbacks
{
    public TextMeshProUGUI scoreText;
    public int score = 0;
    public Transform spawnPoint;
    public GameObject ConfettiParticleEffect;
    //public GameObject EtherealHitParticleEffect;

    [SerializeField] private AudioSource SoundEffect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            score++;
            scoreText.text = score.ToString();
            StartCoroutine(goalParticleEffect());
            photonView.RPC("Send_PlayersName", RpcTarget.OthersBuffered, 0, score.ToString());

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
        //EtherealHitParticleEffect.SetActive(true);
        yield return new WaitForSeconds(2);
        ConfettiParticleEffect.SetActive(false);
        //EtherealHitParticleEffect.SetActive(false);
    }

    [PunRPC]
    void Send_PlayersName(int index, string name)
    {
        scoreText.text = name;
    }
}
