using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f; // Player's maximum health
    public float currentHealth;   // Player's current health
    public Image healthBar;        // Reference to the health bar UI Image

    void Start()
    {
        currentHealth = maxHealth;  // Initialize current health to max
        UpdateHealthBar();          // Set the initial health value in the health bar
    }

    void Update()
    {
        // For testing, we reduce health over time or by input
        if (Input.GetKey(KeyCode.Space))  // Decrease health when pressing the spacebar
        {
            TakeDamage(10f * Time.deltaTime);  // Take damage over time while holding space
        }

        // Optionally, handle player healing:
        if (Input.GetKey(KeyCode.H))  // Heal when pressing H
        {
            Heal(5f * Time.deltaTime);  // Heal over time while holding H
        }
    }

    // Method to handle player taking damage
    public void TakeDamage(float amount)
    {
        Debug.Log("Taking Damage...");
        currentHealth -= amount;
        healthBar.fillAmount  = Mathf.Clamp(currentHealth/maxHealth,0,1);
        
        UpdateHealthBar();  // Update the health bar
    }

    // Method to handle player healing
    public void Heal(float amount)
    {
        Debug.Log("Healing...");
        currentHealth += amount;
        healthBar.fillAmount  = Mathf.Clamp(currentHealth/maxHealth,0,1);
      
        UpdateHealthBar();  
    }

    // Update the health bar based on current health
    private void UpdateHealthBar()
    {
        float healthPercentage = currentHealth / maxHealth;  // Calculate health percentage
        healthBar.fillAmount = healthPercentage;  // Set the fill amount of the health bar Image
    }
}