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
    private bool acordoT = false;
    private bool acordoO = false;
    private bool acordoS = false;
    private bool acordoA = false;

    private bool cuba = false;
    private bool berlim = false;
    private bool stupnik = false;
    private bool chernobyl = false;
    void Start()
    {
        estadosUnidos = GameObject.FindGameObjectWithTag("Player").GetComponent<CriarArmas>();
        alianca = GetComponent<CriarAlianca>();
        Inimigo = GameObject.FindGameObjectWithTag("inimigo").GetComponent<Inimigo>();
    }

    // Update is called once per frame
    void Update()
    {
        Acordo();
        URSS();
    }


    private void Acordo()
    {
        if (!acordoT)
        {
            Tiar();
        }

        if (!acordoO)
        {
            Otan();
        }

        if (!acordoA)
        {
            Anzus();
        }

        if (!acordoS)
        {
            Seato();
        }
    }

    private void URSS()
    {
        if (!cuba)
        {
            AcontecerCuba();
        }
        if (!berlim)
        {
            AcontecerBerlim();
        }
        if (!stupnik)
        {
            AcontecerStupnik();
        }
        if (!chernobyl)
        {
            AcontecerChernobyl();
        }
    }

    //Tiar
    public void AceitarT ()
    {
        estadosUnidos.GetTiar();
        iformativoAliancaT.SetActive(false);
        pauseGame = false;
        PauseGame();
    }

    public void RecusarT()
    {
        iformativoAliancaT.SetActive(false);
        pauseGame = false;
        PauseGame();
    }
    public void Tiar( )
    {
        if (estadosUnidos.GetArmas() >= 15 && estadosUnidos.GetTensao() >= 20 && estadosUnidos.VerificaConfianca() >= 25)
        {
            pauseGame = true;
            PauseGame();
            iformativoAliancaT.SetActive(true);
            acordoT = true;
        }
    }

    //Otan

    public void Otan()
    {
        if (estadosUnidos.GetArmas() >= 25 && estadosUnidos.GetTensao() >= 30 && estadosUnidos.VerificaConfianca() >= 35)
        {
            pauseGame = true;
            PauseGame();
            iformativoaAliancaO.SetActive(true);
            acordoO = true;
        }
    }

    public void AceitarO()
    {
       estadosUnidos.GetOtan();
        Inimigo.PactoVarsovia();
        pauseGame = false;
        PauseGame();
        iformativoaAliancaO.SetActive(false);
    }

    public void RecusarO()
    {
        iformativoaAliancaO.SetActive(false);
        pauseGame = false;
        PauseGame();
    }


    //Seato
    public void Seato()
    {
        if (estadosUnidos.GetArmas() >= 55 && estadosUnidos.GetTensao() >= 25 && estadosUnidos.VerificaConfianca() >= 45)
        {
            pauseGame = true;
            PauseGame();
            iformativoaAliancaS.SetActive(true);
            acordoS = true;
        }
    }

    public void AceitarS()
    {
        estadosUnidos.GetSeato();
        pauseGame = false;
        PauseGame();
        iformativoaAliancaS.SetActive(false);
    }

    public void RecusarS()
    {
        iformativoaAliancaS.SetActive(false);
        pauseGame = false;
        PauseGame();
    }


    //Anzus
    public void Anzus()
    {
        if (estadosUnidos.GetArmas() >= 40 && estadosUnidos.GetTensao() >= 30 && estadosUnidos.VerificaConfianca() >= 45)
        {
            pauseGame = true;
            PauseGame();
            iformativoaAliancaA.SetActive(true);
            acordoA = true;
        }
    }
    public void AceitarA()
    {
        estadosUnidos.GetAnzsus();
        pauseGame = false;
        PauseGame();
        iformativoaAliancaA.SetActive(false);
    }

    public void RecusarA()
    {
        iformativoaAliancaA.SetActive(false);
        pauseGame = false;
        PauseGame();
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
        if (Inimigo.GetArmasI() >= 20 && estadosUnidos.GetTensao() >= 20)
        {
            Inimigo.Cuba();
            cuba = true;
        }
    }

    public void AcontecerBerlim()
    {
        if (Inimigo.GetArmasI() >= 30 && estadosUnidos.GetTensao() >= 30)
        {
            Inimigo.MuroDeBerlim();
            berlim = true;
        }
    }

    public void AcontecerStupnik()
    {
        if (Inimigo.GetArmasI() >= 35 && estadosUnidos.GetTensao() >= 30)
        {
            Inimigo.Stupnik();
            stupnik = true;
        }
    }
    public void AcontecerChernobyl()
    {
        if (Inimigo.GetArmasI() >= 40 && estadosUnidos.GetTensao() >= 35)
        {
            Inimigo.Chernobyl();
            chernobyl = true;
        }
    }

}
