using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBattleMovement : MonoBehaviour
{

    [SerializeField] private float _movespeed = 4f;

    [SerializeField] private InputReader inputReader;

    [SerializeField] private float _jumpPower = 4f;

    private Rigidbody2D rb;

    private bool _isJumping = false;

    private Vector2 _currentMovement;
    

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        inputReader.MoveEvent += UpdateMovement;
        //inputReader.PrimaryFireEvent += JumpPlayer;
    }

    private void Update()
    {
        HandleMovement();

        if (_isJumping )
        {
            transform.Translate(new Vector3(0,_jumpPower * Time.deltaTime, 0));
        }
    }

    private void HandleMovement()
    {
        transform.Translate(_currentMovement.x * _movespeed * Time.deltaTime, 0, 0);
    }

    private void UpdateMovement(Vector2 movement)
    {
        _currentMovement = movement;
    }

    private void JumpPlayer(bool buttonPressed)
    {
        _isJumping = buttonPressed;

        Debug.Log("Jump Button " + buttonPressed.ToString());
        if(buttonPressed)
        {
            
        }
        else
        {
            // go down
        }
    }
}
