using UnityEngine;
using Photon.Pun;
using UnityStandardAssets.Cameras;

public class Player : MonoBehaviour
{
    [SerializeField] PhotonView photonView;
    [SerializeField] FreeLookCam freeLookCam;

    void Awake()
    {
        if (photonView.IsMine)
        {
            freeLookCam = FindObjectOfType<FreeLookCam>();
        }
    }

    void Start()
    {
        if (photonView.IsMine)
        {
            freeLookCam.SetTarget(gameObject.transform);
        }
    }

    void Update()
    {
        if (!photonView.IsMine)
        {
            gameObject.tag = "OtherPlayer";
        }
    }
}
