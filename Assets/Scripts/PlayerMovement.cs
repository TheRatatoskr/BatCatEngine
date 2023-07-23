using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using Cinemachine;

public class PlayerMovement : NetworkBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _vCamera;


    public override void OnNetworkSpawn()
    {

        if(IsOwner)
        {
            _vCamera.Priority = 1;
        }
        else
        {
            _vCamera.Priority = 0;
        }

    }

}
