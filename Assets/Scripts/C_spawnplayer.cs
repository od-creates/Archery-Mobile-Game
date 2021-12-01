using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class C_spawnplayer : MonoBehaviour
{
    public GameObject myplayer;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 randompos = new Vector3(Random.Range(-1.3f, 1.3f), 0, 0);
        PhotonNetwork.Instantiate(myplayer.name, randompos, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
