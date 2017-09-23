using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{

    public int Plants = 0;
    public UnityEngine.UI.Text TextPlant;
    public int Gold = 0;
    public UnityEngine.UI.Text TextGold;
    public int Coal = 0;
    public UnityEngine.UI.Text TextCoal;
    public int Wind = 0;
    public UnityEngine.UI.Text TextWind;


    public int PlantsTarget = 0;
    public UnityEngine.UI.Text TextPlantTarget;
    public int GoldTarget = 0;
    public UnityEngine.UI.Text TextGoldTarget;
    public int CoalTarget = 0;
    public UnityEngine.UI.Text TextCoalTarget;
    public int WindTarget = 0;
    public UnityEngine.UI.Text TextWindTarget;

    public int collected = 0;
    public UnityEngine.UI.Text CollectedText;


    // Use this for initialization
    void Start ()
    {
        RandomizeTargets();
	}

    private void RandomizeTargets()
    {
        PlantsTarget = UnityEngine.Random.Range(0,3);
        GoldTarget = UnityEngine.Random.Range(0, 3);
        CoalTarget = UnityEngine.Random.Range(0, 3);
        WindTarget = UnityEngine.Random.Range(0, 3);
}

    // Update is called once per frame
    void Update ()
    {
        TextWind.text = Wind.ToString();
        TextGold.text = Gold.ToString();
        TextCoal.text = Coal.ToString();
        TextPlant.text = Plants.ToString();

        TextWindTarget.text = WindTarget.ToString();
        TextGoldTarget.text = GoldTarget.ToString();
        TextCoalTarget.text = CoalTarget.ToString();
        TextPlantTarget.text = PlantsTarget.ToString();

        CollectedText.text = "Collected: " + collected.ToString();
    }
    
    public bool CheckResults()
    {
        return (Wind >= WindTarget && Coal >= CoalTarget && Gold >= GoldTarget && Plants >= PlantsTarget);
    }

    public void ResetAll ()
    {
        //Wind = Gold = Coal = Plants = 0;
        Wind -= WindTarget;
        Gold -= GoldTarget;
        Plants -= PlantsTarget;
        Coal -= CoalTarget;

        
        RandomizeTargets();
    }


    internal void Collect(int type)
    {
        if (type == 1)
            Plants++;
        else if (type == 2)
            Gold++;
        else if (type == 4)
            Wind++;
        else if (type == 3)
            Coal++;
    }
}
