using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class Inimigo : MonoBehaviour
{
    [SerializeField] string nome;
    [SerializeField] private int armasI;
    [SerializeField] private TextMeshProUGUI textoArmas;
    [SerializeField] CriarArmas player;
    private bool pactoVasovia = false;
    private bool cuba = false;
    private bool muro = false;
    private bool chernobyl = false;
    private bool stupnik = false;
    //private Audio audio;

    private void Awake()
    {
        ComcecarJogo();
    }
    void Start()
    {
        //audio = GameObject.Find("AudioSource").GetComponent<Audio>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<CriarArmas>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        Limite();
        MostrarTexto();
    }

    private void ComcecarJogo()
    {
        
        
            CriarArmas();
            Espionar();
        
    }
    private void CriarArmas()
    {
        StartCoroutine(ContaArmas()); 
    }

    IEnumerator ContaArmas()
    {
        yield return new WaitForSeconds(1f);
        armasI += Random.Range(1, 5);

        if (pactoVasovia == true)
        {
            armasI += Random.Range(1, 3);
        }
        StartCoroutine(ContaArmas());

        if (armasI >= 100)
        {
            StartCoroutine(Guerra());
        }
        IEnumerator Guerra()
        {
            yield return new WaitForSeconds(1f);
            SceneManager.LoadScene("Derrota");
        }
    }

    private void MostrarTexto()
    {
        textoArmas.text = "Armas Inimigo: " + armasI.ToString();
    }
    private void Espionar()
    {
        StartCoroutine(Espiao());
        
    }

    public int GetArmas()
    {
        return armasI;
    }
    IEnumerator Espiao()
    {
        Debug.Log("Espionando...");
        yield return new WaitForSeconds(3f);
        int dadoI = Random.Range(1, 6);
        if (dadoI > 3)
        {
            player.PerderArmas();
        }
        else if (dadoI <= 4)
        {
            armasI -= Random.Range(1, 5);
        }
    }

    public void PactoVarsovia()
    {
        Debug.Log("Pacto de Varsóvia ativado");
        armasI += 5;
        player.GanharTensao();
        pactoVasovia = true;   
    }

    public void Cuba()
    {
        
            Debug.Log("Evento Cuba ativado");
            armasI += 5;
            player.GanharTensao();
            cuba = true;
        
    }

    public void MuroDeBerlim()
    {

        Debug.Log("Evento Muro de Berlim ativado");
        player.GanharTensao();
        armasI += 5;
        player.PerderConfianca();
        
    }

    public void Chernobyl()
    {
        Debug.Log("Evento Chernobyl ativado");
        player.GanharTensao();
        player.GanharTensao();
        armasI -= 5;
    }

    public void Stupnik ()
    {
        Debug.Log("Evento Stupnik ativado");
        player.GanharTensao();
        player.PerderConfianca ();
        
    }

    public void GanharArmas()
    {
        Debug.Log("Inimigo ganhou armas");
        armasI += 10;
    }

    public void PerderArmas()
    {
        Debug.Log("Inimigo perdeu armas");
        armasI -= 10;
    }

    private void Limite()
    {
        if (armasI > 100)
        {
            armasI = 100;
        }
        else if (armasI < 0)
        { armasI = 0; }
    }

    public int GetArmasI()
    {
        return armasI;
    }   
}
