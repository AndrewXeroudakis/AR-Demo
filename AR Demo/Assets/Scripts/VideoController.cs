using easyar;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoController : MonoBehaviour
{
    public GameObject videoQuad;
    UnityEngine.Video.VideoPlayer videoPlayer;

    private void Start()
    {
        videoPlayer = videoQuad.GetComponent<UnityEngine.Video.VideoPlayer>();
    }

    public void PlayVideo()
    {
        videoPlayer.Play();
    }

    public void PauseVideo()
    {
        videoPlayer.Pause();
    }
}
