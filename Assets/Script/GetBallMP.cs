using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class GetBallMP : MonoBehaviourPunCallbacks
{
    public Transform ball_pos;
    public KeyCode keyShoot;
    public float force = 10f;

    PhotonView view;
    public bool isStickToPlayer;
    public GameObject ball;
    private Vector3 previousLocation;
    [SerializeField] private AudioSource SoundEffect;

    private GameObject ball1;

    void Start()
    {
        view = GetComponent<PhotonView>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            GetBallMP[] getAllObject = FindObjectsOfType<GetBallMP>();

            foreach(GetBallMP item in getAllObject)
            {
                item.isStickToPlayer = false;
            }

            // Move the ball to the player's position
            isStickToPlayer = true;
            ball = other.gameObject;
            //other.transform.position = ball_pos.position;

            
            ball1 = other.gameObject;
            photonView.RPC("Set_OtherPlayerBall", RpcTarget.OthersBuffered);
        }
    }

    void Update()
    {
        if (isStickToPlayer && ball != null)
        {
            ball = ball1;
            Vector2 currentLocation = new Vector2(transform.position.x, transform.position.z);
            float speed = Vector2.Distance(currentLocation, previousLocation) / Time.deltaTime;
            ball.transform.position = ball_pos.position;
            ball.transform.Rotate(new Vector3(transform.right.x, 0, transform.right.z), speed, Space.World);
            previousLocation = currentLocation;

            
                if (Input.GetKeyDown(keyShoot))
                {
                    // Release the ball and apply the kick force
                    Debug.Log("Have kicked");
                    SoundEffect.Play();
                    isStickToPlayer = false;
                    Rigidbody ballRigidbody = ball.GetComponent<Rigidbody>();
                    Vector3 shootDirection = transform.forward;
                    //shootDirection.y += 0.5f;

                    ballRigidbody.AddForce(shootDirection * force, ForceMode.Impulse);


                    //photonView.RPC("Set_OtherPlayerKick", RpcTarget.OthersBuffered);
                }
            
            
        }

        
    }

    public void AIShoot()
    {
        Debug.Log("AI Have kicked");
        SoundEffect.Play();
        isStickToPlayer = false;
        Rigidbody ballRigidbody = ball.GetComponent<Rigidbody>();
        Vector3 shootDirection = transform.forward;
        //shootDirection.y += 0.5f;

        ballRigidbody.AddForce(shootDirection * force, ForceMode.Impulse);
    }

    [PunRPC]
    void Set_OtherPlayerBall()
    {
        GetBallMP[] obj = FindObjectsOfType<GetBallMP>();
        foreach (GetBallMP item in obj)
        {
            item.isStickToPlayer = false;
        }

        isStickToPlayer = true;
        ball = ball1;
    }

    [PunRPC]
    void Set_OtherPlayerKick()
    {
        // Release the ball and apply the kick force
        Debug.Log("Have kicked");
        SoundEffect.Play();
        isStickToPlayer = false;
        Rigidbody ballRigidbody = ball.GetComponent<Rigidbody>();
        Vector3 shootDirection = transform.forward;
        //shootDirection.y += 0.5f;

        ballRigidbody.AddForce(shootDirection * force, ForceMode.Impulse);
    }
}
