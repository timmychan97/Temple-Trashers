﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DropLogic : MonoBehaviour
{
    // Loot to be instantiated
    public GameObject lootPrefab;

    // Extra height to be added when instantiating loot.
    public float spawnHeight = 2f;

    // The drop chance
    public float dropChance = 10f;

    private HealthLogic health;

    void Awake()
    {
        health = GetComponent<HealthLogic>();
        health.onDeath += DropLoot;
    }

    void OnDestroy()
    {
        health.onDeath -= DropLoot;
    }

    private void DropLoot(DamageInfo dmg)
    {
        if (Random.Range(0, 100) < dropChance)
        {
            //... instantiating loot at position of enemy upon death. Need the new vector for the loot to spawn over the map.
            Vector3 spawnPos = transform.position + new Vector3(0, spawnHeight, 0);
            Instantiate(lootPrefab, spawnPos, lootPrefab.transform.rotation);
        }
    }
}
