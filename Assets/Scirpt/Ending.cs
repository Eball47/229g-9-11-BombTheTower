using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{
    public VideoPlayer videoPlayer; // Reference to the VideoPlayer component

    void Start()
    {
        // Get the VideoPlayer component attached to this GameObject
        videoPlayer = GetComponent<VideoPlayer>();

        // Subscribe to the video player's loopPointReached event
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        // Load the next scene when the video ends
        SceneManager.LoadScene("Credit");
    }
}
