using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class PlayerAttack : NetworkBehaviour
{
    [SerializeField] private bool _isAttacking = false;
    [SerializeField] private bool _isRebounding = false;

    private Vector3 _startingPosition;
    [SerializeField] private float _moveToPosition;

    private Vector2 _destinationPosition;

    [SerializeField] private float _stabSpeed;
    [SerializeField] private float _stabTime;

    private float _stabStartTime;

    [SerializeField] private int _whichWeapon = 0;

    [SerializeField] private InputReader inputReader;

    private void Start()
    {
        inputReader.PrimaryFireEvent += StartAttacking;
        _startingPosition = transform.position;
    }


    private void StartAttacking(bool buttonStatus)
    {
        if (!_isAttacking && buttonStatus)
        {
            _isAttacking = true;
            switch(_whichWeapon)
            {
                case 0:
                    StartCoroutine(SpearBehaviour());
                    break;
                default: 
                    break;
            }

        }

    }
    private IEnumerator SpearBehaviour()
    {
        _stabStartTime = Time.time;
        Debug.Log("Move Forward Script");
        while (_stabStartTime + _stabTime > Time.time)
        {
            transform.Translate(Vector3.up * _stabSpeed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        transform.localPosition = _startingPosition;
        _isAttacking = false;
       
    }
}
