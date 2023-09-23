using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Refresh : MonoBehaviour
{
    [SerializeField] Dadu dadu1, dadu2, dadu3, dadu4;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip audioClip;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (dadu1._refresh && dadu2._refresh && dadu3._refresh && dadu4._refresh)
            {
                audioSource.PlayOneShot(audioClip);
                dadu1._refresh = false;
                dadu2._refresh = false;
                dadu3._refresh = false;
                dadu4._refresh = false;
            }
            else
            {
                audioSource.PlayOneShot(audioClip);
                dadu1._refresh = true;
                dadu2._refresh = true;
                dadu3._refresh = true;
                dadu4._refresh = true;
            }
        }        
    }
}
