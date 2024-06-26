using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamePlayManager : Singleton<GamePlayManager>
{
    public float tiempoTotal;
    public int escenariosCompletados;
    public int objetosInteractuados;
    public int pistasRecogidas;
    public Text textoTimer;
    public GameObject reticula;
    public GameObject[] iluminacionPuerta = new GameObject[3];

    public GameObject[] pistas= new GameObject[2];
    public Transform[] SpawningClueZones1 = new Transform[2];
    public Transform[] SpawningClueZones2 = new Transform[2];
    public Transform[] SpawningClueZones3 = new Transform[2];

    private string menuPrincipal = "Menu";

    private void Start()
    {
        DontDestroyOnLoad(this); //Asi NO se destruira entre escenas
        Contador.OnTiempoAgotado += TiempoAgotadoHandler;

        tiempoTotal = 360f; //En segundos, 6 min 
        escenariosCompletados = 0;
        StartCoroutine(SpawnPistas(escenariosCompletados));
        pistasRecogidas = 0;
        objetosInteractuados = 0;
        DesactivarTodasLuces();//Apagar TODAS las luces verde 
    }
    private void DesactivarTodasLuces()
    {
        foreach (var iluminacionPuerta in iluminacionPuerta)
        {
            iluminacionPuerta.SetActive(false);
        }
    }
    private void Update()
    {
        if (tiempoTotal > 0)
        {
            tiempoTotal -= Time.deltaTime;
        }else//Si se agota el CONTADOR 
        {   
            tiempoTotal = 0;
            SceneManager.LoadScene(menuPrincipal);
        }

        if(escenariosCompletados==0 && objetosInteractuados==1 && pistasRecogidas == 2)
        {
            reticula.SetActive(true);//activar mirilla
            iluminacionPuerta[escenariosCompletados].SetActive(true);//Encender luz verde
        }else if(escenariosCompletados == 1 && objetosInteractuados == 1 && pistasRecogidas == 2)
        {
            iluminacionPuerta[escenariosCompletados].SetActive(true);
        }
        else if (escenariosCompletados == 2 && objetosInteractuados == 1 && pistasRecogidas == 2)//Juego completado, mostrar puntuacion en el menu
        {   
            iluminacionPuerta[escenariosCompletados].SetActive(true);
        }
    }

    public IEnumerator SpawnPistas(int escenariosCompletados)
    {
        while (true)
        {
            switch (escenariosCompletados)
            {
                case 0:
                    yield return new WaitForSeconds(Random.Range(5, 10));
                    Instantiate(pistas[Random.Range(0,2)], SpawningClueZones1[Random.Range(0,2)]);
                    break;
                case 1:
                    yield return new WaitForSeconds(Random.Range(5, 10));
                    Instantiate(pistas[Random.Range(0,2)], SpawningClueZones2[Random.Range(0,2)]);
                    break;
                case 2:
                    yield return new WaitForSeconds(Random.Range(5, 10));
                    Instantiate(pistas[Random.Range(0,2)], SpawningClueZones3[Random.Range(0,2)]);
                    break;
                default:
                    break;
            }
        }
    }

    private void StopSpawingPistas(int escenariosCompletados)
    {
        int i;
        if(escenariosCompletados==1){
            i = escenariosCompletados-1;
            StopCoroutine(SpawnPistas(i));//Parar pistas del escenario 1
        }else if(escenariosCompletados==2){
            i = escenariosCompletados-1;
            StopCoroutine(SpawnPistas(i));
        }else{
            i = escenariosCompletados-1;
            StopCoroutine(SpawnPistas(i));
        }
    }

    public void objectoInteractivo()
    {
        objetosInteractuados ++;
    }

    public void pistaRecogida()
    {
        pistasRecogidas ++;
    }

    public void setEscenario2()
    {
        escenariosCompletados = 1;
        pistasRecogidas = 0;
        objetosInteractuados = 0;
        StopSpawingPistas(escenariosCompletados);
        StartCoroutine(SpawnPistas(escenariosCompletados));
    }

    public void setEscenario3()
    {
        escenariosCompletados = 2;
        pistasRecogidas = 0;
        objetosInteractuados = 0;
        StopSpawingPistas(escenariosCompletados);
        StartCoroutine(SpawnPistas(escenariosCompletados));
    }

    private int CalcularPuntuacion(float tiempoRestante)
    {
        int puntuacion = 0;

        if (tiempoRestante >= 300) 
        {
            puntuacion = 100; //Puntuación max
        }
        else if (tiempoRestante >= 180) 
        {
            puntuacion = 50; // intermedia
        }
        else
        {
            puntuacion = 25; //mínima
        }
        return puntuacion;
    }

    public void EscapeRoomCompletado()
    {
        float tiempoRestante = tiempoTotal;
        int puntuacion = CalcularPuntuacion(tiempoRestante);
    }
    private void TiempoAgotadoHandler()
    {
        SceneManager.LoadScene("Menu");
    }

    private void OnDestroy()
    {
        Contador.OnTiempoAgotado -= TiempoAgotadoHandler;
    }
}
