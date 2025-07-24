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
        estadosUnidos.tiarA = true;
    }

    public void CriarAliancaO()
    {
        estadosUnidos.otanA = true;
        armasI.PactoVarsovia();
    }

    public void CriarAliancaS()
    {
        estadosUnidos.seatoA = true;
    }

    public void CriarAliancaA()
    {
        estadosUnidos.anzusA = true;
    }
}
