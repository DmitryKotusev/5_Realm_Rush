﻿using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    int health = 10;
    [SerializeField]
    int healthDecrease = 1;
    [SerializeField]
    Text healthText;
    [SerializeField]
    AudioClip reachTargetSFX;

    private void Start()
    {
        healthText.text = health.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        health -= healthDecrease;
        healthText.text = health.ToString();
        GetComponent<AudioSource>().PlayOneShot(reachTargetSFX);
    }
}
