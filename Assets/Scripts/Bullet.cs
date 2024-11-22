using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Bullet Stats")]
    public float bulletSpeed = 20f;  // Kecepatan pergerakan Bullet
    public int damage = 10;          // Damage yang akan diberikan saat Bullet mengenai musuh
    private Rigidbody2D rb;          // Komponen Rigidbody2D untuk menggerakkan Bullet

    void Start()
    {
        // Mendapatkan komponen Rigidbody2D pada Bullet
        rb = GetComponent<Rigidbody2D>();

        // Menambahkan velocity pada Rigidbody2D agar Bullet bergerak
        if (rb != null)
        {
            rb.velocity = transform.up * bulletSpeed;  // Bullet akan bergerak ke arah "up" (ke atas) dengan kecepatan yang telah ditentukan
        }

        // Hancurkan Bullet setelah beberapa detik untuk mencegah Bullet tidak terhapus
        Destroy(gameObject, 5f); // Durasi hidup Bullet adalah 5 detik
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Mengecek apakah Bullet menabrak objek dengan tag "Enemy"
        if (other.CompareTag("Enemy"))
        {
            // Dapatkan komponen Enemy untuk memberikan damage
            var enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);  // Kirimkan damage ke enemy
            }

            // Hancurkan Bullet setelah mengenai musuh
            Destroy(gameObject);
        }
    }
}