using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;

public class Inimigo : MonoBehaviour
{
    [SerializeField] string nome;
    [SerializeField] public int armasI;
    [SerializeField] private TextMeshProUGUI textoArmas;
    [SerializeField] CriarArmas player;
    private bool pactoVasovia = false;
    private bool cuba = false;
    private bool muro = false;
    private bool chernobyl = false;
    private bool stupnik = false;
    private bool comecar = true;
    private Audio audio;
    void Start()
    {
        audio = GameObject.Find("AudioSource").GetComponent<Audio>();
        player = GetComponent<CriarArmas>();
        if (comecar = true)
        {
            CriarArmas();
            Espiao();
        }
    }

    // Update is called once per frame
    void Update()
    {

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
        textoArmas.text = "Armas Inimigo" + armasI.ToString();
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

    public void GanharArmas()
    {
        armasI += 15;
    }

    public void PactoVarsovia()
    {
        armasI += 5;
        player.tensao += 10;
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
            player.tensao += 10;
            cuba = true;
        }
    }

    private void MuroDeBerlim()
    {
        if (player.tensao >= 30 && armasI >= 30)
        {
            player.tensao += 10;
            armasI += 10;
            player.confianca -= 10;
        }
    }

    private void Chernobyl()
    {
        if (armasI >= 50)
        {
            player.tensao += 20;
            armasI -= 20;
        }
    }

    private void Stupnik ()
    {
        if (armasI >= 35)
        {
            player.tensao += 10;
            player.confianca -= 15;
        }
    }
}
