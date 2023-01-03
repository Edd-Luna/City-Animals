using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalsMove : MonoBehaviour
{
    public float speed = 5.0f;
    private float zDestroy = -50.0f;
    private float xEdge = 14f;
    private Rigidbody objectRb;
    private PlayerController playerControllerScript;
    private Animator animalAnim;
    // Start is called before the first frame update
    void Start()
    {
        objectRb = GetComponent<Rigidbody>();
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        animalAnim = GetComponent<Animator>();
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
            objectRb.velocity = new Vector3( 0.0f, 0.0f,  0.0f);
            if(gameObject.CompareTag("Enemy"))
            {
                //Destroy(gameObject);
                animalAnim.SetFloat("Speed_f", 0f);
                animalAnim.SetBool("Eat_b", true);
            }
        }
        
        if(transform.position.z < zDestroy)
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
}
