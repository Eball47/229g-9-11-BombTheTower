using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class BirdController : MonoBehaviour
{
    public float jumpForce = 5f;
    public Rigidbody rb;
    public int playerScore ;
    public int winScore; // Set your win condition score here
    public AudioClip flapSound;
    private AudioSource audioSource;
    public TextMeshProUGUI scoreText;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        UpdateScoreText();
    }
    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector3.up * jumpForce;
            PlayFlapSound();
        }

        

    }
    public void UpdateScoreText()
        {
            scoreText.text = $"{playerScore} / 11";
        }
    void PlayFlapSound()
    {
        audioSource.PlayOneShot(flapSound);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pipe"))
        {
            playerScore++;
            UpdateScoreText();
        }
        if (other.CompareTag("Dead"))
        {
            SceneManager.LoadScene("SampleScene");
        }
        if (playerScore >= winScore)
        {
            SceneManager.LoadScene("NextScene"); // Load next scene when score reaches winScore
        }
    }
   

}