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

    private void Start()
    {
        _startingPosition = transform.position;
    }

    private void Update()
    {
        HandleAttacking();

    }

    private void HandleAttacking()
    {
        if (_isAttacking)
        {
            _destinationPosition = new Vector2(_startingPosition.x, _startingPosition.y + _moveToPosition);
            //transform.position = Vector2.MoveTowards(transform.position, _destinationPosition, _stabSpeed * Time.deltaTime);
            transform.Translate(0, _moveToPosition * Time.deltaTime, 0);

            if(transform.position.y >= _destinationPosition.y)
            {
                _isRebounding = true;
            }

            if (_isRebounding)
            {
                transform.position = Vector2.MoveTowards(transform.position, _startingPosition, _stabSpeed * Time.deltaTime);

                if (transform.position == _startingPosition)
                {
                    
                    _isAttacking = false;
                    _isRebounding = false;
                }

            }
        }
    }

    private void BasicStabAttack()
    {
        _isAttacking = true;
    }
}
