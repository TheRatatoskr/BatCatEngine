using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;


public class Joiner : MonoBehaviour
{

  public void JoinServer()
    {
        NetworkManager.Singleton.StartClient();
    }

}
