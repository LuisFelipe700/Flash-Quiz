using UnityEngine;
using UnityEngine.SceneManagement;

public class DiretorBatalha : MonoBehaviour
{

    [SerializeField] CriarArmas criarArmas; // Referência ao script CriarArmas
    [SerializeField] Inimigo inimigo; // Referência ao script Inimigo
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        criarArmas = GameObject.FindGameObjectWithTag("Player").GetComponent<CriarArmas>();
        inimigo = GameObject.FindGameObjectWithTag("inimigo").GetComponent<Inimigo>();
    }

    // Update is called once per frame
    void Update()
    {
        EndGame();
    }

    private void EndGame()
    {
        if (criarArmas.GetTensao() >= 150f || inimigo.GetArmasI() >= 100)
        {
            SceneManager.LoadScene("Derrota");
        }
        if (criarArmas.GetArmas() >= 100)
        {
            SceneManager.LoadScene("Foguete");
        }
    }

}
