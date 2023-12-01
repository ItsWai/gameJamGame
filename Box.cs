using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Wai;

public class Box : MonoBehaviour
{

    [SerializeField] float sizeChange;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Small"))
        {
            transform.localScale /= sizeChange;


        }

        if (collision.CompareTag("Big"))
        {
            transform.localScale *= sizeChange;


        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Small"))
        {
            transform.localScale *= sizeChange;

 
        }

        if (collision.CompareTag("Big"))
        {
            transform.localScale /= sizeChange;


        }
    }
}
