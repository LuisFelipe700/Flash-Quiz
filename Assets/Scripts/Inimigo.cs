using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;

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
    private bool comecar;
    //private Audio audio;
    void Start()
    {
        //audio = GameObject.Find("AudioSource").GetComponent<Audio>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<CriarArmas>();
        ComcecarJogo();
        
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    private void ComcecarJogo()
    {
        if (comecar = true)
        {
            CriarArmas();
            Espionar();
        }
    }
    private void CriarArmas()
    {
        StartCoroutine(ContaArmas()); 
    }

    IEnumerator ContaArmas()
    {
        yield return new WaitForSeconds(3f);
        armasI += Random.Range(1, 5);
        MostrarTexto();

        if (pactoVasovia = true)
        {
            armasI += Random.Range(1, 3);
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

    IEnumerator Espiao()
    {
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
        armasI += 5;
        player.GanharTensao();
        pactoVasovia = true;   
    }


    private void Eventos()
    {
        if (!cuba)
        {
            Cuba();
        }

        if (!muro)
        {
            MuroDeBerlim();
        }

        if (!chernobyl)
        {
            Chernobyl();
        }

        if (!stupnik)
        {
            Stupnik();
        }
    }
    private void Cuba()
    {
        if (armasI >= 25);
        {
            armasI -= 10;
            player.GanharTensao();
            cuba = true;
        }
    }

    private void MuroDeBerlim()
    {
        if (player.GetTensao() >= 30 && armasI >= 30)
        {
            player.GanharTensao();
            armasI += 10;
            player.PerderConfianca();
        }
    }

    private void Chernobyl()
    {
        if (armasI >= 50)
        {
            player.GanharTensao();
            player.GanharTensao();
            armasI -= 20;
        }
    }

    private void Stupnik ()
    {
        if (armasI >= 35)
        {
            player.GanharTensao();
            player.PerderConfianca ();
        }
    }

    public void GanharArmas()
    {
        armasI += 15;
    }

    public void PerderArmas()
    {
        armasI -= 10;
    }
}
