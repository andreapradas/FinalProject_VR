using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class InteractableDoor : MonoBehaviour
{
    public GameObject puerta;
    public GameObject interactiveDoor;
    public GameObject iluminacion;
    public Animator animDoor;

    void Start()
    {   
        animDoor = puerta.GetComponent<Animator>();
        interactiveDoor.SetActive(false); //Objeto para cambiar de ESCENARIO
    }

    void Update()
    {
     
    }
    
    private void ActionInteractable()
    {     
         animDoor.SetTrigger("open");//Clip de open 
         StartCoroutine(ActivateInteraction());
    }

    IEnumerator ActivateInteraction()
    {
        iluminacion.SetActive(false);
        yield return new WaitForSeconds(2);
        interactiveDoor.SetActive(true);
    }
}
