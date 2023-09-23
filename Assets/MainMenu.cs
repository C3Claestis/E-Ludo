using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
public class MainMenu : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip clip;
    public void Scene(int scene)
    {
        audioSource.PlayOneShot(clip);
        SceneManager.LoadScene(scene);
    }
    public void ToLink(string link)
    {
        audioSource.PlayOneShot(clip);
        Application.OpenURL(link);
    }
}
