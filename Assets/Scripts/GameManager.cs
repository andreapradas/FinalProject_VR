using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    float tiempo;

    int escenariosCompletados;
    int objetosInteractuados;
    int pistasRecogidas;

    int mejorPuntuacion;

    void Start()
    {
        DontDestroyOnLoad(this); 
        mejorPuntuacion = PlayerPrefs.GetInt("MejorPuntuacion", 0);
    }

    void Update()
    {
        
    }

    public void ActualizarMejorPuntuacion(int puntuacion)
    {
        if (puntuacion > mejorPuntuacion)
        {
            mejorPuntuacion = puntuacion;
            PlayerPrefs.SetInt("MejorPuntuacion", mejorPuntuacion);
            PlayerPrefs.Save();
        }
    }

    public int ObtenerMejorPuntuacion()
    {
        return mejorPuntuacion;
    }
}
