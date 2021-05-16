using System.Collections;
using UnityEngine;
using System.IO;
using System.Xml.Serialization;

public class LoadData
{
    public static ActorContainer actorContainer = new ActorContainer();

    public static void Load(string path)
    {
        actorContainer = LoadActors(path);

        foreach (ActorData data in actorContainer.actors)
        {
            
            EnemyMovement.Generate(data, EnemyMovement.enemyPath, data.name, 
                data.pos, Quaternion.identity);
        }
        ClearActorList();         
    }

    public static void ClearActorList()
    {
        //Limpia el consrtuctor actorContainer.
        actorContainer.actors.Clear();
    }

    private static ActorContainer LoadActors(string path)
    {
        TextAsset jsonString = Resources.Load(path) as TextAsset;
        //Esta función va a leer el archivo tipo JSON y nos va a regresar un contenedor con toda la información de enemigos.
        string json = jsonString.ToString();
        return JsonUtility.FromJson<ActorContainer>(json);
    }
}
