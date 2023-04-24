using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;
    [SerializeField] private float _maxSpread;

    private float _currentSpread;

    private void Start()
    {
        _currentSpread = Random.Range(-_maxSpread, _maxSpread);
    }

    private void Update()
    {
        transform.Translate(new Vector3(-1, _currentSpread, 0) * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage(_damage);
            Destroy(gameObject);
        }

        if (collision.gameObject.TryGetComponent(out Destroyer destroyer))
            Destroy(gameObject);
    }
}
