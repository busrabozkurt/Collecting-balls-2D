using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerMovement : MonoBehaviour
{
   
    Timer timer;
    public Rigidbody playerRb;
    public Vector3 movement;
    public float speed = 10.0f;
    
    public float xRange = 35.0f;
    public float zRange = 13.5f;
    
    //private float turboSpeed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        //i called the timer from Timer Script.Took reference.
        timer = GameObject.Find("Canvas").GetComponent<Timer>(); 
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {        
        MovePlayer();
    }
    void MovePlayer()
    {
        //moves left and right along x axis.
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * speed * Time.deltaTime * horizontalInput);

        //moves up and down along z axis.
        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * speed * Time.deltaTime * verticalInput);
        PlayerBoundPosition();
    }
    public void PlayerBoundPosition()
    {
        if(transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        else if(transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        if(transform.position.z < -zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zRange);
        }
        else if(transform.position.z > zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Capsule"))
        {
            Destroy(other.gameObject);
            timer.capsuleCount++;
        }
        if (other.gameObject.CompareTag("Bomb"))
        {
            Destroy(gameObject);
            Debug.Log("Game Over!!");
            Timer.isGameOver = true;
           
        }
    }
}
