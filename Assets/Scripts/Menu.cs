using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour

    {
    private AudioSource audio;
    [SerializeField] private AudioClip som;
    public string Jogo;

    void Start()
    {
        TocarSom();
        audio = GetComponent<AudioSource>();
    }
    
    public void MudarCena1()
    {
        SceneManager.LoadScene(Jogo);
    }
    public void TocarSom()
    {
        audio.PlayOneShot(som);
    }
}

