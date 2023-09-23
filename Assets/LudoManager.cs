using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class LudoManager : MonoBehaviour
{
    public int _playerMove;
    [SerializeField] GameObject _icon_refresh1, _icon_refresh2, _icon_refresh3, _icon_refresh4;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip clip;
    [SerializeField] GameObject _dice1, _dice2, _dice3, _dice4;
    [SerializeField] public GameObject panel1, panel2, panel3, panel4, panel5, panel6, panel7, panel8, panel9, panel10, panel11, panel12, panel13, panel14, panel15, panel16, panel17, panel18, panel19, panel20, panel21, panel22, panel23;
    [SerializeField] Dadu dadu1, dadu2, dadu3, dadu4;
    [SerializeField] Text name_bali, name_dki, name_sulsel, name_sumbar, transisi_name_bali, transisi_name_dki, transisi_name_sulsel, transisi_name_sumbar;
    [SerializeField] Text final_name_bali, final_name_dki, final_name_sulsel, final_name_sumbar;
    [SerializeField] InputField input_name_bali, input_name_dki, input_name_sulsel, input_name_sumbar;
    [SerializeField] GameObject _button_input, _panel_awal;
    [SerializeField] Animator _animasi_awal, _player_transisi;
    [SerializeField] Text _timer;
    public float _waktu;
    private int minutes;
    private int seconds;    
    public bool _mulai, _soal;
    public bool _transisi;
    public bool _finishClear = true;
    private void Start()
    {
        int mainRandom = Random.Range(1, 12);
        _waktu = 2700f;        
        minutes = 0;
        seconds = 0;
        if(mainRandom == 1 || mainRandom == 5 || mainRandom == 9) { _playerMove = 1; }

        if (mainRandom == 2 || mainRandom == 6 || mainRandom == 10) { _playerMove = 2; }

        if (mainRandom == 3 || mainRandom == 7 || mainRandom == 11) { _playerMove = 3; }
                    
        if (mainRandom == 4 || mainRandom == 8 || mainRandom == 12) { _playerMove = 4; }
                        
    }

    private void Update()
    {
        minutes = Mathf.FloorToInt(_waktu / 60f);
        seconds = Mathf.FloorToInt(_waktu % 60f);
        string timeString = string.Format("{0:00}:{1:00}", minutes, seconds);
        _timer.text = timeString.ToString();        
        if (_waktu < 0)
        {
            _timer.text = "Selesai";            
        }
        if (_mulai)
        {                                              
            if (_soal)
            {
                _waktu -= Time.deltaTime;
                switch (_playerMove)
                {
                    case 1:
                        if (_transisi && _finishClear)
                        {
                            _player_transisi.Play("transisi_bali");
                            StartCoroutine(Dadu(true, false, false, false));
                        }
                        break;
                    case 2:
                        if (_transisi && _finishClear)
                        {
                            _player_transisi.Play("transisi_dki");
                            StartCoroutine(Dadu(false, true, false, false));
                        }
                        break;
                    case 3:
                        if (_transisi && _finishClear)
                        {
                            _player_transisi.Play("transisi_sulsel");
                            StartCoroutine(Dadu(false, false, true, false));
                        }
                        break;
                    case 4:
                        if (_transisi && _finishClear)
                        {
                            _player_transisi.Play("transisi_sumbar");
                            StartCoroutine(Dadu(false, false, false, true));
                        }
                        break;
                }
            }
          
            if (panel1.activeSelf || panel2.activeSelf || panel3.activeSelf ||
                panel4.activeSelf || panel5.activeSelf || panel6.activeSelf ||
                panel7.activeSelf || panel8.activeSelf || panel9.activeSelf ||
                panel10.activeSelf || panel11.activeSelf || panel12.activeSelf ||
                panel13.activeSelf || panel14.activeSelf || panel15.activeSelf ||
                panel16.activeSelf || panel17.activeSelf || panel18.activeSelf ||
                panel19.activeSelf || panel20.activeSelf || panel21.activeSelf ||
                panel22.activeSelf || panel23.activeSelf)
            {
                dadu1._enabled = false;
                dadu2._enabled = false;
                dadu3._enabled = false;
                dadu4._enabled = false;
                _soal = false;
            }

            if (!panel1.activeSelf && !panel2.activeSelf && !panel3.activeSelf &&
                !panel4.activeSelf && !panel5.activeSelf && !panel6.activeSelf &&
                !panel7.activeSelf && !panel8.activeSelf && !panel9.activeSelf &&
                !panel10.activeSelf && !panel11.activeSelf && !panel12.activeSelf &&
                !panel13.activeSelf && !panel14.activeSelf && !panel15.activeSelf &&
                !panel16.activeSelf && !panel17.activeSelf && !panel18.activeSelf &&
                !panel19.activeSelf && !panel20.activeSelf && !panel21.activeSelf &&
                !panel22.activeSelf && !panel23.activeSelf)
            {
                dadu1._enabled = true;
                dadu2._enabled = true;
                dadu3._enabled = true;
                dadu4._enabled = true;
                _soal = true;
            }
        }
        
        if(dadu1._refresh || dadu2._refresh || dadu3._refresh || dadu4._refresh)
        {
            _icon_refresh1.SetActive(true);
            _icon_refresh2.SetActive(true);
            _icon_refresh3.SetActive(true);
            _icon_refresh4.SetActive(true);
        }
        else {
            _icon_refresh1.SetActive(false);
            _icon_refresh2.SetActive(false);
            _icon_refresh3.SetActive(false);
            _icon_refresh4.SetActive(false);
        }
        Input();
    }    

    public void InputName()
    {
        string bali = input_name_bali.text;
        string dki = input_name_dki.text;
        string sulsel = input_name_sulsel.text;
        string sumbar = input_name_sumbar.text;

        name_bali.text = bali;
        name_dki.text = dki;
        name_sulsel.text = sulsel;
        name_sumbar.text = sumbar;

        final_name_bali.text = bali;
        final_name_dki.text = dki;
        final_name_sulsel.text = sulsel;
        final_name_sumbar.text = sumbar;

        transisi_name_bali.text = "Giliran " + bali;
        transisi_name_dki.text = "Giliran " + dki;
        transisi_name_sulsel.text = "Giliran " + sulsel;
        transisi_name_sumbar.text = "Giliran " + sumbar;

        _panel_awal.SetActive(false);
        _animasi_awal.gameObject.SetActive(true);
        switch (_playerMove)
        {
            case 1:
                _animasi_awal.Play("bali_mulai");
                _transisi = true;
                break;
            case 2:
                _animasi_awal.Play("dki_mulai");
                _transisi = true;
                break;
            case 3:
                _animasi_awal.Play("sulsel_mulai");
                _transisi = true;
                break;
            case 4:
                _animasi_awal.Play("sumbar_mulai");
                _transisi = true;
                break;

        }
        StartCoroutine(Animasi());
    }
    private void Input()
    {
        string bali = input_name_bali.text;
        string dki = input_name_dki.text;
        string sulsel = input_name_sulsel.text;
        string sumbar = input_name_sumbar.text;

        if (!bali.Equals("") && !dki.Equals("") && !sulsel.Equals("") && !sumbar.Equals(""))
        {
            _button_input.SetActive(true);
        }
        else
        {
            _button_input.SetActive(false);
        }
    }
    IEnumerator Animasi()
    {
        yield return new WaitForSeconds(5f);
        _animasi_awal.gameObject.SetActive(false);
        yield return new WaitForSeconds(2f);
        _mulai = true;
    }
    IEnumerator Dadu(bool dice1, bool dice2, bool dice3, bool dice4)
    {                      
        yield return new WaitForSeconds(3f);

        _dice1.SetActive(dice1);
        _dice2.SetActive(dice2);
        _dice3.SetActive(dice3);
        _dice4.SetActive(dice4);        
        _transisi = false;
    }    

    public void PrisonBayarBali()
    {
        audioSource.PlayOneShot(clip);
        dadu1._lepasPrison = true;
        panel16.SetActive(false);
    }
    public void PrisonBayarDKI()
    {
        audioSource.PlayOneShot(clip);
        dadu2._lepasPrison = true;
        panel17.SetActive(false);
    }
    public void PrisonBayarSulsel()
    {
        audioSource.PlayOneShot(clip);
        dadu3._lepasPrison = true;
        panel18.SetActive(false);
    }
    public void PrisonBayarSumbar()
    {
        audioSource.PlayOneShot(clip);
        dadu4._lepasPrison = true;
        panel19.SetActive(false);
    }
    public void LemparDaduBali()
    {
        audioSource.PlayOneShot(clip);
        panel16.SetActive(false);
    }
    public void LemparDaduDKI()
    {
        audioSource.PlayOneShot(clip);
        panel17.SetActive(false);
    }
    public void LemparDaduSulsel()
    {
        audioSource.PlayOneShot(clip);
        panel18.SetActive(false);
    }
    public void LemparDaduSumbar()
    {
        audioSource.PlayOneShot(clip);
        panel19.SetActive(false);
    }
}
