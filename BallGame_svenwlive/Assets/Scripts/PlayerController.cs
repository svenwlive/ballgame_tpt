using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Text scoreText;
    public Text winText;
    public GameObject wall;
    private Rigidbody rb;
    public int score;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        score = 0;
        SetScoreText();
        winText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);

        // Restart level
        if (Input.GetKeyDown(KeyCode.R))
        {
            Application.LoadLevel(Application.loadedLevel);  // This is a deprecated method, will change to newer when needed
        }

        // Quit game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("coin"))
        {
            other.gameObject.SetActive(false);
            score ++;
            SetScoreText();
            if(score >= 5)
            {
                wall.gameObject.SetActive(false);
            }
        }

        // Restart level if player hits anything marked as danger
        if(other.gameObject.tag == "danger")
        {
            Application.LoadLevel(Application.loadedLevel);  // This is a deprecated method, will change to newer when needed
        }
    }

    void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
        if(score >= 10)
        {
            winText.text = "You Win! Press R to restart or ESC to quit.";
        }
    }
}
