using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damagedealer : MonoBehaviour
{
    //conf param
    [SerializeField] int damage;

    public int GetDamage()
    {
        return damage;
    }    

    public void Hit()
    {
        Destroy(gameObject);
    }
}
