using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 45f;
    private int score = 0;
    public int health = 5;
    
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {

            if (health == 0)
            {
                Debug.Log("Game Over!");
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                ResetPlayer();
            }
        }

         void FixedUpdate()
        {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        rb.AddForce(new Vector3(horizontal, 0.0f, vertical) * (speed * Time.deltaTime));
        }

         void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Pickup"))
            {
                score++;
                Debug.Log("Score: " + score);
                other.gameObject.SetActive(false);
            }
            else if (other.gameObject.CompareTag("Trap"))
            {
                health--;
                Debug.Log("Health: " + health);
            }
            else if (other.gameObject.CompareTag("Goal"))
            {
                Debug.Log("You win!");
            }
        }
    }
