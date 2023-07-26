using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class CorePlayerAiming : NetworkBehaviour
{
    [SerializeField] private InputReader _inputReader;

    [SerializeField] private Transform _turretTransform;

    private void LateUpdate()
    {
        if (!IsOwner) return;
        Vector2 mouseScreenPosition = _inputReader.AimPosition;
        Vector2 aimWorldPostion = Camera.main.ScreenToWorldPoint(mouseScreenPosition);

        _turretTransform.up = new Vector2(aimWorldPostion.x - _turretTransform.position.x, aimWorldPostion.y - _turretTransform.position.y);
    }

}
