using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//Clase abstracta de la cual van a heredar todos los enemigos.

public abstract class AbstractEnemy : MonoBehaviour
{
    #region Variables&Events
    //Las variables que debe tener cada enemigo:
    protected int enemyHealth;
    protected int enemyPoint;
    protected int multiplier, daño, score, upG;
    protected Sprite alternateSprite, defeatedSprite;
    protected SpriteRenderer spriteRenderer;
    protected GameObject UpD, UpB, UpR;
    protected float YMax, y;

    //Evento para el efecto de sonido
    public static event Action Defeated;

    //Ahora, como queremos que todos los enemigos compartan el mismo comportamiento cuando una bala colisione con ellso, escribiremos esto aquí.
    //El comportamiento de movimiento se manejará en otro script ya que ese es global para todos los enemigos.

    #endregion

    #region damege&destroy
    //Método abstracto heredable por todos los enemigos.
    protected int CalculateScore(int value, float distance, float max)
    {
        if (distance <= max / 3)
        {
            multiplier = 1;
        }
        else if (distance <= (2 * max / 3))
        {
            multiplier = 2;
        }
        else
        {
            multiplier = 3;
        }

        return(value*multiplier);
    }

    protected void Audio()
    {
        Defeated?.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        switch (col.tag)
        {
            case "BulletN":
                daño = 1;
                Damage(daño);
                break;
            case "BulletM":
                daño = 2;
                Damage(daño);
                break;
            case "BulletS":
                daño = 3;
                Damage(daño);
                break;
            default:
                break;
        }
    }

    protected void Damage(int damage)
    {
        if (enemyHealth - damage <= 0)
        {
            //Calcula la distancia vertical del enemigo
            YMax = ManagerScript.maxY;
            y = gameObject.transform.position.y;

            //Calcula la puntuación
            score = CalculateScore(enemyPoint, y, YMax);
            
            //Usa el efecto de sonido y cambia el sprite.
            Audio();
            spriteRenderer.sprite = defeatedSprite;
            Score.score += score;

            //Genera upgrade
            if(!UpgradeManager.onAir)
            {
                GenerateUpgrade();
                UpgradeManager.onAir = true;
            }
            

            //Destruye al enemigo
            Destroy(this.gameObject, 0.5f);

        }

        else
        {
            enemyHealth -= daño;
            if(enemyHealth == 1)
            {
                spriteRenderer.sprite = alternateSprite;
            }
        }

    }
    #endregion

    #region upgrades
    private void GenerateUpgrade()
    {

        //Puede generar un upgrade.
        upG = UnityEngine.Random.Range(0, 10);
        if (upG >= 7)
        {
            switch (upG)
            {
                case 7:
                    if(!UpgradeManager.geneY)
                    {
                        Instantiate(UpD, gameObject.transform.position, Quaternion.identity);
                        UpgradeManager.geneY = true;
                    }
                    
                    break;
                case 8:
                    if (!UpgradeManager.geneB)
                    {
                        Instantiate(UpB, gameObject.transform.position, Quaternion.identity);
                        UpgradeManager.geneB = true;
                    }
                    break;
                case 9:
                    if (!UpgradeManager.geneR)
                    {
                        Instantiate(UpR, gameObject.transform.position, Quaternion.identity);
                        UpgradeManager.geneR = true;
                    }
                    break;
                default:
                    break;
            }
        }
    }
    #endregion
}
