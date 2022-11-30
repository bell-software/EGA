using System.Collections;
using System.Collections.Generic;
using UnityEngine.Video;
using UnityEngine;
using UnityEngine.UI;

public class VideoInteractionController : InteractionController
{
    public VideoClip videoToPlay;

    public GameObject videoPlayerHolder;

    public VideoPlayer videoPlayer;

    public Slider videoPlayerSlider;

    public Image playButton;

    public Sprite playButtonIcon;


    public Sprite pauseButtonIcon;

    public override void Start()
    {
        base.Start();
        videoPlayer.clip = videoToPlay;
    }

    public override void OnStart(int args)
    {
        base.OnStart(args);




    }

    public override void OnComplete(int arg)
    {
        base.OnComplete(arg);
    }


    public void TogglePlayPause()
    {
        if (!videoPlayer.isPlaying)
        {
            videoPlayer.Play();
            playButton.sprite = playButtonIcon;
        }

        else

        {
            videoPlayer.Pause();

            playButton.sprite = pauseButtonIcon;
        }
    }

    public void VolumeController()
    {
        
        videoPlayer.SetDirectAudioVolume(0, videoPlayerSlider.value);
    }

    public void QuitVideoPlayer()
    {
        videoPlayer.Stop();
        videoPlayerHolder.SetActive(false);
       
    
    }

}
