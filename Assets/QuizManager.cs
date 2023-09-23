using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip benar, salah, sfxRandom, sfxcoin;
    [SerializeField] GameObject[] _display_soal;
    [SerializeField] GameObject awal;
    [SerializeField] Koin koin;
    int random;
    public int min, max;
    public bool soal_biasa;
    private void OnEnable()
    {
        awal.SetActive(true);       
    }
    public void Quiz()
    {
        random = Random.Range(min, max);
        audioSource.PlayOneShot(sfxRandom);
        _display_soal[random].SetActive(true);
        awal.SetActive(false);
    }
    public void Soal(int scan)
    {
        if (soal_biasa)
        {
            if (scan == 1)
            {
                audioSource.PlayOneShot(sfxcoin);
                koin.coin += 2;
                koin._hitung_koin += 2;
                audioSource.PlayOneShot(benar);
                StartCoroutine(Wait());
            }
            else
            {
                audioSource.PlayOneShot(sfxcoin);
                koin.coin -= 1;
                koin._hitung_koin -= 1;
                audioSource.PlayOneShot(salah);
                StartCoroutine(Wait());
            }
        }
        else
        {
            if (scan == 1)
            {
                audioSource.PlayOneShot(sfxcoin);
                koin.coin += 3;
                koin._hitung_koin += 3;
                audioSource.PlayOneShot(benar);
                StartCoroutine(Wait());
            }
            else
            {
                audioSource.PlayOneShot(sfxcoin);
                koin.coin -= 1;
                koin._hitung_koin -= 1;
                audioSource.PlayOneShot(salah);
                StartCoroutine(Wait());
            }
        }
        
    }    

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
        _display_soal[random].SetActive(false);
        gameObject.SetActive(false);
    }
}
