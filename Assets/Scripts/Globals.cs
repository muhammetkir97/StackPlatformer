using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globals : MonoBehaviour
{
    public static Globals instance = null;

    private float characterSpeedBase = 0.04f;
    private float characterSpeedMultiplier = 1.2f;

    private float blockSpeedBase = 0.1f;
    private float blockSpeedMultiplier = 1.2f;

    private float spanwDistance = 5;


    private void Awake() 
    {
        if(instance != this) instance = this;
    }


    void Start()
    {
        
    }

    public float GetCharacterSpeed(int level)
    {
        float value = characterSpeedBase;

        for(int i=0; i<level; i++)
        {
            value = value * characterSpeedMultiplier;
        }

        return value;
    }

    public float GetBlockSpeed(int level)
    {
        float value = blockSpeedBase;

        for(int i=0; i<level; i++)
        {
            value = value * blockSpeedMultiplier;
        }

        return value; 
    }

    public float GetSpawnDistance()
    {
        return spanwDistance;
    }


}
