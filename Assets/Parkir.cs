using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parkir : MonoBehaviour
{
    [SerializeField] GameObject panel_parkir;
    [SerializeField] LudoManager ludoManager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            panel_parkir.SetActive(true);
            ludoManager._finishClear = false;
        }
    }
}
