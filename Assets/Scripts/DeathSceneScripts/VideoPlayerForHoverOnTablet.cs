using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;


public class VideoPlayerForHoverOnTablet : MonoBehaviour
{
    private int videoIndex;
    private Vector3 originalPosition;
    private Quaternion originalRotation;
    string playerDiedAt = "";

    public VideoPlayer videoPlayer;
    public VideoClip[] videoClips;
    public int levelOfPlayerDeath = 1;


    public GameObject videoPlayerGameObject;
    void Start()
    {
        videoIndex = levelOfPlayerDeath;
        videoPlayerGameObject.SetActive(false);
        originalPosition = transform.position;
        originalRotation = transform.rotation;

    }

    void Update()
    {
        if (transform.position != originalPosition)
        {
            transform.position = originalPosition;
            transform.rotation = originalRotation;
        }
        
    }


    public void PlayVideo() {
        videoIndex = GlobalState.GetLevel() - 1;
        videoPlayerGameObject.SetActive(true);
        if (videoPlayer.isPlaying) {
            videoPlayer.Stop();
            videoPlayer.clip = videoClips[videoIndex];
            videoPlayer.Play();
        } else {
            videoPlayer.clip = videoClips[videoIndex];
            videoPlayer.Play();
        }
    }

    public void StopVideo() {
        if (videoPlayer.isPlaying) {
            videoPlayer.Stop();
            videoPlayerGameObject.SetActive(false);
        }
    }

    void SelectVideoIndex(string deathLocation) {
        switch (deathLocation) {

        }
    }
}
