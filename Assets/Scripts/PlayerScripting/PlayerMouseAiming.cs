using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Unity.Netcode;
using UnityEngine;

public class PlayerMouseAiming : NetworkBehaviour
{
    [SerializeField] private InputReader _inputReader;

    [SerializeField] private Transform _weaponContainer;

    private void LateUpdate()
    {
        if (!IsOwner) return;
        Vector2 mouseScreenPosition = _inputReader.AimPosition;
        Vector2 aimWorldPostion = Camera.main.ScreenToWorldPoint(mouseScreenPosition);

        _weaponContainer.up = new Vector2(aimWorldPostion.x - _weaponContainer.position.x, aimWorldPostion.y - _weaponContainer.position.y);
    }
}
