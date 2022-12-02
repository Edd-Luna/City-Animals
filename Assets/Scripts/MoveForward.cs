using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed = 5.0f;
    private float zDestroy = -50.0f;
    private float xEdge = 14f;
    private Rigidbody objectRb;
    // Start is called before the first frame update
    void Start()
    {
        objectRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        objectRb.AddForce(Vector3.forward * -speed);
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
