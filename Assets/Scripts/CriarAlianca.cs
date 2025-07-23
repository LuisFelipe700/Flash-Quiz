using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CriarAlianca : MonoBehaviour
{

    [SerializeField] CriarArmas estadosUnidos;
    [SerializeField] Inimigo armasI;
    [SerializeField] TextMeshProUGUI informativo;
    [SerializeField] GameObject aceitar;
    [SerializeField] GameObject recusar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        estadosUnidos = GetComponent<CriarArmas>();
        armasI = GetComponent<Inimigo>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

       
   public void CriarAliancaT()
    {
        
        
    }

    public void CriarAliancaO()
    {

    }

    public void CriarAliancaS()
    {

    }

    public void CriarAliancaA()
    {

    }
}
