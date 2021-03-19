using System;
using Photon.Pun;
using UnityEngine;

public class MultiPlayerRPC : MonoBehaviour
{
  private PhotonView photonView;
  public GrabbedState IsGrabbed;
  private Transform GrabberPosition;
  private RaycastHit2D HitObj;
  private float RaycastXStart;
  private float direction;
  private int grabbedPhotonID;

  // Start is called before the first frame update
  void Start()
  {
    photonView = GetComponent<PhotonView>();
    HitObj = new RaycastHit2D();
    grabbedPhotonID = 0;
  }

  void Update()
  {
    if (photonView.IsMine && PhotonNetwork.IsConnected)
    {
      if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
      {
        if (Input.GetAxis("Horizontal") > 0)
        {
          direction = 1;
        }
        else
        {
          direction = -1;
        }
      }

      if (Input.GetKeyDown(KeyCode.LeftShift))
      {
        Debug.Log(direction);
        RaycastXStart = transform.position.x + direction;
        HitObj = Physics2D.Raycast(new Vector2(RaycastXStart, transform.position.y + .3f), Vector3.forward, .5f);

        if (HitObj.collider != null)
        {
          grabbedPhotonID = HitObj.collider.GetComponent<PhotonView>().ViewID;
          Debug.Log("I have grabbed: " + grabbedPhotonID);
          photonView.RPC("GrabObjectOverNetwork", RpcTarget.All, grabbedPhotonID);
        }
      }

      if (Input.GetKeyUp(KeyCode.LeftShift))
      {
        photonView.RPC("ReleaseObjectOverNetwork", RpcTarget.All, grabbedPhotonID);
      }
    }
  }

  [PunRPC]
  void GrabObjectOverNetwork(int grabbedPhotonID)
  {
    PhotonView grabbed = PhotonView.Find(grabbedPhotonID);
    Debug.Log("I'm the grabbee: " + grabbed.gameObject.name);
    grabbed.GetComponent<MultiPlayerRPC>().grabbedPhotonID = grabbedPhotonID;
    grabbed.GetComponent<MultiPlayerRPC>().IsGrabbed = GrabbedState.Grabbed;
    grabbed.GetComponent<MultiPlayerRPC>().GrabberPosition = photonView.transform;
  }

  [PunRPC]
  void ReleaseObjectOverNetwork(int grabbedPhotonID)
  {
    PhotonView grabbed = PhotonView.Find(grabbedPhotonID);
    grabbed.GetComponent<MultiPlayerRPC>().IsGrabbed = GrabbedState.Free;
  }

  void FixedUpdate()
  {
    PhotonView syncPhoton = PhotonView.Find(grabbedPhotonID);

    if (grabbedPhotonID != 0)
    {
      //if (photonView.IsMine && PhotonNetwork.IsConnected)
      //{
      if (syncPhoton.GetComponent<MultiPlayerRPC>().IsGrabbed.Equals(GrabbedState.Grabbed))
      {
        Transform grabber = syncPhoton.GetComponent<MultiPlayerRPC>().GrabberPosition;
        syncPhoton.transform.position = new Vector2(grabber.position.x, grabber.position.y + 2);

      }
    //}
    }
  }
}

public enum GrabbedState
{
  Free,
  Grabbed
}