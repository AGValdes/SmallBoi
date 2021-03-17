using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameSetupController : MonoBehaviour
{
  [SerializeField]private string prefabFolderLocation;
  [SerializeField] private string playerOnePrefabName; 
  [SerializeField] private string playerTwoPrefabName;
  [SerializeField] private Vector3 playerOneSpawn;
  [SerializeField] private Vector3 playerTwoSpawn;

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
      PhotonNetwork.Instantiate(Path.Combine(prefabFolderLocation, playerOnePrefabName), playerOneSpawn, Quaternion.identity);
    }
    else
    {
      Debug.Log("I am the current Player 2");
      PhotonNetwork.Instantiate(Path.Combine(prefabFolderLocation, playerTwoPrefabName), playerTwoSpawn, Quaternion.identity);
    }
  }
}
