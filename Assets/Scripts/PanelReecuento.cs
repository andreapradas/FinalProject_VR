using UnityEngine;
using UnityEngine.UI;

public class PanelReecuento : MonoBehaviour
{
    private int pistasEncontradas;
    private int salasSuperadas;
    private int objetosInteractuados;
    GamePlayManager manager;

    public Text textoPanel;

    void Start()//Inicializar las variables
    {
        pistasEncontradas = manager.pistasRecogidas;
        salasSuperadas = manager.escenariosCompletados;
        objetosInteractuados = manager.objetosInteractuados;
    }

    public void IncrementarPistas()
    {
        pistasEncontradas++;
        ActualizarPanel();
    }

    public void IncrementarSalas()
    {
        salasSuperadas++;
        ActualizarPanel();
    }

    public void IncrementarObjetos()
    {
        objetosInteractuados++;
        ActualizarPanel();
    }

    private void ActualizarPanel()
    {
        textoPanel.text = "Pistas Recogidas: " + pistasEncontradas.ToString() +
                          "\nObjetos Interactuados: " + objetosInteractuados.ToString() +
                          "\nSalas Superadas: " + salasSuperadas.ToString();
    }
}
