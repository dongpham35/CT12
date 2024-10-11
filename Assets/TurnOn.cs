using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOn : MonoBehaviour
{
    [SerializeField] private Light _light;
    private void OnEnable()
    {
        TurnOff_TurnOnLight.Instance.stateLight += OnSetIntensity;
    }

    private void OnDisable()
    {
        TurnOff_TurnOnLight.Instance.stateLight += OnSetIntensity;
    }

    private void OnSetIntensity(int intensity)
    {
        _light.intensity = intensity;
    }
}
