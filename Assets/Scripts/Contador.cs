using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Contador : MonoBehaviour
{
    public float tiempoTotal; 
    public TMP_Text textoContador;

    public delegate void TiempoAgotadoAction();
    public static event TiempoAgotadoAction OnTiempoAgotado;

    private void Start()
    {
        
    }

    private void Update()//Si NO se acaba el tiempo
    {
        if(tiempoTotal>0)
        {
            tiempoTotal-=Time.deltaTime;
            ActualizarTextoContador();
        }
        else if(tiempoTotal<0)
        {
            tiempoTotal = 0;//Asi NO habra tiempos negativos
            ActualizarTextoContador();
            OnTiempoAgotado?.Invoke();
        }
        
    }

    private void ActualizarTextoContador()
    {
        int minutos = Mathf.FloorToInt(tiempoTotal / 60f);
        int segundos = Mathf.FloorToInt(tiempoTotal % 60f);
        string tiempoFormateado = string.Format("{0:00}:{1:00}", minutos, segundos);
        textoContador.text = "Remaining Time: " + tiempoFormateado;
    }
}