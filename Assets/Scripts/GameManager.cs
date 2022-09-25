using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] playerPrefab;

    private GameObject player;

    private Vector3 posDefault = new Vector3(40, 0.5f, -80);

    private Quaternion quaternion;

    private int indexPlayer;

    // Start is called before the first frame update
    void Awake()
    {
        SpawnPlayer();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Reload"))
        {
            SpawnPlayer();
        }
    }

    private void SpawnPlayer()
    {
        if (player)
        {
            posDefault = player.gameObject.transform.position;
            quaternion = player.gameObject.transform.rotation;
            Destroy(player.gameObject);
        };

        int number = RandomNumber();

        if (indexPlayer == number)
        {
            SpawnPlayer();
        }
        else
        {
            indexPlayer = number;
            player = Instantiate(playerPrefab[indexPlayer], posDefault, quaternion);
            ParticleSystem particleSystem = this.player.GetComponentInChildren<ParticleSystem>();
            particleSystem.Play();
        }
    }

    private int RandomNumber()
    {
        return Random.Range(0, this.playerPrefab.Length);
    }
}
