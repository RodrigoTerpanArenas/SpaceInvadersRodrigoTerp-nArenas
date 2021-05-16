using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartManager : MonoBehaviour
{
    //Este script va a controlar los elementos de canvas del inicio y va a dar el estado que queremos para el juego.

    //Primero, variables.
    public GameObject[] paneles = new GameObject[2]; 
    public Button bot1, bot2, bot3;

 
    void Start()
    {
        if (!paneles[0].activeInHierarchy) 
        {
            paneles[0].SetActive(true);
            paneles[1].SetActive(false);
        }

        //Inicializamos los botones y les damos listeners.
        bot1.onClick.AddListener(() => Estado(bot1.name));
        bot2.onClick.AddListener(() => Estado(bot2.name));
        bot3.onClick.AddListener(() => Estado(bot3.name));
    }

    //Esto es para alternar entre el menú principal y los créditos.
    public void Reverse()
    {
        foreach(GameObject p in paneles)
        {
            if(!p.activeInHierarchy)
            {
                p.SetActive(true);
            }
            else
            {
                p.SetActive(false);
            }
        }
    }

    //Esta función toma el nombre del botón y modifica el estado de la variable identificador para su uso en el juego.
    public void Estado(string name)
    {
        switch(name)
        {
            case "button1":
                ManagerScript.state = 1;
                ManagerScript.indentificador = "one";
                break;

            case "button2":
                ManagerScript.state = 2;
                ManagerScript.indentificador = "two";
                break;

            case "button3":
                ManagerScript.state = 3;
                ManagerScript.indentificador = "three";
                break;

            default:
                break;
        }
        ManagerScript.LoadGame();
    }

    
}
