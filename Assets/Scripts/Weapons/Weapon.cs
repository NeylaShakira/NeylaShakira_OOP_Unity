using UnityEngine;
using UnityEngine.Pool;

public class Weapon : MonoBehaviour
{
    [Header("Weapon Stats")]
    [SerializeField] private float shootIntervalInSeconds = 3f;

    [Header("Bullets")]
    public Bullet bullet;
    [SerializeField] private Transform bulletSpawnPoint;

    [Header("Bullet Pool")]
    private IObjectPool<Bullet> objectPool;

    private float timer;

    private void Awake()
    {
        objectPool = new ObjectPool<Bullet>(CreateBullet, OnGetBullet, OnReleaseBullet, OnDestroyBullet, collectionCheck: false, defaultCapacity: 30, maxSize: 100);
    }

private Bullet CreateBullet()
{
    var newBullet = Instantiate(bullet, bulletSpawnPoint.position, bulletSpawnPoint.rotation, null);
    newBullet.gameObject.SetActive(false);
    return newBullet;
}

private void OnGetBullet(Bullet bullet)
{
    bullet.transform.position = bulletSpawnPoint.position;
    bullet.transform.rotation = bulletSpawnPoint.rotation;
    bullet.gameObject.SetActive(true);
}


    private void OnReleaseBullet(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
    }

    private void OnDestroyBullet(Bullet bullet)
    {
        Destroy(bullet.gameObject);
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= shootIntervalInSeconds)
        {
            Shoot();
            timer = 0;
        }
    }

    private void Shoot()
    {
        var bullet = objectPool.Get();
    }

    public void ReturnBulletToPool(Bullet bullet)
    {
        objectPool.Release(bullet);
    }
}