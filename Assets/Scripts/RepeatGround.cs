using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatGround : MonoBehaviour
{
    private Vector3 startPos;
    private float repeatWidth;
    private float speed = 20;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        repeatWidth = GetComponent<BoxCollider>().size.z / 2;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * speed);
        if(transform.position.z < startPos.z - repeatWidth)
        {
            transform.position = startPos;
        }
    }
}