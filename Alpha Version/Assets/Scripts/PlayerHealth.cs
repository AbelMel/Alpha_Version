using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth singleton;
    public float currentHealth;
    public float maxHealth = 100f;
    public Slider healthSlider;
    public Text healthCounter;
    public bool isDead = false;
    // Start is called before the first frame update

    private void Awake()
    {
        singleton = this;
    }

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthCounter();
    }

    public void PlayerDamage(float damage)
    {
        if(currentHealth > 0)
        {
        if(damage >= currentHealth)
        {
            Dead();
        }

        else
        {
            currentHealth -= damage;
            healthSlider.value -= damage;
           }

        UpdateHealthCounter();
        }
    }

    // Update is called once per frame
    public void Dead()
    {
        currentHealth = 0;
        isDead = true;
        healthSlider.value = 0;
        UpdateHealthCounter();
        Debug.Log("You are Dead!");
    }

    void UpdateHealthCounter(){
        healthCounter.text = currentHealth.ToString();
    }
}
