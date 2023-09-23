using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MateriManager : MonoBehaviour
{
    [SerializeField] GameObject[] _display_soal;
    [SerializeField] GameObject awal, sudahPaham, belumPaham;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip paham, tidakpaham, sfxRandom;
    int random;
   
    private void OnEnable()
    {
        awal.SetActive(true);        
    }
    public void Materi()
    {
        random = Random.Range(0, 20);
        audioSource.PlayOneShot(sfxRandom);
        _display_soal[random].SetActive(true);
        awal.SetActive(false);
    }
    public void Paham()
    {
        audioSource.PlayOneShot(paham);
        StartCoroutine(SudahPaham());
    }
    public void Belom()
    {
        audioSource.PlayOneShot(tidakpaham);
        StartCoroutine(BelumPaham());
    }
    IEnumerator SudahPaham()
    {
        sudahPaham.SetActive(true);
        yield return new WaitForSeconds(1f);
        sudahPaham.SetActive(false);
        _display_soal[random].SetActive(false);
        gameObject.SetActive(false);
    }
    IEnumerator BelumPaham()
    {
        belumPaham.SetActive(true);
        yield return new WaitForSeconds(3f);
        belumPaham.SetActive(false);
    }
}
