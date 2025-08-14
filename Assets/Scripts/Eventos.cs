using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Eventos : MonoBehaviour
{
    [SerializeField] CriarArmas estadosUnidos;
    [SerializeField] CriarAlianca alianca;
    [SerializeField] Inimigo Inimigo;
    private bool pauseGame = false;
    [SerializeField] GameObject iformativoAliancaT;
    [SerializeField] GameObject iformativoaAliancaO;
    [SerializeField] GameObject iformativoaAliancaS;
    [SerializeField] GameObject iformativoaAliancaA;
    [SerializeField] private bool acordoT = false;
    [SerializeField]  private bool acordoO = false;
    [SerializeField] private bool acordoS = false;
    [SerializeField] private bool acordoA = false;

    private bool cuba = false;
    private bool berlim = false;
    private bool stupnik = false;
    private bool chernobyl = false;

    private bool acontecendo = false;
    void Start()
    {
        estadosUnidos = GameObject.FindGameObjectWithTag("Player").GetComponent<CriarArmas>();
        alianca = GetComponent<CriarAlianca>();
        Inimigo = GameObject.FindGameObjectWithTag("inimigo").GetComponent<Inimigo>();
    }

    // Update is called once per frame
    void Update()
    {
        Acordos();
        URSS();
    }


    private void Acordos()
    {
        
        Tiar();
        
        Otan();
       
        Anzus();
        
        Seato();
        
    }

    private void URSS()
    {
        
        AcontecerCuba();
        
        AcontecerBerlim();
        
        AcontecerStupnik();
        
        AcontecerChernobyl();
        
    }

    //Tiar
    public void AceitarT ()
    {
        estadosUnidos.GetTiar();
        
        PauseGame();
        acontecendo = false; // Permite que o evento aconteça novamente
        iformativoAliancaT.SetActive(false);
    }

    public void RecusarT()
    {
        
        PauseGame();
        acontecendo = false; // Permite que o evento aconteça novamente
        iformativoAliancaT.SetActive(false);
    }
    public void Tiar( )
    {
        if (estadosUnidos.GetArmas() >= 15 && estadosUnidos.GetTensao() >= 20 && estadosUnidos.VerificaConfianca() >= 25 && acordoT == false && acontecendo == false)
        {
            PauseGame();
            iformativoAliancaT.SetActive(true);
            acordoT = true;
            acontecendo = true; // Impede que o evento aconteça novamente
        }
    }

    //Otan

    public void Otan()
    {
        if (estadosUnidos.GetArmas() >= 25 && estadosUnidos.GetTensao() >= 30 && estadosUnidos.VerificaConfianca() >= 35 && acordoO == false && acontecendo == false)
        {
            PauseGame();
            iformativoaAliancaO.SetActive(true);
            acordoO = true;
            acontecendo = true; // Impede que o evento aconteça novamente
        }
    }

    public void AceitarO()
    {
       estadosUnidos.GetOtan();
        Inimigo.PactoVarsovia();
        PauseGame();
        
        acontecendo = false; // Permite que o evento aconteça novamente
        iformativoaAliancaO.SetActive(false);
    }

    public void RecusarO()
    {

        PauseGame();
        acontecendo = false; // Permite que o evento aconteça novamente
        iformativoaAliancaO.SetActive(false);

    }


    //Seato
    public void Seato()
    {
        if (estadosUnidos.VerificaConfianca() == 60)
        {

            PauseGame();
            iformativoaAliancaS.SetActive(true);
            acordoS = true;
            acontecendo = true; // Impede que o evento aconteça novamente
        }
    }

    public void AceitarS()
    {
        
        estadosUnidos.GetSeato();
        acontecendo = false; // Permite que o evento aconteça novamente
        PauseGame();
        iformativoaAliancaS.SetActive(false);
    }

    public void RecusarS()
    {
        PauseGame();
        acontecendo = false; // Permite que o evento aconteça novamente
        iformativoaAliancaS.SetActive(false);
    }


    //Anzus
    public void Anzus()
    {
        if (estadosUnidos.GetArmas() >= 35 && estadosUnidos.GetTensao() >= 25 && estadosUnidos.VerificaConfianca() >= 45 && acordoA == false && acontecendo == false)
        {
            PauseGame();
            iformativoaAliancaA.SetActive(true);
            acordoA = true;
            acontecendo = true; // Impede que o evento aconteça novamente
        }
    }
    public void AceitarA()
    {
        estadosUnidos.GetAnzsus();
        PauseGame();
        
        acontecendo = false; // Permite que o evento aconteça novamente
        iformativoaAliancaA.SetActive(false);
    }

    public void RecusarA()
    {
        
        PauseGame();
        acontecendo = false;
        iformativoaAliancaA.SetActive(false);
    }

    private void PauseGame()
    {
        if(pauseGame)
        {
            Time.timeScale = 1.0f;
            pauseGame = false;
        }
        else
        {
            Time.timeScale = 0f;
            pauseGame = true;
        }
    }

    // Eventos Inomigos

    public void AcontecerCuba()
    {
        if (Inimigo.GetArmasI() >= 20 && estadosUnidos.GetTensao() >= 20 && cuba == false)
        {
            Inimigo.Cuba();
            cuba = true;
        }
    }

    public void AcontecerBerlim()
    {
        if (Inimigo.GetArmasI() >= 30 && estadosUnidos.GetTensao() >= 30 && berlim == false)
        {
            Inimigo.MuroDeBerlim();
            berlim = true;
        }
    }

    public void AcontecerStupnik()
    {
        if (Inimigo.GetArmasI() >= 35 && estadosUnidos.GetTensao() >= 30 && stupnik == false)
        {
            Inimigo.Stupnik();
            stupnik = true;
        }
    }
    public void AcontecerChernobyl()
    {
        if (Inimigo.GetArmasI() >= 40 && estadosUnidos.GetTensao() >= 35 && chernobyl == false)
        {
            Inimigo.Chernobyl();
            chernobyl = true;
        }
    }

}
