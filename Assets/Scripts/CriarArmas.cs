using System.Collections;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CriarArmas : MonoBehaviour
{
    [SerializeField] public int armas = 0;
    [SerializeField] public int tensao = 0;
    [SerializeField] Button botaoCriarArma; //Cria uma arma a cada click e adiciona entre 1 e 3 de tensao
    [SerializeField] Button espionarInimigoC; //Espiona China e adquire 5 armas e o inimigo perde 5, porem, aumenta 10 de tensao 
    [SerializeField] Button espionarInimigoR; //Espiona Russia e adquire 5 armas e o inimigo perde 5, porem, aumenta 10 de tensao
    [SerializeField] Button negociarPaz; //Diminui 10 de tensao, porem perde 5 armas e os inimigos perdem entre 3 a 8 armas
    [SerializeField] private AudioClip jump;
    [SerializeField] private TextMeshProUGUI textoTensao;
    [SerializeField] private TextMeshProUGUI textoArmas;
    [SerializeField] private TextMeshProUGUI informativo;
    [SerializeField] private TextMeshProUGUI textoConfianca;
    [SerializeField] Slider confiancaSlider;
    [SerializeField] public int confianca = 100;
    [SerializeField] Inimigo inimigo;
    public bool tiarA = false;
    public bool otanA = false;
    public bool seatoA = false;
    public bool anzusA = false;

    private Audio audioSource;
   
    void Start()
    {
        audioSource = GameObject.Find("AudioSource").GetComponent<Audio>();
        inimigo = GetComponent<Inimigo>();

        if (confiancaSlider == null)
        {
            confiancaSlider = GameObject.Find("Confianca").GetComponent<Slider>();
            confiancaSlider.maxValue = confianca;
            confiancaSlider.value = confianca;
            textoConfianca.text = confianca.ToString() + "%";
        }

    }

    
    void Update()
    {
        Limite();
    }

    public void CriaArmas()
    {
        armas += Random.Range(1, 3);
        tensao += Random.Range(1, 5); // aumenta tensão a cada clique

        SetAlianca();

        if (seatoA = true)
        {
            armas += Random.Range(1, 3);
        }
        if (tensao >=  100f)
        {
            StartCoroutine(Guerra());
        }
        if (armas >= 100)
        {
            StartCoroutine(Paz());
        }

        StartCoroutine(Confianca());
        MostraTexto();
    }

    IEnumerator Confianca()
    {
        yield return new WaitForSeconds(2f);
        ++confianca;
    }

    
    private void SetAlianca()
    {
        if (tiarA = true)
        {
            StartCoroutine(TiarA());
        }
        if (otanA = true)
        {
            StartCoroutine(OtanA());
        }
        if (seatoA = true)
        {
            StartCoroutine(SeatoA());
        }
        if (anzusA = true)
        {
            StartCoroutine(AnzusA());
        }
        
    }

    IEnumerator TiarA()
    {
        yield return new WaitForSeconds(1);
        armas += 15;
        tensao += 20;
        confianca += 5;
    }

    IEnumerator OtanA()
    {
        yield return new WaitForSeconds(1);
    }

    IEnumerator SeatoA()
    {
        yield return new WaitForSeconds(1);
        confianca += 10;
        tensao += 10;
    }

    IEnumerator AnzusA()
    {
        yield return new WaitForSeconds(1);
        confianca += 10;
        tensao += 10;
        inimigo.GanharArmas();
    }
    IEnumerator Guerra()
    {
        yield return new WaitForSeconds(1);
    }

    IEnumerator Paz()
    {
        yield return new WaitForSeconds(1);
    }

    public void EspionarR()
    {
        StartCoroutine(EspionaR());
    }

    IEnumerator EspionaR()
    {
        yield return new WaitForSeconds(5);
        int dado = Random.Range(1, 6);

        if (dado > 3)
        {
            informativo.text = "Seus espioes conseguiram informacoes";
            armas += 5;
            tensao += 10;
            inimigo.armasI -= 10;
        }
        else if (dado <= 3)
        {
            informativo.text = "Seus espioes foram descobertos ou nao conseguiram informacoes";
            tensao += 2;
        }
    }

    public void MostraTexto()
    {
        textoArmas.text = "Armas: " + armas.ToString();
        textoTensao.text = "Tensao: " + tensao.ToString() + "%";
    }

    public int PerderArmas()
    {
       armas -= Random.Range(1,3);
       return armas;
    }

    public int GetArmas()
    {
        return armas;
    }
    public float GetTensao()
    {
        return tensao;
    }


    public void NegociarPaz()
    {
        tensao -= 10;
        armas -= 5;
    }

    private void Limite()
    {
        if (armas > 100)
        {
            armas = 100;
        }
        else if (armas < 0)
        { armas = 0; }

        if (tensao > 100)
        {
            tensao = 100;
        }
        else if (tensao < 0)
        {
            tensao = 0;
        }
    }
}
