using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyPlayer : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public int maxStars = 100;
    public int currentStars;

    public HealthBarScript healthBar;
    public StarBar starbar;

    public PauseScreen pause;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        currentStars = 0;
        starbar.SetMaxStars(maxStars);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
            GetStar(20);
        }
        if (currentHealth == 0)
        {
            currentHealth -= 1;
            Debug.Log("You died.");
            PlayerDeath();
        }
    }
    
    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    void GetStar(int star)
    {
        currentStars += star;
        starbar.SetStar(currentStars);
    }

    void PlayerDeath()
    {
        pause.DeathPause();
    }
}
