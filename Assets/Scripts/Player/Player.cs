using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private Animator animator;

    void Start()
    {
        // Mengambil komponen PlayerMovement dan Animator
        playerMovement = GetComponent<PlayerMovement>();

        // Pastikan GameObject "EngineEffect" memiliki komponen Animator
        animator = GameObject.Find("EngineEffect")?.GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        // Memanggil fungsi Move untuk menggerakkan pemain
        playerMovement.Move();
    }

    void LateUpdate()
    {
        // Mengatur parameter animasi berdasarkan status pergerakan
        if (animator != null)
        {
            animator.SetBool("IsMoving", playerMovement.IsMoving());
        }
    }
}