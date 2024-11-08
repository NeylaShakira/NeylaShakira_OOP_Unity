using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Pastikan untuk menambahkan ini agar bisa memanggil LoadScene

public class Portal : MonoBehaviour
{
    [SerializeField] private float speed; // Kecepatan portal bergerak
    [SerializeField] private float rotateSpeed; // Kecepatan portal berputar
    private Vector2 newPosition; // Posisi baru yang akan dituju portal

    private void Start()
    {
        ChangePosition(); // Inisialisasi nilai newPosition
    }

    private void Update()
    {
        // Gerakkan portal menuju newPosition
        transform.position = Vector2.MoveTowards(transform.position, newPosition, speed * Time.deltaTime);
        
        // Cek jarak antara posisi portal dan newPosition
        if (Vector2.Distance(transform.position, newPosition) < 0.5f)
        {
            ChangePosition(); // Ganti posisi baru
        }

        // Cek apakah Player memiliki weapon
        if (PlayerHasWeapon()) // Anda perlu membuat metode ini
        {
            gameObject.SetActive(true); // Tampilkan portal
        }
        else
        {
            gameObject.SetActive(false); // Sembunyikan portal
        }

        // Berputar
        transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
    }

    private void ChangePosition()
    {
        // Mengatur posisi baru secara acak dalam batas tertentu
        newPosition = new Vector2(Random.Range(-5f, 5f), Random.Range(-5f, 5f)); // Ubah rentang sesuai kebutuhan
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Jika collider adalah Player
        {
            SceneManager.LoadScene("Main"); // Memuat scene "Main"
        }
    }

    private bool PlayerHasWeapon()
    {
        // Implementasikan logika untuk memeriksa apakah Player memiliki weapon
        // Kembalikan true jika Player memiliki weapon, false jika tidak
        return true; // Ganti dengan logika yang sesuai
    }
}