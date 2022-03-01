﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerSpecificManager : MonoBehaviour
{
    private static int playerCount = 0;
    private int playerIndex;
    private PlayerInput input;

    [SerializeField]
    private GameObject[] playerPrefabs;

    private PlayerStateController instantiatedPlayer;
    public Vector3 spawnPoint;

    void Awake()
    {
        playerIndex = playerCount++;
        input = GetComponent<PlayerInput>();
    }

    void Start()
    {
        spawnPoint = BaseController.Singleton ? BaseController.Singleton.SpawnPoint.position : Vector3.zero;
        InitializePlayer();
    }

    public void InitializePlayer()
    {
        // Spawn at a random position around the base
        spawnPoint += new Vector3(Random.Range(-10, 10), 1, Random.Range(-10, 10));

        GameObject playerToSpawn = playerPrefabs[playerIndex % playerPrefabs.Length];
        instantiatedPlayer = Instantiate(playerToSpawn, spawnPoint, playerToSpawn.transform.rotation).GetComponent<PlayerStateController>();
        instantiatedPlayer.SetUpInput(input, this);
        CameraFocusController.Singleton.AddFocusObject(instantiatedPlayer.transform);
    }

    public void RespawnPlayer(float delay)
    {
        StartCoroutine(WaitForRespawn(delay));
    }

    private IEnumerator WaitForRespawn(float delay)
    {
        yield return new WaitForSeconds(delay);
        InitializePlayer();
    }
}
