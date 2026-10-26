using UnityEngine;
using System.Collections.Generic;

public class Bullet : MonoBehaviour
{
    private const int POOl_SIZE = 10;

    [SerializeField] GameObject _BulletPrefab;

    private Queue<GameObject> _Bullets;

    void Start()
    {
        _Bullets = new();

        for (int i = 0; i < POOl_SIZE; i++)
        {
            GameObject _Bullet = Instantiate(_BulletPrefab, Vector3.zero, Quaternion.identity, this.transform);
            _Bullet.SetActive(false);
            _Bullets.Enqueue(_Bullet);
        }
    }

    private GameObject GetBulletFromPool()
    {
        if(_Bullets.Count > 0)
        {
            GameObject _Bullet = _Bullets.Dequeue();
            _Bullet.SetActive(true);
            return _Bullet;
        }
        return null;
    }

    private void ReturnBulletToPool(GameObject _Bullet)
    {
        _Bullet.SetActive(false);
        _Bullets.Enqueue(_Bullet);
    }

    // private IEnumerator DisableBulletAfterDelay(GameObject _bullet, float delay)
    // {
    //     yield return new WaitForSeconds(delay);
    //     ReturnBulletToPool(_bullet);
    // }

    void Update()
    {
        
    }


}
