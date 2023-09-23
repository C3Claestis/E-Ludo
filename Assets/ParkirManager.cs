using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkirManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSource, gameBGM;
    [SerializeField] AudioClip clip;
    [SerializeField] GameObject video, panel_manager;
    [SerializeField] LudoManager ludoManager;
    public void Tonton()
    {
        gameBGM.Stop();
        video.SetActive(true);
    }
    public void BackGame()
    {
        gameBGM.Play();
        video.SetActive(false);
        panel_manager.SetActive(false);
        ludoManager._finishClear = true;
    }
}
