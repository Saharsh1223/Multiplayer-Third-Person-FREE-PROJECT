using UnityEngine;
using Photon.Pun;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject playerPrefab;

    void Start()
    {
        GameObject player = PhotonNetwork.Instantiate(playerPrefab.name, new Vector3(Random.Range(-5f, 5f), Random.Range(5f, 10f), Random.Range(-5f, 5f)), Quaternion.identity);
    }
}
