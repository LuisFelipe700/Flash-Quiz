using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CriarArmas : MonoBehaviour
{
    [SerializeField] private int armas = 0;
    [SerializeField] private float tensao = 0f;
    [SerializeField] Button botaoCriarArma; //Cria uma arma a cada click e adiciona entre 1 e 3 de tensao
    [SerializeField] Button espionarInimigoC; //Espiona China e adquire 5 armas e o inimigo perde 5, porem, aumenta 10 de tensao 
    [SerializeField] Button espionarInimigoR; //Espiona Russia e adquire 5 armas e o inimigo perde 5, porem, aumenta 10 de tensao
    [SerializeField] Button negociarPaz; //Diminui 10 de tensao, porem perde 5 armas e os inimigos perdem entre 3 a 8 armas
    [SerializeField] private AudioClip jump;
    [SerializeField] private TextMeshProUGUI textoTensao;
    [SerializeField] private TextMeshProUGUI textoArmas;
    private Audio audioSource;
   
    void Start()
    {
        audioSource = GameObject.Find("AudioSource").GetComponent<Audio>();

    }

    
    void Update()
    {
        
    }

    private void CriaArmas()
    {
        ++armas;
        tensao += Random.Range(1f, 3f); // aumenta tensão a cada clique

        if (tensao >=  100f)
        {
            StartCoroutine(Guerra());
        }

        if (armas >= 100)
        {
            StartCoroutine(Paz());
        }
    }

    IEnumerator Guerra()
    {
        yield return new WaitForSeconds(1);
    }

    IEnumerator Paz()
    {
        yield return new WaitForSeconds(1);
    }

    private void EspionarC()
    {
        armas += 5;
        tensao += 10;
    }

    private void EspionarR()
    {
        armas += 5;
        tensao += 10;
    }

    public void MostraTexto()
    {
        textoArmas.text = "Armas: " + armas.ToString();
        textoTensao.text = "Tensao Mundial: " + tensao.ToString();
    }

}
