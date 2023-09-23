using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dadu : MonoBehaviour
{    
    Collider2D collider;
    [SerializeField] GameObject _panel_prison, _icon_prison;
    [SerializeField] Transform _player, _titikStart, _spawnRumah;
    [SerializeField] Sprite[] _dadu;
    [SerializeField] GameObject animator, playerMov;
    [SerializeField] Transform[] _position;
    [SerializeField] int _diceNo;
    [SerializeField] Text text;
    [SerializeField] Koin koin;
    SpriteRenderer spriteRenderer;
    public LudoManager ludoManager;
    public bool _enabled, _prison, _refresh, _lepasPrison;
    int random, _nambahChance;
    public int _tambah;
    bool hasMoved = false;
    int lastExecutedIndex;    
    private void OnEnable()
    {
        transform.localScale = new Vector3(0.5f, 0.5f, 1);
        collider.enabled = true;
        playerMov.GetComponent<Player>().kondisi = true;

        if (_prison)
        {
            _panel_prison.SetActive(true);
        }
        else { return; }
    }
    private void OnDisable()
    {
        playerMov.GetComponent<Player>().kondisi = false;
    }
    // Start is called before the first frame update
    void Start()
    {      
        spriteRenderer = GetComponent<SpriteRenderer>();
        collider = GetComponent<Collider2D>();
        _enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (text.text.Equals("FINISH"))
        {
            gameObject.transform.localScale = new Vector3(0, 0, 0);
            if (_refresh)
            {
                if (_diceNo == 1)
                {
                    ludoManager._playerMove = 4;
                    ludoManager._transisi = true;
                }
                else
                {
                    ludoManager._playerMove = _diceNo - 1;
                    ludoManager._transisi = true;
                }
            }
            else
            {
                if (_diceNo == 4)
                {
                    ludoManager._playerMove = 1;
                    ludoManager._transisi = true;
                }
                else
                {
                    ludoManager._playerMove = _diceNo + 1;
                    ludoManager._transisi = true;
                }
            }
        }
        else
        {
            if (_player.position != _spawnRumah.position && !hasMoved)
            {
                Move();
                hasMoved = true;
            }
        }

        if (_prison)
        {
            _icon_prison.SetActive(true);
        }
        else { _icon_prison.SetActive(false); }       
    }
    private void OnMouseDown()
    {
        if (_enabled == true && _prison == false && _lepasPrison == false)
        {
            StartCoroutine(RollDice());
            _player.GetComponent<Player>()._lepas_prison = false;
            lastExecutedIndex = _tambah;
        }
        else if (_enabled == true && _prison == true && _lepasPrison == false)
        {
            StartCoroutine(PrisonRollDice());            
            lastExecutedIndex = _tambah;                        
        }
        else if(_enabled == true && _lepasPrison == true && _prison == true)
        {
            StartCoroutine(RollDice());
            lastExecutedIndex = _tambah;
            koin.coin -= 3;
            koin._hitung_koin -= 3;
            _lepasPrison = false;
            _prison = false;
        }    

    }
    void Move()
    {        
        StartCoroutine(MoveDir());
    }
 
    IEnumerator MoveDir()
    {                              
        for (int i = lastExecutedIndex; i <= _tambah; i++)
        {                     
            _player.position = _position[i].position;            
            yield return new WaitForSeconds(1f);
            lastExecutedIndex = i;
            playerMov.GetComponent<CircleCollider2D>().enabled = false;            
        }
        if (lastExecutedIndex == _tambah)
        {
            StartCoroutine(Switch());
            playerMov.GetComponent<CircleCollider2D>().enabled = true;            
        }
    }

    IEnumerator RollDice()
    {        
        if(_nambahChance >= 3 && _nambahChance < 5)
        {
            random = Random.Range(0, 7);
        }else if(_nambahChance >= 5 && _nambahChance < 7)
        {
            random = Random.Range(0, 8);
        }
        else if (_nambahChance >= 7 && _nambahChance < 10)
        {
            random = Random.Range(0, 9);
        }
        else if (_nambahChance >= 10)
        {
            random = Random.Range(6, 6);
        }
        else { random = Random.Range(0, 6); }
        
        animator.SetActive(true);
        transform.localScale = new Vector3(0, 0, 0);
        yield return new WaitForSeconds(1.5f);        
        switch (random)
        {
            case 0:
                int random_again = Random.Range(1, 6);
                collider.enabled = false;
                if (random_again == 1 || random_again == 2 || random_again == 3)
                {
                    spriteRenderer.sprite = _dadu[5];

                    if (_player.position == _spawnRumah.position)
                    {
                        _player.position = _titikStart.position;
                        _nambahChance = 0;
                    }
                    else
                    {
                        if (_tambah != 55 && _tambah != 54 && _tambah != 53 && _tambah != 52 && _tambah != 51)
                        {
                            _tambah += 6;
                        }
                    }
                        
                }
                else
                {
                    spriteRenderer.sprite = _dadu[0];
                    if (_player.position != _spawnRumah.position)
                        _tambah += 1;
                    else
                        _nambahChance++;
                }                 
                break;
            case 1 :
                collider.enabled = false;
                spriteRenderer.sprite = _dadu[0];                
                if (_player.position != _spawnRumah.position)
                    _tambah += 1;
                else
                    _nambahChance++;
                break;
            case 2:
                collider.enabled = false;
                spriteRenderer.sprite = _dadu[1];                
                if (_player.position != _spawnRumah.position && _tambah != 55)
                    _tambah += 2;
                else
                    _nambahChance++;
                break;
            case 3:
                collider.enabled = false;
                spriteRenderer.sprite = _dadu[2];                
                if (_player.position != _spawnRumah.position && _tambah != 55 && _tambah != 54)
                    _tambah += 3;
                else
                    _nambahChance++;
                break;
            case 4:
                collider.enabled = false;
                spriteRenderer.sprite = _dadu[3];                
                if (_player.position != _spawnRumah.position && _tambah != 55 && _tambah != 54 && _tambah != 53)
                    _tambah += 4;
                else
                    _nambahChance++;
                break;
            case 5:
                collider.enabled = false;
                spriteRenderer.sprite = _dadu[4];                
                if (_player.position != _spawnRumah.position && _tambah != 55 && _tambah != 54 && _tambah != 53 & _tambah != 52)
                    _tambah += 5;
                else
                    _nambahChance++;
                break;
            case 6:
                collider.enabled = false;
                spriteRenderer.sprite = _dadu[5];                
                if (_player.position == _spawnRumah.position)
                {
                    _player.position = _titikStart.position;
                    _nambahChance = 0;
                }
                else
                {
                    if (_tambah != 55 && _tambah != 54 && _tambah != 53 && _tambah != 52 && _tambah != 51)
                    {
                        _tambah += 6;
                    }
                }                    
                break;
            case 7:
                collider.enabled = false;
                spriteRenderer.sprite = _dadu[5];
                if (_player.position == _spawnRumah.position)
                {
                    _player.position = _titikStart.position;
                    _nambahChance = 0;
                }               
                break;
            case 8:
                collider.enabled = false;
                spriteRenderer.sprite = _dadu[5];
                if (_player.position == _spawnRumah.position)
                {
                    _player.position = _titikStart.position;
                    _nambahChance = 0;
                }               
                break;
            case 9:
                collider.enabled = false;
                spriteRenderer.sprite = _dadu[5];
                if (_player.position == _spawnRumah.position)
                {
                    _player.position = _titikStart.position;
                    _nambahChance = 0;
                }               
                break;           
        }
        animator.SetActive(false);
        transform.localScale = new Vector3(0.5f, 0.5f, 1);
        yield return new WaitForSeconds(1f);
        transform.localScale = new Vector3(0, 0, 1);
        hasMoved = false;
        if (lastExecutedIndex == _tambah)
        {
            yield return new WaitForSeconds(1f);

            if (_refresh)
            {
                if (_diceNo == 1)
                {
                    ludoManager._playerMove = 4;
                    ludoManager._transisi = true;
                }
                else
                {
                    ludoManager._playerMove = _diceNo - 1;
                    ludoManager._transisi = true;
                }
            }
            else
            {
                if (_diceNo == 4)
                {
                    ludoManager._playerMove = 1;
                    ludoManager._transisi = true;
                }
                else
                {
                    ludoManager._playerMove = _diceNo + 1;
                    ludoManager._transisi = true;
                }
            }
        }        
    }
    IEnumerator Switch()
    {
        yield return new WaitForSeconds(1f);

        if (_refresh)
        {
            if (_diceNo == 1)
            {
                ludoManager._playerMove = 4;
                ludoManager._transisi = true;
            }
            else
            {
                ludoManager._playerMove = _diceNo - 1;
                ludoManager._transisi = true;
            }
        }
        else
        {
            if (_diceNo == 4)
            {
                ludoManager._playerMove = 1;
                ludoManager._transisi = true;
            }
            else
            {
                ludoManager._playerMove = _diceNo + 1;
                ludoManager._transisi = true;
            }
        }       
    }

    IEnumerator PrisonRollDice()
    {
        random = Random.Range(0, 6);
        animator.SetActive(true);
        transform.localScale = new Vector3(0, 0, 0);
        yield return new WaitForSeconds(1.5f);
        switch (random)
        {
            case 0:
                collider.enabled = false;
                int random_again = Random.Range(1, 6);               
                if (random_again == 1 || random_again == 2 || random_again == 3)
                {
                    spriteRenderer.sprite = _dadu[5];

                    if (_player.position == _spawnRumah.position)
                    {
                        _player.position = _titikStart.position;
                    }
                    else
                    {
                        _prison = false;
                        _player.GetComponent<Player>()._lepas_prison = true;
                    }
                }
                else
                {
                    spriteRenderer.sprite = _dadu[0];                    
                }
                break;
            case 1:
                collider.enabled = false;
                spriteRenderer.sprite = _dadu[0];                
                break;
            case 2:
                collider.enabled = false;
                spriteRenderer.sprite = _dadu[1];                
                break;
            case 3:
                collider.enabled = false;
                spriteRenderer.sprite = _dadu[2];                
                break;
            case 4:
                collider.enabled = false;
                spriteRenderer.sprite = _dadu[3];                
                break;
            case 5:
                collider.enabled = false;
                spriteRenderer.sprite = _dadu[4];                
                break;
            case 6:                
                spriteRenderer.sprite = _dadu[5];
                _prison = false;
                _player.GetComponent<Player>()._lepas_prison = true;
                break;
        }
        animator.SetActive(false);
        transform.localScale = new Vector3(0.5f, 0.5f, 1);
        yield return new WaitForSeconds(1f);
        transform.localScale = new Vector3(0, 0, 1);
        hasMoved = false;
        if (lastExecutedIndex == _tambah)
        {
            yield return new WaitForSeconds(1f);

            if (_refresh)
            {
                if (_diceNo == 1)
                {
                    ludoManager._playerMove = 4;
                    ludoManager._transisi = true;
                }
                else
                {
                    ludoManager._playerMove = _diceNo - 1;
                    ludoManager._transisi = true;
                }
            }
            else
            {
                if (_diceNo == 4)
                {
                    ludoManager._playerMove = 1;
                    ludoManager._transisi = true;
                }
                else
                {
                    ludoManager._playerMove = _diceNo + 1;
                    ludoManager._transisi = true;
                }
            }
        }
    }
}
