using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Materi : MonoBehaviour
{
    [SerializeField] GameObject panel_materi;
    [SerializeField] int _count;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {           
            if(collision.GetComponent<Player>()._stak != _count)
            {
                panel_materi.SetActive(true);
                collision.GetComponent<Player>()._stak = _count;
            }
        }
    }
}
