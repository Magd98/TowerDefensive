using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class BaseHealth : MonoBehaviour
{
    [SerializeField] int health = 10;
    [SerializeField] int healthDecrease = 1;
    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] AudioClip playerDamageSFX;
     
    void Start()
    {
        healthText.text=health.ToString();
    }
    private void OnTriggerEnter(Collider other)
    {
        GetComponent<AudioSource>().PlayOneShot(playerDamageSFX);
        health -= healthDecrease;
        healthText.text = health.ToString();

    }
}
