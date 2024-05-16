
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 25f;
    private int score = 0;
    public int health = 5;
    private int initialHealth;
    private float vertical;
    private float horizontal;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.frameCount % 10 == 0)
        {


            if (health <= 0)
            {
                Debug.Log("Game Over!");
                health = 5;
                score = 0;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }

         void FixedUpdate()
        {
            PlayerMovements();
        }


         void PlayerMovements()
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");
        }

         void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Pickup"))
            {
                score++;
                Debug.Log("Score: " + score);
                Destroy(other.gameObject);
            }
            if (other.CompareTag("Trap"))
            {
                health--;
                Debug.Log("Health: " + health);
            }
            if (other.CompareTag("Goal"))
            {
                Debug.Log("You win!");
            }
        }
    } }
