using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;

public class Inimigo : MonoBehaviour
{
    [SerializeField] string nome;
    [SerializeField] int armasI;
    [SerializeField] private TextMeshProUGUI textoArmas;
    [SerializeField] CriarArmas player;
    private Audio audio;
    void Start()
    {
        audio = GameObject.Find("AudioSource").GetComponent<Audio>();
    }

    // Update is called once per frame
    void Update()
    {
        CriarArmas();
    }

    private void CriarArmas()
    {
        StartCoroutine(ContaArmas()); 
    }

    IEnumerator ContaArmas()
    {
        yield return new WaitForSeconds(1f);
        armasI += Random.Range(1, 2);
    }

    private void Espionar()
    {
        StartCoroutine(Espiao());
        
    }

    IEnumerator Espiao()
    {
        yield return new WaitForSeconds(5f);
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
}
