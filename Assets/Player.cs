using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{    
    public Transform _spawnPosisi;
    SpriteRenderer sprite;
    [SerializeField] LudoManager ludoManager;
    //[SerializeField] Winner winner;
    [SerializeField] int _no;
    [SerializeField] Text text;
    [SerializeField] AudioSource sfx;
    [SerializeField] AudioClip clip;
    [SerializeField] GameObject _panel_finish, _finish;
    public bool kondisi;
    CircleCollider2D box;
    public Dadu dadu;    
    private bool isSfxPlaying = false;
    bool sekali;
    public bool _lepas_prison;
    public int _stak;
    // Start is called before the first frame update
    void Start()
    {        
        box = GetComponent<CircleCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
    }
    void Sekali()
    {
        if (!sekali)
        {
            /*
            if(winner._hitungPemenang == 0)
            {
                winner._pemenang_1 = _no;
                winner._hitungPemenang++;
            }else if(winner._hitungPemenang == 1)
            {
                winner._pemenang_2 = _no;
                winner._hitungPemenang++;
            }
            else if (winner._hitungPemenang == 2)
            {
                winner._pemenang_3 = _no;
                winner._hitungPemenang++;
            }
            else { winner._pemenang_4 = _no; }
            */
            _panel_finish.SetActive(true);
            ludoManager._finishClear = false;
            sekali = true;
        }
    }
    // Update is called once per frame
    void Update()
    {        
        if(transform.position.x == 0 && transform.position.y == 0)
        {
            sfx.mute = true;
            box.enabled = false;
            sprite.enabled = false;
            text.text = "FINISH";
            _finish.SetActive(true);
            Sekali();
        }
        if(!box.enabled && !isSfxPlaying)
        {
            StartCoroutine(Sfx());
        }        
    }
    IEnumerator Sfx()
    {
        isSfxPlaying = true;
        while (!box.enabled)
        {
            sfx.PlayOneShot(clip);
            yield return new WaitForSeconds(1f);
        }
        isSfxPlaying = false;
    }
    /*
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (kondisi)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                collision.GetComponent<Player>().dadu._tambah = 0;
                collision.GetComponent<Player>().dadu._prison = false;
                collision.GetComponent<Player>().dadu._refresh = false;
                collision.GetComponent<Transform>().position = collision.GetComponent<Player>()._spawnPosisi.position;                
            }            
        }
    } */   
}
