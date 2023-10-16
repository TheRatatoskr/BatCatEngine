using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StabbyTesting : MonoBehaviour
{
    [SerializeField] private Vector2 _neutralPosition;

    [SerializeField] float _attackSpeed = 3f;

    [SerializeField] private int _whatWeaponAmIHolding =0;

    [SerializeField] private bool _isAttacking = true;

    [SerializeField] private float _moveDistance = 30f;

    [SerializeField] private GameObject _daWeapon;

    private void Start()
    {
        _neutralPosition = new Vector2(_daWeapon.transform.position.x, transform.position.y);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.J))
        {
            
            PAttackWasDeclared();
        }
    }
    private void PAttackWasDeclared()
    {
        _isAttacking = true;
        switch (_whatWeaponAmIHolding)
        {
            case 0:

                Debug.Log("in the switch");
                StartCoroutine(PSpearBehaviour());
                break;
            case 1:break;
            case 2:break;
            default:break;
        }
    }
    private IEnumerator PSpearBehaviour()
    {
        while (_isAttacking)
        {
            _daWeapon.transform.Translate(Vector2.up * _attackSpeed);

            yield return new WaitForEndOfFrame();
            if (_daWeapon.transform.position.y > _moveDistance)
            {
                _isAttacking = false;
                _daWeapon.transform.position = _neutralPosition;
            }

        }


        //return to neutral position
    }

}
