using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BuyManager : MonoBehaviour
{
    [SerializeField] LudoManager ludoManager;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip buy, noBuy;
    [SerializeField] Winner winner;
    [SerializeField] Koin _coin_bali, _coin_dki, _coin_sulsel, _coin_sumbar;
    [SerializeField] Text rumah_bali, rumah_dki, rumah_sulsel, rumah_sumbar;
    [SerializeField] GameObject _animasi_kurang, _animasi_beli;
    [SerializeField] GameObject _panel_bali, _panel_dki, _panel_sulsel, _panel_sumbar;
    int bali, dki, sulsel, sumbar;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Time.timeScale = 1;
        }
        rumah_bali.text = bali.ToString();
        rumah_dki.text = dki.ToString();
        rumah_sulsel.text = sulsel.ToString();
        rumah_sumbar.text = sumbar.ToString();
    }
    IEnumerator Beli()
    {        
        _animasi_beli.SetActive(true);
        audioSource.PlayOneShot(buy);
        yield return new WaitForSeconds(3f);
        _animasi_beli.SetActive(false);
        ludoManager._finishClear = true;
    }
    IEnumerator Kurang()
    {        
        _animasi_kurang.SetActive(true);
        audioSource.PlayOneShot(noBuy);
        yield return new WaitForSeconds(3f);
        _animasi_kurang.SetActive(false);
        ludoManager._finishClear = true;
    }
    public void Bali()
    {        
        if(_coin_bali.coin < 6)
        {
            StartCoroutine(Kurang());
            _panel_bali.SetActive(false);
        }
        else if(_coin_bali.coin >= 6 && _coin_bali.coin < 12)
        {
            bali = 1; StartCoroutine(Beli());
            _panel_bali.SetActive(false);
            _coin_bali.coin -= 6;
        }
        else if (_coin_bali.coin >= 12 && _coin_bali.coin < 18)
        {
            bali = 2; StartCoroutine(Beli());
            _panel_bali.SetActive(false);
            _coin_bali.coin -= 12;
        }
        else if (_coin_bali.coin >= 18 && _coin_bali.coin < 24)
        {
            bali = 3; StartCoroutine(Beli()); _panel_bali.SetActive(false);
            _coin_bali.coin -= 18;
        }
        else if (_coin_bali.coin >= 24 && _coin_bali.coin < 30)
        {
            bali = 4; StartCoroutine(Beli()); _panel_bali.SetActive(false);
            _coin_bali.coin -= 24;
        }
        else if (_coin_bali.coin >= 30 && _coin_bali.coin < 36)
        {
            bali = 5; StartCoroutine(Beli()); _panel_bali.SetActive(false);
            _coin_bali.coin -= 30;
        }
        else if (_coin_bali.coin >= 36 && _coin_bali.coin < 42)
        {
            bali = 6; StartCoroutine(Beli()); _panel_bali.SetActive(false);
            _coin_bali.coin -= 36;
        }
        else if (_coin_bali.coin >= 42 && _coin_bali.coin < 48)
        {
            bali = 7; StartCoroutine(Beli()); _panel_bali.SetActive(false);
            _coin_bali.coin -= 42;
        }
        else if (_coin_bali.coin >= 48 && _coin_bali.coin < 54)
        {
            bali = 8; StartCoroutine(Beli()); _panel_bali.SetActive(false);
            _coin_bali.coin -= 48;
        }
        else if (_coin_bali.coin >= 54 && _coin_bali.coin < 60)
        {
            bali = 9; StartCoroutine(Beli()); _panel_bali.SetActive(false);
            _coin_bali.coin -= 54;
        }
        else if (_coin_bali.coin >= 60 && _coin_bali.coin < 66)
        {
            bali = 10; StartCoroutine(Beli()); _panel_bali.SetActive(false);
            _coin_bali.coin -= 60;
        }
        else if (_coin_bali.coin >= 66 && _coin_bali.coin < 72)
        {
            bali = 11; StartCoroutine(Beli()); _panel_bali.SetActive(false);
            _coin_bali.coin -= 66;
        }
        winner._finisher++;
    }

    public void DKI()
    {
        if (_coin_dki.coin < 6)
        {
            StartCoroutine(Kurang());
            _panel_dki.SetActive(false);
        }
        else if (_coin_dki.coin >= 6 && _coin_dki.coin < 12)
        {
            dki = 1; StartCoroutine(Beli());
            _panel_dki.SetActive(false);
            _coin_dki.coin -= 6;
        }
        else if (_coin_dki.coin >= 12 && _coin_dki.coin < 18)
        {
            dki = 2; StartCoroutine(Beli());
            _panel_dki.SetActive(false);
            _coin_dki.coin -= 12;
        }
        else if (_coin_dki.coin >= 18 && _coin_dki.coin < 24)
        {
            dki = 3; StartCoroutine(Beli()); _panel_dki.SetActive(false);
            _coin_dki.coin -= 18;
        }
        else if (_coin_dki.coin >= 24 && _coin_dki.coin < 30)
        {
            dki = 4; StartCoroutine(Beli()); _panel_dki.SetActive(false);
            _coin_dki.coin -= 24;
        }
        else if (_coin_dki.coin >= 30 && _coin_dki.coin < 36)
        {
            dki = 5; StartCoroutine(Beli()); _panel_dki.SetActive(false);
            _coin_dki.coin -= 30;
        }
        else if (_coin_dki.coin >= 36 && _coin_dki.coin < 42)
        {
            dki = 6; StartCoroutine(Beli()); _panel_dki.SetActive(false);
            _coin_dki.coin -= 36;
        }
        else if (_coin_dki.coin >= 42 && _coin_dki.coin < 48)
        {
            dki = 7; StartCoroutine(Beli()); _panel_dki.SetActive(false);
            _coin_dki.coin -= 42;
        }
        else if (_coin_dki.coin >= 48 && _coin_dki.coin < 54)
        {
            dki = 8; StartCoroutine(Beli()); _panel_dki.SetActive(false);
            _coin_dki.coin -= 48;
        }
        else if (_coin_dki.coin >= 54 && _coin_dki.coin < 60)
        {
            dki = 9; StartCoroutine(Beli()); _panel_dki.SetActive(false);
            _coin_dki.coin -= 54;
        }
        else if (_coin_dki.coin >= 60 && _coin_dki.coin < 66)
        {
            dki = 10; StartCoroutine(Beli()); _panel_dki.SetActive(false);
            _coin_dki.coin -= 60;
        }
        else if (_coin_dki.coin >= 66 && _coin_dki.coin < 72)
        {
            dki = 11; StartCoroutine(Beli()); _panel_dki.SetActive(false);
            _coin_dki.coin -= 66;
        }
        winner._finisher++;
    }
    public void Sulsel()
    {
        if (_coin_sulsel.coin < 6)
        {
            StartCoroutine(Kurang());
            _panel_sulsel.SetActive(false);
        }
        else if (_coin_sulsel.coin >= 6 && _coin_sulsel.coin < 12)
        {
            sulsel = 1; StartCoroutine(Beli());
            _panel_sulsel.SetActive(false);
            _coin_sulsel.coin -= 6;
        }
        else if (_coin_sulsel.coin >= 12 && _coin_sulsel.coin < 18)
        {
            sulsel = 2; StartCoroutine(Beli());
            _panel_sulsel.SetActive(false);
            _coin_sulsel.coin -= 12;
        }
        else if (_coin_sulsel.coin >= 18 && _coin_sulsel.coin < 24)
        {
            sulsel = 3; StartCoroutine(Beli()); _panel_sulsel.SetActive(false);
            _coin_sulsel.coin -= 18;
        }
        else if (_coin_sulsel.coin >= 24 && _coin_sulsel.coin < 30)
        {
            sulsel = 4; StartCoroutine(Beli()); _panel_sulsel.SetActive(false);
            _coin_sulsel.coin -= 24;
        }
        else if (_coin_sulsel.coin >= 30 && _coin_sulsel.coin < 36)
        {
            sulsel = 5; StartCoroutine(Beli()); _panel_sulsel.SetActive(false);
            _coin_sulsel.coin -= 30;
        }
        else if (_coin_sulsel.coin >= 36 && _coin_sulsel.coin < 42)
        {
            sulsel = 6; StartCoroutine(Beli()); _panel_sulsel.SetActive(false);
            _coin_sulsel.coin -= 36;
        }
        else if (_coin_sulsel.coin >= 42 && _coin_sulsel.coin < 48)
        {
            sulsel = 7; StartCoroutine(Beli()); _panel_sulsel.SetActive(false);
            _coin_sulsel.coin -= 42;
        }
        else if (_coin_sulsel.coin >= 48 && _coin_sulsel.coin < 54)
        {
            sulsel = 8; StartCoroutine(Beli()); _panel_sulsel.SetActive(false);
            _coin_sulsel.coin -= 48;
        }
        else if (_coin_sulsel.coin >= 54 && _coin_sulsel.coin < 60)
        {
            sulsel = 9; StartCoroutine(Beli()); _panel_sulsel.SetActive(false);
            _coin_sulsel.coin -= 54;
        }
        else if (_coin_sulsel.coin >= 60 && _coin_sulsel.coin < 66)
        {
            sulsel = 10; StartCoroutine(Beli()); _panel_sulsel.SetActive(false);
            _coin_sulsel.coin -= 60;
        }
        else if (_coin_sulsel.coin >= 66 && _coin_sulsel.coin < 72)
        {
            sulsel = 11; StartCoroutine(Beli()); _panel_sulsel.SetActive(false);
            _coin_sulsel.coin -= 66;
        }
        winner._finisher++;
    }
    public void Sumbar()
    {
        if (_coin_sumbar.coin < 6)
        {
            StartCoroutine(Kurang());
            _panel_sumbar.SetActive(false);
        }
        else if (_coin_sumbar.coin >= 6 && _coin_sumbar.coin < 12)
        {
            sumbar = 1; StartCoroutine(Beli());
            _panel_sumbar.SetActive(false);
            _coin_sumbar.coin -= 6;
        }
        else if (_coin_sumbar.coin >= 12 && _coin_sumbar.coin < 18)
        {
            sumbar = 2; StartCoroutine(Beli());
            _panel_sumbar.SetActive(false);
            _coin_sumbar.coin -= 12;
        }
        else if (_coin_sumbar.coin >= 18 && _coin_sumbar.coin < 24)
        {
            sumbar = 3; StartCoroutine(Beli()); _panel_sumbar.SetActive(false);
            _coin_sumbar.coin -= 18;
        }
        else if (_coin_sumbar.coin >= 24 && _coin_sumbar.coin < 30)
        {
            sumbar = 4; StartCoroutine(Beli()); _panel_sumbar.SetActive(false);
            _coin_sumbar.coin -= 24;
        }
        else if (_coin_sumbar.coin >= 30 && _coin_sumbar.coin < 36)
        {
            sumbar = 5; StartCoroutine(Beli()); _panel_sumbar.SetActive(false);
            _coin_sumbar.coin -= 30;
        }
        else if (_coin_sumbar.coin >= 36 && _coin_sumbar.coin < 42)
        {
            sumbar = 6; StartCoroutine(Beli()); _panel_sumbar.SetActive(false);
            _coin_sumbar.coin -= 36;
        }
        else if (_coin_sumbar.coin >= 42 && _coin_sumbar.coin < 48)
        {
            sumbar = 7; StartCoroutine(Beli()); _panel_sumbar.SetActive(false);
            _coin_sumbar.coin -= 42;
        }
        else if (_coin_sumbar.coin >= 48 && _coin_sumbar.coin < 54)
        {
            sumbar = 8; StartCoroutine(Beli()); _panel_sumbar.SetActive(false);
            _coin_sumbar.coin -= 48;
        }
        else if (_coin_sumbar.coin >= 54 && _coin_sumbar.coin < 60)
        {
            sumbar = 9; StartCoroutine(Beli()); _panel_sumbar.SetActive(false);
            _coin_sumbar.coin -= 54;
        }
        else if (_coin_sumbar.coin >= 60 && _coin_sumbar.coin < 66)
        {
            sumbar = 10; StartCoroutine(Beli()); _panel_sumbar.SetActive(false);
            _coin_sumbar.coin -= 60;
        }
        else if (_coin_sumbar.coin >= 66 && _coin_sumbar.coin < 72)
        {
            sumbar = 11; StartCoroutine(Beli()); _panel_sumbar.SetActive(false);
            _coin_sumbar.coin -= 66;
        }
        winner._finisher++;
    }
}
