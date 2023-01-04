using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private float speed= 500f;
    private float jumpForce = 200f;
    private float xEdge = 13f;
    private float yEdge = 1f;
    private float zEdge = -41.0f;
    private Rigidbody playerRb;
    private GameManager Manager;
    private Animator playerAnim;
    public ParticleSystem lifeParticle;
    public ParticleSystem deathParticle;
    public bool gameOver;
    public GameObject Diamond;
    public TextMeshProUGUI scoreAndLifes;
    public TextMeshProUGUI gameOverText;
    public AudioSource playerAudio;
    public AudioClip failSound;
    public AudioClip scoreSound;
    public AudioClip powerUpSound;
    


    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        Manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        playerAudio = GetComponent<AudioSource>();
        gameOver = false;
    }

    void Update()
    {
        scoreAndLifes.text = "Score:" + Manager.playerScore + "<br>Extra Lifes:" + Manager.playerLifes;
        if(!gameOver)
        {
        MovePlayer();
        if(Manager.playerLifes > 0)
        {
            Diamond.SetActive(true);
        }
        else
        {
            Diamond.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            GameObject pooledProjectile = ObjectPooler.SharedInstance.GetPooledObjectFood();
            if (pooledProjectile != null)
            {
                pooledProjectile.SetActive(true); // activate it
                pooledProjectile.transform.position = new Vector3(transform.position.x, transform.position.y + 1.0f, transform.position.z  + 2.0f); // position it at player
            }
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            GameObject pooledProjectile = ObjectPooler.SharedInstance.GetPooledObjectBomb();
            if (pooledProjectile != null)
            {
                pooledProjectile.SetActive(true); // activate it
                pooledProjectile.transform.position = new Vector3(transform.position.x,transform.position.y + 1.0f, transform.position.z  + 2.0f); // position it at player
            }
        }

        if(Manager.playerLifes < 0)
        {
            Instantiate(deathParticle, transform.position, lifeParticle.transform.rotation);
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 2);
            gameOver = true;
            Manager.GameOver();
            gameOverText.gameObject.SetActive(true);
            gameOverText.text = "Game Over!";
            
        }
        }
    }


    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        {
            playerRb.AddForce(Vector3.right * speed * horizontalInput);
            
        if(transform.position.x > xEdge)
        {
            transform.position = new Vector3( xEdge, transform.position.y, transform.position.z);
            playerRb.velocity = new Vector3( 0.0f, playerRb.velocity.y, playerRb.velocity.z);
            playerRb.AddForce(Vector3.left *4, ForceMode.VelocityChange);
        }
        if(transform.position.x < - xEdge)
        {
            transform.position = new Vector3(-xEdge, transform.position.y, transform.position.z);
            playerRb.velocity = new Vector3( 0.0f, playerRb.velocity.y, playerRb.velocity.z);
            playerRb.AddForce(Vector3.right *3, ForceMode.VelocityChange);
        }
        if(transform.position.z < zEdge)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zEdge);
            playerRb.velocity = new Vector3( playerRb.velocity.x, playerRb.velocity.y, 0.0f);
            playerRb.AddForce(Vector3.forward *3, ForceMode.VelocityChange);
        }
        }
        
        if(Input.GetKeyDown(KeyCode.Space) && transform.position.y <= yEdge)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerAnim.SetBool("Jump_b", true);
        }
    }

    private void OnCollisionEnter(Collision collision) 
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            if(Manager.playerLifes <= 0)
            {
            gameOver = true;
            Manager.GameOver();
            Instantiate(deathParticle, transform.position, lifeParticle.transform.rotation);
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 2);
            Destroy(collision.gameObject);
            gameOverText.gameObject.SetActive(true);
            gameOverText.text = "Animal Collision, Game Over!";
            playerAudio.PlayOneShot(failSound, 1.0f);
            }
            else 
            {
                Destroy(collision.gameObject);
                Instantiate(lifeParticle, transform.position, lifeParticle.transform.rotation);
                Manager.playerLifes -= 1;
            }           
        }

        if(collision.gameObject.CompareTag("Obstacle") || collision.gameObject.CompareTag("Barrier"))
        {
            if(Manager.playerLifes <= 0)
            {
            gameOver = true;
            Manager.GameOver();
            Instantiate(deathParticle, transform.position, lifeParticle.transform.rotation);
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 2);
            gameOverText.gameObject.SetActive(true);
            gameOverText.text = "Obstacle Collision, Game Over!";
            playerAudio.PlayOneShot(failSound, 1.0f);
            }
            else
            {
                Destroy(collision.gameObject);
                Instantiate(lifeParticle, transform.position, lifeParticle.transform.rotation);
                Manager.playerLifes -= 1;
            }
        }   
        
        else if (collision.gameObject.CompareTag("Ground"))
       {
         playerAnim.SetBool("Jump_b", false);
       }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Powerup"))
        {
            Destroy(other.gameObject);
            Manager.playerLifes += 1;
            Instantiate(lifeParticle, transform.position, lifeParticle.transform.rotation);
            playerAudio.PlayOneShot(powerUpSound, 1.0f);
        }
    }

    

}
