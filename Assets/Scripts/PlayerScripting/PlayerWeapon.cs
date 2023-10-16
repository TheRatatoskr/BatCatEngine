using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Unity.Netcode;


public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] private int _weaponType = 0;
    [SerializeField] private int _element = 0;

    [SerializeField] private float _minDamage = 1f;
    [SerializeField] private float _maxDamage = 2f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //collision.gameObject.
        //if other object is not owned by player
        switch(collision.gameObject.tag)
        {
            case "Player": //i hit a player
                break;
            default: break;

        }

    }

}
