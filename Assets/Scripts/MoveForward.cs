using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed;
    private float zMinDestroy = -45.0f;
    private float zMaxObject = 65.0f;
    private float zMaxProjectile = -2.0f;
    private float xEdge = 14f;
    private Rigidbody objectRb;
    private PlayerController playerControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        objectRb = GetComponent<Rigidbody>();
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerControllerScript.gameOver == false)
        {
            objectRb.AddForce(Vector3.forward * -speed);
        }
        else 
        {
            if(gameObject.CompareTag("Obstacle") || gameObject.CompareTag("Powerup") || gameObject.CompareTag("Barrier") )
            {
                objectRb.velocity = new Vector3( 0.0f, 0.0f,  0.0f);
            }
        }
        
        if(transform.position.z < zMinDestroy)
        {
        Destroy(gameObject);
        }
        
        if(transform.position.z > zMaxProjectile && (gameObject.CompareTag("Apple") || gameObject.CompareTag("Bomb")))
        {
        gameObject.SetActive(false);
        }
        
        if(transform.position.z > zMaxObject && (gameObject.CompareTag("Obstacle") || gameObject.CompareTag("Enemy") || gameObject.CompareTag("Barrier")))
        {
            Destroy(gameObject);
        }
        if(transform.position.x > xEdge)
        {
            transform.position = new Vector3( xEdge, transform.position.y, transform.position.z);
            objectRb.velocity = new Vector3( 0.0f, objectRb.velocity.y, objectRb.velocity.z);
            objectRb.AddForce(Vector3.left *3, ForceMode.VelocityChange);
        }
        if(transform.position.x < - xEdge)
        {
            transform.position = new Vector3(-xEdge, transform.position.y, transform.position.z);
            objectRb.velocity = new Vector3( 0.0f, objectRb.velocity.y, objectRb.velocity.z);
            objectRb.AddForce(Vector3.right *3, ForceMode.VelocityChange);
        }
        }

        /*
        private void OnTriggerEnter(Collider other) 
        {
            if(other.gameObject.CompareTag("Obstacle"))
            {
            Destroy(other.gameObject);
            }
        }*/
        
    }


