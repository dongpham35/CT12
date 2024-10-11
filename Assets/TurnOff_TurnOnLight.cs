using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOff_TurnOnLight : MonoBehaviour
{
    public static TurnOff_TurnOnLight Instance {  get; private set; }
    public event Action<int> stateLight;

    private void OnEnable()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }


    public void ActiveLight(int Intesity)
    {
        stateLight?.Invoke(Intesity);
    }

}
