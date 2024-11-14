using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float rotateSpeed;
    private Vector2 newPosition;

    private void Start()
    {
        ChangePosition();
    }

    private void Update()
    {
        if (Player.Instance != null)
        {
            bool hasWeapon = Player.Instance.thisweapon != null;
            GetComponent<Collider2D>().enabled = hasWeapon;
            GetComponent<SpriteRenderer>().enabled = hasWeapon;
        }

        transform.position = Vector2.MoveTowards(transform.position, newPosition, speed * Time.deltaTime);
        transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, newPosition) < 0.5f)
        {
            ChangePosition();
        }
    }

    private void ChangePosition()
    {
        float posisirandom_X = Random.Range(-4, 4);
        float posisirandom_Y = Random.Range(-2, 2);
        newPosition = new Vector2(posisirandom_X, posisirandom_Y);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Player player = other.GetComponent<Player>();

        if (other.CompareTag("Player") && player != null && player.thisweapon != null)
        {
            Debug.Log("Portal: Player enter portal succesfully!");
            GameManager.Instance.LevelManager.LoadScene("Main");
        }
        else
        {
            Debug.Log("Portal: Player haven't got weapon!");
        }
    }
}