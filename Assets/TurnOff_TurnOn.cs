using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOff_TurnOn : MonoBehaviour
{
    private bool _isChangeState = true;
    [SerializeField] private Light _sun;
    [SerializeField] private float _speed;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T) && _isChangeState)
        {
            StartCoroutine(MoveSun(30, 191));
        }
        if(Input.GetKeyDown(KeyCode.B) && _isChangeState)
        {
            StartCoroutine(MoveSun(191, 390));
        }
        if (Input.GetKey(KeyCode.U) && !_isChangeState)
        {
            _speed += Time.deltaTime * 2f;
        }
        if(Input.GetKeyDown(KeyCode.R) && !_isChangeState)
        {
            _speed = 3f;
        }
    }


    IEnumerator MoveSun(float from, float to)
    {
        _isChangeState = false;
        while(from <= to)
        {
            from += Time.deltaTime * _speed;
            _sun.transform.Rotate(Vector3.right, Time.deltaTime * _speed);
            if(from >= 180 && from <= 360)
            {
                TurnOff_TurnOnLight.Instance.ActiveLight(1);
            }
            else
            {
                TurnOff_TurnOnLight.Instance.ActiveLight(0);
            }
            yield return new WaitForEndOfFrame();
        }
        
        _isChangeState = true;
        yield break;
    }


    public void TurnOnLight()
    {

    }

    public void TurnOffLight()
    {

    }

}
