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
            StartCoroutine(MoveObjectCoroutine());
        }

    }
    private IEnumerator MoveObjectCoroutine()
    {
        _stabStartTime = Time.time;
        Debug.Log("Move Forward Script");
        while (_stabStartTime + _stabTime > Time.time)
        {
            transform.Translate(Vector3.up * _stabSpeed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }


        yield return new WaitForSeconds(1.0f);

        Debug.Log("Return script");
        while (transform.position != _startingPosition)
        {
            Vector2.MoveTowards(transform.position, _startingPosition, _stabSpeed + _stabSpeed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }


        transform.position = _startingPosition;
        _isAttacking = false;
    }
}
