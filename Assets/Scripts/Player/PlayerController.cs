using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    #region variables
    //Aquí vamos a controlar el movimiento del jugador.
    //Primero vamos a establecer las variables que controlan a la nave.
    private Transform objeto;
    float eje;
    private readonly float speed = 0.3f;
    private float maximoX, minimoX, maximoY;

    //Ancho del sprite
    private float objectWidth;

    //Variables para el control touch
    private bool isTouch, isRight, isLeft;
    
    #endregion

    #region start
    void Start()
    {
        //Obtenemos el componente transform que nos permitirá mover al jugador.
        objeto = this.GetComponent<Transform> ();
        objeto.position = new Vector3(0,2,0);

        //Obtenemos el valor de ancho del sprite.
        objectWidth = objeto.GetComponent<SpriteRenderer>().bounds.extents.x;

        //Delimitamos los máximos de la pantalla.
        maximoX = ManagerScript.maxX - objectWidth;
        minimoX = ManagerScript.minX + objectWidth;
        maximoY = ManagerScript.maxY;

        //Inicializamos los bools de la pantalla tactil
        isTouch = false;
        isRight = false;
        isLeft = false;
       
    }
    #endregion

    #region movement
    private void FixedUpdate()
    {
        //Aquí vamos a controlar la función de movimiento.
        if(isTouch)
        {
            if(isRight)
            {
                eje = 1.0f;
            }
            if(isLeft)
            {
               eje  =-1.0f;
            }
        }
        else
        {
            eje = Input.GetAxis("Horizontal"); 
        }
        

        //Condiciones en las cuales no se mueve el jugador:
        if (objeto.position.x < minimoX && eje < 0)
        {
            eje = 0;
        }

        if (objeto.position.x > maximoX && eje > 0)
        {
            eje = 0;
        }
        //Con esto movemos al jugador cada cuadro.
        MoveCharacter(eje);
    }

    void MoveCharacter(float magnitud)
    {
        objeto.position += (Vector3.right * speed * magnitud);
    }

    public void signalLeft()
    {
        isTouch = true;
        isLeft = true;
    }
    public void signalRight()
    {
        isTouch = true;
        isRight = true;
    }
    public void abandonLeft()
    {
        isTouch = false;
        isLeft = false;
    }
    public void abandonRight()
    {
        isTouch = false;
        isRight = false;
    }

    #endregion
   
}
