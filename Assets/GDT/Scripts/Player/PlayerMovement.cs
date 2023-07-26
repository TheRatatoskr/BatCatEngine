using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using Cinemachine;

public class PlayerMovement : NetworkBehaviour
{
    [Header("Object References")]
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private Transform _bodyTransform;
    [SerializeField] private Rigidbody2D _body;

    [Header("Movement Settings")]
    [SerializeField] private float _moveSpeed = 4f;
    [SerializeField] private float _turningRate = 30f;

    private Vector2 _currentMovement;

    public override void OnNetworkSpawn()
    {
        if (!IsOwner)
        {
            return;
        }
        _inputReader.MoveEvent += UpdateMovement;
        
    }

    public override void OnNetworkDespawn()
    {
        if(!IsOwner)
        {
            return;
        }
        _inputReader.MoveEvent -= UpdateMovement;
    }

    private void UpdateMovement(Vector2 movementInput)
    {
        _currentMovement = movementInput;
    }
    private void UpdateMovement()
    {
        float zRotation = _currentMovement.x * -_turningRate * Time.deltaTime;
        _bodyTransform.Rotate(0f,0f,zRotation);
    }

    private void FixedUpdate()
    {
        if (!IsOwner) return;
        _body.velocity = (Vector2)_bodyTransform.up * _currentMovement.y * _moveSpeed;
    }

    private void Update()
    {
        if (!IsOwner) return;

        UpdateMovement();
    }


}
