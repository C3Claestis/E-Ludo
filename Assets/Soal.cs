using UnityEngine;

public class Soal : MonoBehaviour
{
    [SerializeField] GameObject panel_soal_bali, panel_soal_dki, panel_soal_sulsel, panel_soal_sumbar;
    [SerializeField] int _count;    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player Bali")
        {
            if(collision.GetComponent<Player>()._stak != _count)
            {
                panel_soal_bali.SetActive(true);
                collision.GetComponent<Player>()._stak = _count;
            }
        }
        else if (collision.gameObject.name == "Player DKI")
        {
            if (collision.GetComponent<Player>()._stak != _count)
            {
                panel_soal_dki.SetActive(true);
                collision.GetComponent<Player>()._stak = _count;
            }
        }
        else if (collision.gameObject.name == "Player Sulsel")
        {
            if (collision.GetComponent<Player>()._stak != _count)
            {
                panel_soal_sulsel.SetActive(true);
                collision.GetComponent<Player>()._stak = _count;
            }
        }
        else if (collision.gameObject.name == "Player Sumbar")
        {
            if (collision.GetComponent<Player>()._stak != _count)
            {
                panel_soal_sumbar.SetActive(true);
                collision.GetComponent<Player>()._stak = _count;
            }
        }
    }
}
