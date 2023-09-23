using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
public class Knob : MonoBehaviour
{
    [SerializeField] VideoPlayer videoPlayer;
    Slider slider;
    bool _on_drag = false;
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    public void OnDrag()
    {
        _on_drag = true;
    }
    public void OnUp()
    {
        _on_drag = false;
        float frame = (float)slider.value * (float)videoPlayer.frameCount;
        videoPlayer.frame = (long)frame;
    }
    private void Update()
    {
        if(videoPlayer.isPlaying && !_on_drag)
        {
            slider.value = (float)videoPlayer.frame / (float)videoPlayer.frameCount;
        }
    }
}
