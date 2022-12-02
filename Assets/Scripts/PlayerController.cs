using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed= 400f;
    private float jumpForce = 200f;
    private float xEdge = 13f;
   // private float zEdge1 = -15.0f;
    //private float zEdge2 = -48.5f;
    private float yEdge = 1f;
    private Rigidbody playerRb;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();

        if(transform.position.x > xEdge)
        {
            transform.position = new Vector3( xEdge, transform.position.y, transform.position.z);
            playerRb.velocity = new Vector3( 0.0f, playerRb.velocity.y, playerRb.velocity.z);
            playerRb.AddForce(Vector3.left *3, ForceMode.VelocityChange);
        }
        if(transform.position.x < - xEdge)
        {
            transform.position = new Vector3(-xEdge, transform.position.y, transform.position.z);
            playerRb.velocity = new Vector3( 0.0f, playerRb.velocity.y, playerRb.velocity.z);
            playerRb.AddForce(Vector3.right *3, ForceMode.VelocityChange);
        }
        /*if(transform.position.z > zEdge1)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zEdge1);
            playerRb.velocity = new Vector3(playerRb.velocity.x, playerRb.velocity.y, 0.0f);
            playerRb.AddForce(Vector3.back *3, ForceMode.VelocityChange);
        }
        if(transform.position.z < zEdge2)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zEdge2);
            playerRb.velocity = new Vector3(playerRb.velocity.x, playerRb.velocity.y, 0.0f);
            playerRb.AddForce(Vector3.forward *3, ForceMode.VelocityChange);
        }*/
    }


    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        //float verticalInput = Input.GetAxis("Vertical");

        //playerRb.AddForce(Vector3.forward * speed * verticalInput);
        if ( transform.position.y <= yEdge)
        {
            playerRb.AddForce(Vector3.right * speed * horizontalInput);
        }
        

        if(Input.GetKeyDown(KeyCode.Space) && transform.position.y <= yEdge)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision) 
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Player has collied with enemy.");
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Powerup"))
        {
            Destroy(other.gameObject);
        }
    }

}
