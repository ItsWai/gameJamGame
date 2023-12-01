using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SwitchBeahaviour : MonoBehaviour
{
    [SerializeField] private UnityEvent doSomething;

    public AudioClip click;
    public AudioSource sfx;

    [SerializeField] public bool isOnSwitch;
    [SerializeField] public bool isOfSwitch;

    float _switchSizeY;
    Vector3 _switchUpPos;
    Vector3 _switchDownPos;
    float _switchSpeed = 2f;
    float _switchDelay = 0.2f;
    public bool _isPressngSwich = false;

    // Start is called before the first frame update
    void Awake()
    {
        _switchSizeY = transform.localScale.y / 2;

        _switchUpPos = transform.position;
        _switchDownPos = new Vector3(transform.position.x, transform.position.y - _switchSizeY, transform.position.z);

    }

    // Update is called once per frame
    void Update()
    {
        if(_isPressngSwich)
        {
            MoveSwitchDown();
        }
        else if (!_isPressngSwich)
        {
            MoveSwitchUp();
        }
    }

    private void MoveSwitchUp()
    {
        if(transform.position != _switchUpPos)
        {
            transform.position = Vector3.MoveTowards(transform.position, _switchUpPos, _switchSpeed * Time.deltaTime);
        }
    }

    private void MoveSwitchDown()
    {
        if (transform.position != _switchDownPos)
        {
            transform.position = Vector3.MoveTowards(transform.position, _switchDownPos, _switchSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") || collision.CompareTag("Box"))
        {

            sfx.clip = click;
            sfx.Play();

            _isPressngSwich = !_isPressngSwich;

            doSomething.Invoke();
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") || collision.CompareTag("Box"))
        {
            StartCoroutine(SwitchUpDelay(_switchDelay));
        }
    }

    IEnumerator SwitchUpDelay(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        _isPressngSwich = false;
    }
}
