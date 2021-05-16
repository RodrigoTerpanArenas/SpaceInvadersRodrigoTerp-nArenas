using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour
{
    //Este script se encarga de mantenerse al tanto de cuales upgrades han sido generados y consumidos.
    //Además controla elementos del UI que señalan cuanto tiempo le queda al jugador.

    //Variables
    public static bool upgradeY, upgradeR, upgradeB, onAir, powered;
    public static bool geneY, geneB, geneR;
    private bool timerOn;
    private float timerFloat, timerMax;

    //Variables UI   
    private Slider sliderUI;

    void Start()
    {
        geneY = false;
        geneR = false;
        geneR = false;
        upgradeY = false;
        upgradeR = false;
        upgradeB = false;
        onAir = false;
        powered = false;
        timerOn = false;
        SetupSlider();
    }

    
    void Update()
    {
        if(!timerOn && powered)
        {
            if (upgradeY) timerFloat = 7.0f;
            else if (upgradeB) timerFloat = 6.0f;
            else if (upgradeR) timerFloat = 5.0f;
            timerMax = timerFloat;
            timerOn = true;
        }

        if(timerOn)
        {
            timerFloat -= Time.deltaTime;
            sliderUI.value = timerFloat/timerMax;
        }
        if (timerFloat <= 0)
        {
            timerFloat = 0;
            timerMax = 0;
            upgradeY = false; upgradeR = false; upgradeB = false;
            onAir = false;
            powered = false;
            timerOn = false;       
        }
    }

    private void SetupSlider()
    {
        sliderUI = GameObject.Find("SliderUpgrade").GetComponent<Slider>();
        sliderUI.minValue = 0;
        sliderUI.maxValue = 1;
        sliderUI.wholeNumbers = false;
    }
}
