using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //Esta clase está encargada de cargar las distribuciones de enemigos y moverlas de forma simultanea en el área de juego.
    private static Transform container;
    private static Vector3 positionOrig;
    private float speed;
    private float height;

    //Tomamos la información que necesitamos del manager:
    int state;
    string path;

    public const string enemyPath = "Prefabs/"; //En donde se encuentran los prefabs de los enemigos.
    private static string dataPath = string.Empty; //String en donde va a ir el json.

    void Awake()
    {
        state = ManagerScript.state;
        path =  ManagerScript.indentificador;
        //Con esto cargamos el archivo Json adecuado
    }

    private void Start()
    {
        //Primero, inicializamos un par de datos que necesitamos para centrar el objeto que maneja a los componentes.
        height = ManagerScript.maxY;
        Vector3 origin = new Vector3(0, height * 0.75f, 0); //centramos el origen de los enemigos a 2/3 de la altura de la pantalla.

        //Inicializamos el componente padre.
        container = GetComponent<Transform>();
        container.position = origin;
        positionOrig = origin;
        

        //Con el JSON, podemos instanciar a los enemigos.
        LoadData.Load(path);

        //Finalmente mandamos a llamar el método de movimiento
        int modifier = ManagerScript.state;
        speed = 0.05f * modifier;
        InvokeRepeating("Movement",1.0f, 0.5f);
    }

    #region move
    private void Movement()
    {
        //Aquí  vamos a mover el objetode manera horizontal y vamos a verificar si alguno de los objetos ha llegado a alcanzar al jugador.
        //De ser asi, se acaba el juego (Se activa la bandera de GamOver).

        container.position += Vector3.down * speed;

        foreach (Transform enemy in container)
        {
            if (enemy.position.y <= 1)
            {
                Score.isDead = true;
                Time.timeScale = 0;
            } 
        }
        if (container.childCount == 0)
        {
            Score.isWin = true;
            Time.timeScale = 0;
        }

    }
    #endregion

    #region load
    public static void Generate(string name, Vector3 position, Quaternion rotation)
    {
        GameObject prefab = Resources.Load<GameObject>(name);

        GameObject obj = Instantiate(prefab, positionOrig + position, rotation) as GameObject;

        obj.transform.parent = container;
    }

    public static void Generate(ActorData data, string path, string name, Vector3 position, Quaternion rotation)
    {
        string compName = string.Concat(path,name);
        Generate(compName, position, rotation);
    }
    #endregion

}
