using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject SpawnPoint;
    public PlayerController pc;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Respawn()
    {
        player.transform.position = SpawnPoint.transform.position;
    }
}
