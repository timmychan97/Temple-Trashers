﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AxeTowerAnimationController : MonoBehaviour, TurretInterface
{
    public MeshRenderer handAxe;
    public MeshRenderer totemAxe;
    public Transform spawnPoint;
    public GameObject axeProjectilePrefab;
    public float projectileSpeed = 5f;
    public Transform forwardTransform;

    [SerializeField]
    private AudioSource throws;
    [SerializeField]
    private AudioSource hits;

    public void Hit()
    {
        hits.Play();
    }
    public void Grab()
    {
        handAxe.enabled = true;
        totemAxe.enabled = false;
    }

    public void Shoot()
    {
        handAxe.enabled = false;
        Rigidbody projectileBody = Instantiate(axeProjectilePrefab, spawnPoint.position, spawnPoint.rotation, transform)
            .GetComponent<Rigidbody>();
        projectileBody.velocity = forwardTransform.right * projectileSpeed;
        throws.Play();
    }

    public void Spawn()
    {
        totemAxe.enabled = true;
    }
}
