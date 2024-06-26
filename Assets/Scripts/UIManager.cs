using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public Text puntuacion;

    void Start()
    {
        MostrarMejorPuntuacion();
    }
    public void loadGameScene()//Al pulsar el boton Comenzar
    {
        SceneManager.LoadScene(1);
    }

    public void exitGame()
    {
        Application.Quit();
    }

    public void MostrarMejorPuntuacion()
    {
        int mejorPuntuacion = PlayerPrefs.GetInt("MejorPuntuacion", 0);

        puntuacion.text = "Mejor Puntuación: " + mejorPuntuacion.ToString();
    }
}
