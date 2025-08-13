using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public string Jogo;
    private Audio audioSource;
    
   // [SerializeField] private AudioClip clip;
    void Start()
    {
        audioSource = GetComponent<Audio>();
    }
    public void MudarCena1()
    {
        SceneManager.LoadScene(Jogo);
        //audioSource.TocarSom(clip);
    }

}

