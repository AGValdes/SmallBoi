using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameSetupController : MonoBehaviourPunCallbacks
{
  

  [SerializeField] private string PrefabFolderName;
  [SerializeField] private string playerOnePrefabName;
  [SerializeField] private string playerTwoPrefabName;
  [SerializeField] private string baddiePrefabName;
  [SerializeField] private string platformPrefabName;
  [SerializeField] private GameObject platform;
  [SerializeField] private Vector3 p1StartPoint;
  [SerializeField] private Vector3 p2StartPoint;
  [SerializeField] private Vector3 baddiePoint;
  [SerializeField] private Vector3 platformPoint;
  private PhotonView pView;

  // Start is called before the first frame update
  void Start()
  {
   
    pView = platform.GetComponent<PhotonView>();

    if (pView == null) { Debug.LogError("photonView is null"); }
    else { Debug.Log($"View ID: {pView.ViewID}"); }
    //PhotonNetwork.SendRate = 60;
    
    
  CreatePlayer();
    SyncPlatform();
  }

  // Update is called once per frame
  private void CreatePlayer()
  {
    Debug.Log("Creating Player");
    if(PhotonNetwork.IsMasterClient)
    {
      Debug.Log("I am the current Player 1");
      PhotonNetwork.Instantiate(Path.Combine(PrefabFolderName, playerOnePrefabName), p1StartPoint, Quaternion.identity);
      PhotonNetwork.Instantiate(Path.Combine(PrefabFolderName, baddiePrefabName), baddiePoint, Quaternion.identity);      
      //PhotonNetwork.Instantiate(Path.Combine(PrefabFolderName, platformPrefabName), platformPoint, Quaternion.identity);
    }
    else
    {
      Debug.Log("I am the current Player 2");
      PhotonNetwork.Instantiate(Path.Combine(PrefabFolderName, playerTwoPrefabName), p2StartPoint, Quaternion.identity);
    }

  }
    void SyncPlatform()
    {
      if (!PhotonNetwork.IsMasterClient)
    {
      int viewId = pView.ViewID;
      Debug.Log($"Is NonMaster RPC: {viewId}");
      pView.RPC("SyncPositOfPlatform", RpcTarget.MasterClient, viewId);      
    }
      else { Debug.Log("Master Client. No Plat sync"); }
       //If you are not the master, then I want you to sync position with the master platform.  Once.  Just once..

    }
  [PunRPC]
  void SyncPositOfPlatform(int nonMasterViewID)
  {
    Debug.Log("SyncPositOfPlatform");
    PhotonView nonMaster = PhotonView.Find(nonMasterViewID);
    if (nonMaster != null)
    {

      GameSetupController nonMasterGameSetupController = nonMaster.GetComponent<GameSetupController>();
      Debug.Log($"NonMstr Posit: {nonMasterGameSetupController.transform.position}");
      Debug.Log($"Mstr Posit: {platform.transform.position}");
      nonMasterGameSetupController.platform.transform.position = platform.transform.position;
    }
    else { Debug.LogError($"{pView.ViewID}: nonMaster PhotonView is Null"); }
   
  }
  public void ExitRoom()
  {
    PhotonNetwork.LeaveRoom();    
  }
}
