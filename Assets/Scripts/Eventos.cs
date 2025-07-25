using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Eventos : MonoBehaviour
{
    [SerializeField] CriarArmas estadosUnidos;
    [SerializeField] CriarAlianca alianca;
    private bool pauseGame = false;
    [SerializeField] GameObject iformativoAliancaT;
    [SerializeField] GameObject iformativoaAliancaO;
    [SerializeField] GameObject iformativoaAliancaS;
    [SerializeField] GameObject iformativoaAliancaA;
    private bool acordoT = false;
    private bool acordoO = false;
    private bool acordoS = false;
    private bool acordoA = false;
    void Start()
    {
        estadosUnidos = GameObject.FindGameObjectWithTag("Player").GetComponent<CriarArmas>();
        alianca = GetComponent<CriarAlianca>();
    }

    // Update is called once per frame
    void Update()
    {
        Acordo();
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
    public void AceitarT ()
    {
        alianca.CriarAliancaT();
        iformativoAliancaT.SetActive(false);
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
        alianca.CriarAliancaO();
    }

    public void RecusarO()
    {
        iformativoAliancaT.SetActive(false);
        pauseGame = false;
        PauseGame();
    }



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
        alianca.CriarAliancaS();
    }

    public void RecusarS()
    {
        iformativoAliancaT.SetActive(false);
        pauseGame = false;
        PauseGame();
    }



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
        alianca.CriarAliancaA();
    }

    public void RecusarA()
    {
        iformativoAliancaT.SetActive(false);
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
}
