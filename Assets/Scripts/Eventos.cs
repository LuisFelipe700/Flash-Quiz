using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Eventos : MonoBehaviour
{
    [SerializeField] CriarArmas estadosUnidos;
    [SerializeField] CriarAlianca alianca;
    [SerializeField] GameObject tiar;
    [SerializeField] TextMeshProUGUI tiarText;
    [SerializeField] GameObject otan;
    [SerializeField] TextMeshProUGUI otanText;
    [SerializeField] GameObject seato;
    [SerializeField] TextMeshProUGUI seatoText;
    [SerializeField] GameObject anzus;
    [SerializeField] TextMeshProUGUI anzusText;
    private bool pauseGame = false;
    [SerializeField] GameObject iformativoAliancaT;
    [SerializeField] GameObject iformativoaAliancaO;
    [SerializeField] GameObject iformativoaAliancaS;
    [SerializeField] GameObject iformativoaAliancaA;

    void Start()
    {
        estadosUnidos = GetComponent<CriarArmas>();
        alianca = GetComponent<CriarAlianca>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AceitarT ()
    {
        alianca.CriarAliancaT();
    }

    public void RecusarT()
    {
        iformativoAliancaT.SetActive(false);
        pauseGame = false;
        PauseGame();
    }
    public void Tiar( )
    {
        if (estadosUnidos.armas >= 15 && estadosUnidos.tensao <= 20 && estadosUnidos.confianca >= 25)
        {
            pauseGame = true;
            PauseGame();
            iformativoAliancaT.SetActive(true);
        }
    }



    public void Otan()
    {
        if (estadosUnidos.armas >= 25 && estadosUnidos.tensao <= 30 && estadosUnidos.confianca >= 35)
        {
            pauseGame = true;
            PauseGame();
            iformativoaAliancaO.SetActive(true);
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
        if (estadosUnidos.armas >= 55 && estadosUnidos.tensao <= 25 && estadosUnidos.confianca >= 45)
        {
            pauseGame = true;
            PauseGame();
            iformativoaAliancaS.SetActive(true);
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
        if (estadosUnidos.armas >= 40 && estadosUnidos.tensao <= 30 && estadosUnidos.confianca >= 45)
        {
            pauseGame = true;
            PauseGame();
            iformativoaAliancaA.SetActive(true);
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
