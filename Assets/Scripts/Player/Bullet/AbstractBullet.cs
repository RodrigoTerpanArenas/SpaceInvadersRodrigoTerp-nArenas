using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractBullet : MonoBehaviour
{

    //Clase que controla proyectiles
    #region variables

    //Variables que dependen de cada proyectil
    protected float speed;
    
    //El máximo de la pantalla
    float mY = ManagerScript.maxY;

    //Variables del objeto
    protected Transform body;

    #endregion

    #region methods
    
    protected void FixedUpdate()
    {
        //Velocidad de la bala
        body.position += Vector3.up * speed;

        //Si la bala pasa de cierto límite, entonces se destruye
        if(body.position.y >= mY-2.0)
        {
            Destroy(gameObject);
        }
    }

    //Si colisiona con un enemigo
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }

    #endregion
}
