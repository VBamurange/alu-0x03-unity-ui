using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 50f;
    private int score = 0;
    public int health = 5;

    public Text scoreText;
    public Text healthText;
    public Text winLoseText;
    public Image winLoseBG;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        SetScoreText();
        SetHealthText();
    }


    void Update()
    {

        if (health == 0)
        {
            GameOver();

        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            LoadMenu();
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
            SetScoreText();
            ;// UnityEngine.Debug.Log("Score: " + score);
            other.gameObject.SetActive(false);
        }
        else if (other.gameObject.CompareTag("Trap"))
        {
            health--;
            SetHealthText();
            // Debug.Log("Health: " + health);
        }
        else if (other.gameObject.CompareTag("Goal"))
        {
            WinGame();
            //Debug.Log("You win!");
        }
    }
    void SetScoreText()
    {
        scoreText.text = "Score: " + score;

    }
    void SetHealthText()
    {
        healthText.text = "Health: " + health;
    }
    void WinGame()
    {
        winLoseBG.gameObject.SetActive(true);
        winLoseText.text = "You win!";
        winLoseText.color = Color.black;
        winLoseBG.color = Color.green;
        StartCoroutine(LoadScene(3));
    }
    void GameOver()
    {
        winLoseBG.gameObject.SetActive(true);
        winLoseText.text = "Game Over!";
        winLoseText.color = Color.white;
        winLoseBG.color = Color.red;
        StartCoroutine(LoadScene(3));
    }
    IEnumerator LoadScene(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    void LoadMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
