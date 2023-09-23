using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Winner : MonoBehaviour
{
    public int _finisher;   
    public LudoManager ludoManager;    
    [SerializeField] Koin bali, dki, sulsel, sumbar;
    [SerializeField] Image juara_1, juara_2, juara_3, juara_4;
    [SerializeField] Sprite _bali, _dki, _sulsel, _sumbar;
    [SerializeField] Transform player1, player2, player3, player4;   
    [SerializeField] GameObject panel_finish, panel_resume, panel_finish_end, panel_leaderboard;
    [SerializeField] Text rumah_bali, rumah_dki, rumah_sulsel, rumah_sumbar;
    [SerializeField] Text coin_bali, coin_dki, coin_sulsel, coin_sumbar;
    [SerializeField] Text jumlah_coin_bali, jumlah_coin_dki, jumlah_coin_sulsel, jumlah_coin_sumbar;
    [SerializeField] Text jumlah_rumah_bali, jumlah_rumah_dki, jumlah_rumah_sulsel, jumlah_rumah_sumbar;
    [SerializeField] AudioSource audioSource, music;
    [SerializeField] AudioClip clip;
    // Update is called once per frame
    void Update()
    {
        if (_finisher == 4 || ludoManager._waktu <= 0)
        {           
            StartCoroutine(Wait());
        }            
    }

    IEnumerator Wait()
    {
        SetsRankings();
        music.Stop();
        yield return new WaitForSeconds(3);
        panel_finish.SetActive(true);

        jumlah_rumah_bali.text = rumah_bali.text;
        jumlah_rumah_dki.text = rumah_dki.text;
        jumlah_rumah_sulsel.text = rumah_sulsel.text;
        jumlah_rumah_sumbar.text = rumah_sumbar.text;

        jumlah_coin_bali.text = coin_bali.text;
        jumlah_coin_dki.text = coin_dki.text;
        jumlah_coin_sulsel.text = coin_sulsel.text;
        jumlah_coin_sumbar.text = coin_sumbar.text;

        ludoManager._finishClear = false;
    }
    public void MainMenu()
    {
        audioSource.PlayOneShot(clip);
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
    public void Resume()
    {
        audioSource.PlayOneShot(clip);
        panel_resume.SetActive(true);
        Time.timeScale = 0;
    }
    public void BackResume()
    {
        audioSource.PlayOneShot(clip);
        panel_resume.SetActive(false);
        Time.timeScale = 1;
    }
    public void Restart()
    {
        audioSource.PlayOneShot(clip);
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
    public void EndFinish()
    {
        audioSource.PlayOneShot(clip);
        panel_finish_end.SetActive(true);
        panel_leaderboard.SetActive(false);
    }
    public void LeaderBoard()
    {
        audioSource.PlayOneShot(clip);
        panel_finish_end.SetActive(false);
        panel_leaderboard.SetActive(true);
    }
    void SetsRankings()
    {
        int highestScore = Mathf.Max(bali._hitung_koin, dki._hitung_koin, sulsel._hitung_koin, sumbar._hitung_koin);

        if (highestScore == bali._hitung_koin)
        {
            SetWinner(juara_1, _bali);

            // Peringkat kedua, ketiga, dan keempat jika bali memiliki nilai tertinggi
            if (dki._hitung_koin > sulsel._hitung_koin && dki._hitung_koin > sumbar._hitung_koin)
            {
                SetRunnerUp(juara_2, _dki);
                SetThirdPlace(juara_3, sulsel._hitung_koin > sumbar._hitung_koin ? _sulsel : _sumbar);
                SetFourthPlace(juara_4, sulsel._hitung_koin > sumbar._hitung_koin ? _sumbar : _sulsel);
            }
            else if (sulsel._hitung_koin > dki._hitung_koin && sulsel._hitung_koin > sumbar._hitung_koin)
            {
                SetRunnerUp(juara_2, _sulsel);
                SetThirdPlace(juara_3, dki._hitung_koin > sumbar._hitung_koin ? _dki : _sumbar);
                SetFourthPlace(juara_4, dki._hitung_koin > sumbar._hitung_koin ? _sumbar : _dki);
            }
            else
            {
                SetRunnerUp(juara_2, _sumbar);
                SetThirdPlace(juara_3, dki._hitung_koin > sulsel._hitung_koin ? _dki : _sulsel);
                SetFourthPlace(juara_4, dki._hitung_koin > sulsel._hitung_koin ? _sulsel : _dki);
            }
        }
        else if (highestScore == dki._hitung_koin)
        {
            SetWinner(juara_1, _dki);

            // Peringkat kedua, ketiga, dan keempat jika dki memiliki nilai tertinggi
            if (bali._hitung_koin > sulsel._hitung_koin && bali._hitung_koin > sumbar._hitung_koin)
            {
                SetRunnerUp(juara_2, _bali);
                SetThirdPlace(juara_3, sulsel._hitung_koin > sumbar._hitung_koin ? _sulsel : _sumbar);
                SetFourthPlace(juara_4, sulsel._hitung_koin > sumbar._hitung_koin ? _sumbar : _sulsel);
            }
            else if (sulsel._hitung_koin > bali._hitung_koin && sulsel._hitung_koin > sumbar._hitung_koin)
            {
                SetRunnerUp(juara_2, _sulsel);
                SetThirdPlace(juara_3, bali._hitung_koin > sumbar._hitung_koin ? _bali : _sumbar);
                SetFourthPlace(juara_4, bali._hitung_koin > sumbar._hitung_koin ? _sumbar : _bali);
            }
            else
            {
                SetRunnerUp(juara_2, _sumbar);
                SetThirdPlace(juara_3, bali._hitung_koin > sulsel._hitung_koin ? _bali : _sulsel);
                SetFourthPlace(juara_4, bali._hitung_koin > sulsel._hitung_koin ? _sulsel : _bali);
            }
        }
        else if (highestScore == sulsel._hitung_koin)
        {
            SetWinner(juara_1, _sulsel);

            // Peringkat kedua, ketiga, dan keempat jika sulsel memiliki nilai tertinggi
            if (bali._hitung_koin > dki._hitung_koin && bali._hitung_koin > sumbar._hitung_koin)
            {
                SetRunnerUp(juara_2, _bali);
                SetThirdPlace(juara_3, dki._hitung_koin > sumbar._hitung_koin ? _dki : _sumbar);
                SetFourthPlace(juara_4, dki._hitung_koin > sumbar._hitung_koin ? _sumbar : _dki);
            }
            else if (dki._hitung_koin > bali._hitung_koin && dki._hitung_koin > sumbar._hitung_koin)
            {
                SetRunnerUp(juara_2, _dki);
                SetThirdPlace(juara_3, bali._hitung_koin > sumbar._hitung_koin ? _bali : _sumbar);
                SetFourthPlace(juara_4, bali._hitung_koin > sumbar._hitung_koin ? _sumbar : _bali);
            }
            else
            {
                SetRunnerUp(juara_2, _sumbar);
                SetThirdPlace(juara_3, bali._hitung_koin > dki._hitung_koin ? _bali : _dki);
                SetFourthPlace(juara_4, bali._hitung_koin > dki._hitung_koin ? _dki : _bali);
            }
        }
        else // The highest score is sumbar
        {
            SetWinner(juara_1, _sumbar);

            // Peringkat kedua, ketiga, dan keempat jika sumbar memiliki nilai tertinggi
            if (bali._hitung_koin > dki._hitung_koin && bali._hitung_koin > sulsel._hitung_koin)
            {
                SetRunnerUp(juara_2, _bali);
                SetThirdPlace(juara_3, dki._hitung_koin > sulsel._hitung_koin ? _dki : _sulsel);
                SetFourthPlace(juara_4, dki._hitung_koin > sulsel._hitung_koin ? _sulsel : _dki);
            }
            else if (dki._hitung_koin > bali._hitung_koin && dki._hitung_koin > sulsel._hitung_koin)
            {
                SetRunnerUp(juara_2, _dki);
                SetThirdPlace(juara_3, bali._hitung_koin > sulsel._hitung_koin ? _bali : _sulsel);
                SetFourthPlace(juara_4, bali._hitung_koin > sulsel._hitung_koin ? _sulsel : _bali);
            }
            else
            {
                SetRunnerUp(juara_2, _sulsel);
                SetThirdPlace(juara_3, bali._hitung_koin > dki._hitung_koin ? _bali : _dki);
                SetFourthPlace(juara_4, bali._hitung_koin > dki._hitung_koin ? _dki : _bali);
            }
        }
    }
    
    // Mengatur gambar dan peringkat juara
    void SetWinner(Image juaraImage, Sprite wilayahSprite)
    {
        juaraImage.sprite = wilayahSprite;
    }

    void SetRunnerUp(Image juaraImage, Sprite wilayahSprite)
    {
        juaraImage.sprite = wilayahSprite;
    }

    void SetThirdPlace(Image juaraImage, Sprite wilayahSprite)
    {
        juaraImage.sprite = wilayahSprite;
    }

    void SetFourthPlace(Image juaraImage, Sprite wilayahSprite)
    {
        juaraImage.sprite = wilayahSprite;
    }
}