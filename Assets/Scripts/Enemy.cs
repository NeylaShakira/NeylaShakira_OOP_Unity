using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;  // Health Enemy

    // Fungsi untuk menerima damage
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    // Fungsi untuk menghancurkan Enemy ketika health habis
    private void Die()
    {
        Destroy(gameObject);
    }
}