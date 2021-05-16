using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UpgradeBehavior : MonoBehaviour
{
    private Transform upgradeTransform;

    public static event Action UpG;

    void Awake()
    {
        upgradeTransform = GetComponent<Transform>();
        InvokeRepeating("Moving", 0.3f, 0.3f);
    }

    private void Update()
    {
        if(upgradeTransform.position.y <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void Moving()
    {
        upgradeTransform.position += Vector3.down;
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            switch(gameObject.tag)
            {
                case "Double":
                    UpgradeManager.upgradeY = true;
                    break;
                case "Blue":
                    UpgradeManager.upgradeB = true;
                    break;
                case "Red":
                    UpgradeManager.upgradeR = true;
                    break;
                default:
                    break;
            }            
            UpG?.Invoke();
            UpgradeManager.powered = true;
            Destroy(gameObject);
        }
    }
}
