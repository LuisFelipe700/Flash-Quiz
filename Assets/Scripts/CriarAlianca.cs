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
        estadosUnidos = GameObject.FindGameObjectWithTag("Player").GetComponent<CriarArmas>();
        armasI = GameObject.FindGameObjectWithTag("inimigo").GetComponent<Inimigo>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

       
   public void CriarAliancaT()
    {
        estadosUnidos.GetTiar();
    }

    public void CriarAliancaO()
    {
        estadosUnidos.GetOtan();
        armasI.PactoVarsovia();
    }

    public void CriarAliancaS()
    {
        estadosUnidos.GetSeato();
    }

    public void CriarAliancaA()
    {
        estadosUnidos.GetTensao();
    }
}
