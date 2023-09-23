using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tambah : MonoBehaviour
{
    [SerializeField] Koin manager_bali, manager_dki, manager_sulsel, manager_sumbar;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip clip;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player Bali")
        {
            manager_bali.coin++;
            manager_bali._hitung_koin++;
            audioSource.PlayOneShot(clip);
            Animator animator = collision.GetComponentInChildren<Animator>();
            animator.Play("angka_kurang");
        }
        else if (collision.gameObject.name == "Player DKI")
        {
            manager_dki.coin++;
            manager_dki._hitung_koin++;
            audioSource.PlayOneShot(clip);
            Animator animator = collision.GetComponentInChildren<Animator>();
            animator.Play("angka_kurang");
        }
        else if (collision.gameObject.name == "Player Sulsel")
        {
            manager_sulsel.coin++;
            manager_sulsel._hitung_koin++;
            audioSource.PlayOneShot(clip);
            Animator animator = collision.GetComponentInChildren<Animator>();
            animator.Play("angka_kurang");
        }
        else if (collision.gameObject.name == "Player Sumbar")
        {
            manager_sumbar.coin++;
            manager_sumbar._hitung_koin++;
            audioSource.PlayOneShot(clip);
            Animator animator = collision.GetComponentInChildren<Animator>();
            animator.Play("angka_kurang");
        }
    }
}
