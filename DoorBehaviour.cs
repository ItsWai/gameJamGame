using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehaviour : MonoBehaviour
{
    [SerializeField] SwitchBeahaviour switchBehaviour;

    float fieldSizeY;

    Vector3 fieldUpPos;
    Vector3 fieldDownPos;
    
    [SerializeField] float fieldSpeed = 1f;

    public bool isOn = false;

    // Start is called before the first frame update
    void Awake()
    {
        fieldSizeY = transform.localScale.y * 4;

        fieldDownPos = transform.position;
        fieldUpPos = new Vector3(transform.position.x, transform.position.y + fieldSizeY, transform.position.z);

      

    }

    // Update is called once per frame
    void Update()
    {
        if(isOn)
        {
            TurnFieldOn();
        }

        if(!isOn)
        {
            TurnFieldOf();
        }

    }

    private void TurnFieldOn()
    {
        

        if (transform.position != fieldUpPos)
        {
            transform.position = Vector3.MoveTowards(transform.position, fieldUpPos, fieldSpeed * Time.deltaTime);
        }
    }

    private void TurnFieldOf()
    {
        if (transform.position != fieldDownPos)
        {
            transform.position = Vector3.MoveTowards(transform.position, fieldDownPos, fieldSpeed * Time.deltaTime);
        }
    }

    public void MoveField()
    {

        if (switchBehaviour.isOnSwitch && !isOn)
        {
           isOn = !isOn;
        }
        else if (switchBehaviour.isOfSwitch && isOn)
        {
           isOn = !isOn;
        }
    }
}
