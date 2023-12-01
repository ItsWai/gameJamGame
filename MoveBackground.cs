using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{

    private float startPos;
    private float startPosY;
    private GameObject cam;
    [SerializeField] private float parallaxEffect;
    [SerializeField] private float parallaxOffsetY;

    private float length;
    private float lengthy;

    // Start is called before the first frame update
    void Start()
    {
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        lengthy = GetComponent<SpriteRenderer>().bounds.size.y;
        cam = GameObject.Find("Virtual Camera");
        startPos = transform.position.x;
        startPosY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        float temp = (cam.transform.position.x * (1 -parallaxEffect));
        float dist = (cam.transform.position.x * parallaxEffect);
        float disty = (cam.transform.position.y * parallaxOffsetY);
        float tempy = (cam.transform.position.y * (1 - parallaxOffsetY));
        transform.position = new Vector3(startPos + dist, transform.position.y, transform.position.z);
        transform.position = new Vector3(transform.position.x, startPosY + disty,  transform.position.z);

        if (temp > startPos + length && tempy > startPosY + lengthy)
        {
            startPos += length;
            startPosY = lengthy;
        }
        else if(temp < startPos - length && tempy < startPosY - lengthy)
        {
            startPos -= length;
            startPosY -= lengthy;
        }
    }
}
