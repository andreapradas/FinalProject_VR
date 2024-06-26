using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class siguienteEscenario : MonoBehaviour
{
    public UnityEvent evento;
    public Camera mainCamera;
    public GamePlayManager playManager;
    public Transform teletransportPoint2;
    public Transform teletransportPoint3;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("InteractiveDoor1"))
        {
            mainCamera.transform.position = teletransportPoint2.transform.position;//Mover la camara hasta el centro del escenario2
            playManager.setEscenario2();
        }
        else if(other.CompareTag("InteractiveDoor2"))
        {
            mainCamera.transform.position = teletransportPoint3.transform.position;//Mover la camara hasta el centro del escenario3
            playManager.setEscenario3();
        }
        else if(other.CompareTag("InteractiveDoor3"))
        {
            //Se acaba el juego, mostrar menu principal, puntuacion y mensaje de finalizacion
            SceneManager.LoadScene(0);
        }
    }
}
