using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Wai;

public class Death : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        var player = other.collider.GetComponent<Move>();
        if(player != null)
        {
            player.Die();
        }
    }
}
