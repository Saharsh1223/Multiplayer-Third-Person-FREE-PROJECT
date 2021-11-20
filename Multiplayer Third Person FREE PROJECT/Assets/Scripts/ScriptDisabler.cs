using UnityEngine;
using Photon.Pun;

public class ScriptDisabler : MonoBehaviour
{
    [SerializeField] PhotonView photonView;
    [Space]
    [SerializeField] MonoBehaviour[] scripts;

    void Update()
    {
        if (!photonView.IsMine)
        {
            //loop to disable all the scripts
            for (int i = 0; i < scripts.Length; i++)
            {
                scripts[i].enabled = false;
            }
        }
    }
}
