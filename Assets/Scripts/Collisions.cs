using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisions : MonoBehaviour
{
    public ParticleSystem explosionParticle;
    public ParticleSystem pointParticle;
    private GameManager Manager;
    private PlayerController playerControllerScript;


     void Start()
    {
       Manager = GameObject.Find("GameManager").GetComponent<GameManager>();
       playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();

    }


    private void OnCollisionEnter(Collision collision) 
    {
        if(playerControllerScript.gameOver == false)
        {
        if(gameObject.CompareTag("Obstacle") && collision.gameObject.CompareTag("Bomb"))
        {
            playerControllerScript.playerAudio.PlayOneShot(playerControllerScript.failSound, 1.0f);
            collision.gameObject.SetActive(false);
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            
            
        }
        
        if(gameObject.CompareTag("Enemy") && collision.gameObject.CompareTag("Apple"))
        {
            playerControllerScript.playerAudio.PlayOneShot(playerControllerScript.scoreSound, 1.0f);
            collision.gameObject.SetActive(false);
            Destroy(gameObject);
            Debug.Log("collision apple");
            Instantiate(pointParticle, transform.position, pointParticle.transform.rotation);
            Manager.playerScore += 1;
        }

        if((gameObject.CompareTag("Barrier") || gameObject.CompareTag("Obstacle")) && (collision.gameObject.CompareTag("Bomb") || collision.gameObject.CompareTag("Apple")))
        {
            collision.gameObject.SetActive(false);
        }
        
        if(gameObject.CompareTag("Enemy") && collision.gameObject.CompareTag("Bomb"))
        {
            playerControllerScript.playerAudio.PlayOneShot(playerControllerScript.failSound, 1.0f);
            collision.gameObject.SetActive(false);
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            Manager.playerLifes -= 1;
            
        }
        }
    }
}
