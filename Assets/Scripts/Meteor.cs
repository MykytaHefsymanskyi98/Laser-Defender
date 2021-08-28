using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Damagedealer damageDealer = collision.gameObject.GetComponent<Damagedealer>();
        if (!damageDealer)
        {
            return;
        }
    }
}
