using UnityEngine;
using Photon;
using Photon.Pun;

public class QuickStartRoomController : MonoBehaviourPunCallbacks
{
  // Start is called before the first frame update
  [SerializeField] private int multiplayerSceneIndex;
    
  public override void OnEnable()
  {
    PhotonNetwork.AddCallbackTarget(this);
  }
  public override void OnDisable()
  {
    PhotonNetwork.RemoveCallbackTarget(this);
  }
  public override void OnJoinedRoom()
  {   Debug.Log("Joined Room");
      StartGame();    
  }
  private void StartGame()
    {
      if (PhotonNetwork.IsMasterClient)
      {
        Debug.Log("Starting the Game, I am the Master!");
        PhotonNetwork.LoadLevel(multiplayerSceneIndex);
      }
    }

}
