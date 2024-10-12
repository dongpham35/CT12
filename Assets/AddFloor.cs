using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddFloor : MonoBehaviour
{
    [SerializeField] private GameObject _floor;
    [SerializeField] private GameObject _railMaxHeight;
    [SerializeField] private Transform _pointCanAddFloors;

    private Stack<GameObject> _stack;

    private Vector3 staticPoint_floor = new Vector3(-1.7f, 0f, -15.7f);

    private void Start()
    {
        _stack = new Stack<GameObject>();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))//AddFloor
        {
            AddExtraFloor();
        }

        if(Input.GetKeyDown(KeyCode.Q))//RemoveFloor
        {
            RemoveFloor();
        }
    }

    private void AddExtraFloor()
    {
        GameObject floorClone = Instantiate(_floor);
        _stack.Push(floorClone);
        floorClone.transform.SetParent(_pointCanAddFloors);
         
        Vector3 pointOfFloor = staticPoint_floor + Vector3.up * (_stack.Count - 1) * 4f;
        floorClone.transform.localPosition = pointOfFloor;
        _railMaxHeight.transform.position += new Vector3(0, 4f, 0);
    }

    private void RemoveFloor()
    {
        if (_stack.Count == 0) return;
        GameObject floorClone = _stack.Pop();
        Destroy(floorClone);
        _railMaxHeight.transform.position -= new Vector3(0, 4f, 0);
    }
}
