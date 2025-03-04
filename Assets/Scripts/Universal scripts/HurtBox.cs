﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HurtBox : MonoBehaviour
{
    [SerializeField]
    private string[] tagsToDamage;

    [SerializeField]
    private int damage;

    void OnTriggerEnter(Collider other)
    {
        foreach (string tagToDamage in tagsToDamage)
        {
            if (!other.CompareTag(tagToDamage))
                continue;

            other.GetComponent<HealthLogic>().OnReceiveDamage(damage);
        }
    }
}
