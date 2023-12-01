using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Hud : MonoBehaviour
{

    private Vector3 hudUpPos;
    private Vector3 hudDownPos;
    float hudSizeY;
    private float hudSpeed = 3000;

    private bool IsMoved = false;

    // Start is called before the first frame update
    void Start()
    {
        hudSizeY = transform.localScale.y * 550;

        hudUpPos = transform.position;
        hudDownPos = new Vector3(transform.position.x, transform.position.y - hudSizeY, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    


    

    public void spawnHud()
    {
        if(!gameObject.activeInHierarchy)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
    
}
