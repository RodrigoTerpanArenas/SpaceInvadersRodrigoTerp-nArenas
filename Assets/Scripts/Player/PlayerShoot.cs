using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShoot : MonoBehaviour
{
    //Código que va a controlar el disparo del jugador
    //Las variables que controlan el disparo.
    public GameObject bullet, bulletBlue, bulletRed; //Los distintos tipos de balas.
    private GameObject placeHolder; //El holder que se va a disparar.
    private Transform shotOrigin;
    private static float timeBetweenShots;
    private float lastShot;

    private Button botFire;

    //Componente de audio
    private AudioSource source;

    void Start()
    {
        //Inicializamos las variables
        timeBetweenShots = 0.8f;
        lastShot = Time.time; //Inicializamos el tiempo inicial antes de disparo.

        //Obtenemos la ubicación del transform de donde se van a originar los disparos.
        shotOrigin = gameObject.transform.GetChild(0).GetComponent<Transform>();

        //agregamos listners a los botones
        botFire = GameObject.Find("ButtonFire").GetComponent<Button>();
        botFire.onClick.AddListener(() => Choose());

        //Inicializamos el audiosource
        source = gameObject.GetComponent<AudioSource>();
    }

    #region shoot
    void Update()
    {
        //Aquí vamos a manejar las variables con las cuales se va a dispárar.
        if(UpgradeManager.upgradeB)
        {
            placeHolder = bulletBlue;
            if(UpgradeManager.upgradeR)
            {
                UpgradeManager.upgradeB = false;
                placeHolder = bulletRed;
            }   
        }

        else if(UpgradeManager.upgradeR)
        {
            placeHolder = bulletRed;
            if (UpgradeManager.upgradeB)
            {
                UpgradeManager.upgradeR = false;
                placeHolder = bulletBlue;
            }
        }
        else
        {
            placeHolder = bullet;
        }

        //Aquí vamos a controlar la función de disparo, incluyendo los diversos upgrades que puede tener.   
        if (Input.GetButtonDown("Fire1"))
        {
            Choose();
        }
    }
    void Choose()
    {
        if (UpgradeManager.upgradeY)
        {
            Double(placeHolder);
        }
        else
        {
            Fire(placeHolder);
        }
    }

    void Fire(GameObject projectile)
    {
        if ((Time.time - lastShot) > timeBetweenShots)
        {
            source.Play();
            lastShot = Time.time; //Aumentamos el tiempo que debe ser medido para que se pueda disparar de nuevo.
            Instantiate(projectile, shotOrigin.position, shotOrigin.rotation); //Generamos una nueva bala.  
        }

    }
    void Double(GameObject projectile)
    {
        if ((Time.time - lastShot) > timeBetweenShots)
        {
            source.Play();
            lastShot = Time.time; //Aumentamos el tiempo que debe ser medido para que se pueda disparar de nuevo.
            Instantiate(projectile, shotOrigin.position + Vector3.right, shotOrigin.rotation); //Generamos una nueva bala.  
            Instantiate(projectile, shotOrigin.position + Vector3.left, shotOrigin.rotation); //Generamos una bala adicional
        }

    }
    #endregion
}

