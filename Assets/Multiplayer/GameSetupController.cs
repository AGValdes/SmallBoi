using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameSetupController : MonoBehaviour
{
  // Start is called before the first frame update
  void Start()
  {
  CreatePlayer();
  }

  // Update is called once per frame
  private void CreatePlayer()
  {
    Debug.Log("Creating Player");
    if(PhotonNetwork.IsMasterClient)
    {
      Debug.Log("I am the current Player 1");
      PhotonNetwork.Instantiate(Path.Combine("Prefab", "MagicDiamond"), Vector3.zero, Quaternion.identity);
    }
    else
    {
      Debug.Log("I am the current Player 2");
      PhotonNetwork.Instantiate(Path.Combine("Prefab", "SuperCircle"), Vector3.zero, Quaternion.identity);
    }
  }
}
