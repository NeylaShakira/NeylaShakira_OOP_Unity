using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    [SerializeField] private Weapon weaponHolder; // Referensi senjata yang akan dipasangkan
    private Weapon weapon; // Senjata yang akan diambil

    private void Awake()
    {
        weapon = weaponHolder; // Menginisialisasi weapon dengan weaponHolder
    }

    private void Start()
    {
        if (weapon != null)
        {
            TurnVisual(false); // Menonaktifkan visual senjata pada awal
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Mengambil komponen Weapon dari Player
            Weapon bebas = other.GetComponentInChildren<Weapon>();

            if (bebas != null)
            {
                // Set weapon as child of player
                weapon.transform.parent = other.transform; 
                TurnVisual(false, bebas); // Memanggil TurnVisual dengan weapon baru
            }
        }
    }

    private void TurnVisual(bool on)
    {
        gameObject.SetActive(on); // Mengubah status aktif objek visual
    }

    private void TurnVisual(bool on, Weapon newWeapon)
    {
        weapon = newWeapon; // Mengatur senjata baru
        gameObject.SetActive(on); // Mengubah tampilan visual
    }
}