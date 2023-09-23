using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prison : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip clip;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player Bali")
        {            
            if(collision.GetComponent<Player>()._lepas_prison == false)
            {
                audioSource.PlayOneShot(clip);
                collision.GetComponent<Player>().dadu._prison = true;
            }
        }
        else if (collision.gameObject.name == "Player DKI")
        {            
            if (collision.GetComponent<Player>()._lepas_prison == false)
            {
                audioSource.PlayOneShot(clip);
                collision.GetComponent<Player>().dadu._prison = true;
            }
        }
        else if (collision.gameObject.name == "Player Sulsel")
        {            
            if (collision.GetComponent<Player>()._lepas_prison == false)
            {
                audioSource.PlayOneShot(clip);
                collision.GetComponent<Player>().dadu._prison = true;
            }
        }
        else if (collision.gameObject.name == "Player Sumbar")
        {         
            if (collision.GetComponent<Player>()._lepas_prison == false)
            {
                audioSource.PlayOneShot(clip);
                collision.GetComponent<Player>().dadu._prison = true;
            }
        }       
    }
}
