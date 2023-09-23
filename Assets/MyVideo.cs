using System.Collections;
using UnityEngine.Video;
using UnityEngine;

public class MyVideo : MonoBehaviour
{
    [SerializeField] GameObject play, pause;   
    [SerializeField] VideoPlayer videoPlayer;
    [SerializeField] string videoFileName;
    private void Start()
    {        
        PlayVideo();
    }
    public void PlayVideo()
    {
        if (videoPlayer)
        {
            string path = System.IO.Path.Combine(Application.streamingAssetsPath, videoFileName);
            Debug.Log(path);
            videoPlayer.url = path;
            videoPlayer.Play();
        }
    }
    public void VideoPause()
    {
        videoPlayer.Play();
        pause.SetActive(false);
        play.SetActive(true);
    }
    public void VideoPlay()
    {
        videoPlayer.Pause();
        pause.SetActive(true);
        play.SetActive(false);
    }
}
