using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Tutor : MonoBehaviour
{
    [SerializeField] GameObject[] tutor;
    [SerializeField] GameObject next, prev;
    int count;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;        
    }

    // Update is called once per frame
    void Update()
    {
        switch (count)
        {
            case 0 :
                prev.SetActive(false);
                tutor[0].SetActive(true);
                tutor[1].SetActive(false);
                tutor[2].SetActive(false);
                tutor[3].SetActive(false);
                tutor[4].SetActive(false);
                tutor[5].SetActive(false);
                tutor[6].SetActive(false);
                tutor[7].SetActive(false);
                tutor[8].SetActive(false);
                tutor[9].SetActive(false);
                break;
            case 1:
                tutor[0].SetActive(false);
                tutor[1].SetActive(true);
                tutor[2].SetActive(false);
                tutor[3].SetActive(false);
                tutor[4].SetActive(false);
                tutor[5].SetActive(false);
                tutor[6].SetActive(false);
                tutor[7].SetActive(false);
                tutor[8].SetActive(false);
                tutor[9].SetActive(false);
                next.SetActive(true);
                prev.SetActive(true);
                break;
            case 2:
                tutor[0].SetActive(false);
                tutor[1].SetActive(false);
                tutor[2].SetActive(true);
                tutor[3].SetActive(false);
                tutor[4].SetActive(false);
                tutor[5].SetActive(false);
                tutor[6].SetActive(false);
                tutor[7].SetActive(false);
                tutor[8].SetActive(false);
                tutor[9].SetActive(false);
                next.SetActive(true);
                prev.SetActive(true);
                break;
            case 3:
                tutor[0].SetActive(false);
                tutor[1].SetActive(false);
                tutor[2].SetActive(false);
                tutor[3].SetActive(true);
                tutor[4].SetActive(false);
                tutor[5].SetActive(false);
                tutor[6].SetActive(false);
                tutor[7].SetActive(false);
                tutor[8].SetActive(false);
                tutor[9].SetActive(false);
                next.SetActive(true);
                prev.SetActive(true);
                break;
            case 4:
                tutor[0].SetActive(false);
                tutor[1].SetActive(false);
                tutor[2].SetActive(false);
                tutor[3].SetActive(false);
                tutor[4].SetActive(true);
                tutor[5].SetActive(false);
                tutor[6].SetActive(false);
                tutor[7].SetActive(false);
                tutor[8].SetActive(false);
                tutor[9].SetActive(false);
                next.SetActive(true);
                prev.SetActive(true);
                break;
            case 5:
                tutor[0].SetActive(false);
                tutor[1].SetActive(false);
                tutor[2].SetActive(false);
                tutor[3].SetActive(false);
                tutor[4].SetActive(false);
                tutor[5].SetActive(true);
                tutor[6].SetActive(false);
                tutor[7].SetActive(false);
                tutor[8].SetActive(false);
                tutor[9].SetActive(false);
                next.SetActive(true);
                prev.SetActive(true);
                break;
            case 6:
                tutor[0].SetActive(false);
                tutor[1].SetActive(false);
                tutor[2].SetActive(false);
                tutor[3].SetActive(false);
                tutor[4].SetActive(false);
                tutor[5].SetActive(false);
                tutor[6].SetActive(true);
                tutor[7].SetActive(false);
                tutor[8].SetActive(false);
                tutor[9].SetActive(false);
                next.SetActive(true);
                prev.SetActive(true);
                break;
            case 7:
                tutor[0].SetActive(false);
                tutor[1].SetActive(false);
                tutor[2].SetActive(false);
                tutor[3].SetActive(false);
                tutor[4].SetActive(false);
                tutor[5].SetActive(false);
                tutor[6].SetActive(false);
                tutor[7].SetActive(true);
                tutor[8].SetActive(false);
                tutor[9].SetActive(false);
                next.SetActive(true);
                prev.SetActive(true);
                break;
            case 8:
                tutor[0].SetActive(false);
                tutor[1].SetActive(false);
                tutor[2].SetActive(false);
                tutor[3].SetActive(false);
                tutor[4].SetActive(false);
                tutor[5].SetActive(false);
                tutor[6].SetActive(false);
                tutor[7].SetActive(false);
                tutor[8].SetActive(true);
                tutor[9].SetActive(false);
                next.SetActive(true);
                prev.SetActive(true);
                break;
            case 9:
                tutor[0].SetActive(false);
                tutor[1].SetActive(false);
                tutor[2].SetActive(false);
                tutor[3].SetActive(false);
                tutor[4].SetActive(false);
                tutor[5].SetActive(false);
                tutor[6].SetActive(false);
                tutor[7].SetActive(false);
                tutor[8].SetActive(false);
                tutor[9].SetActive(true);
                next.SetActive(false);
                break;
        }        
    }
    public void Next()
    {
        count++;
    }
    public void Prev()
    {
        count--;
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
