using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   
    [SerializeField] private GameObject _BulletPrefab;
    [SerializeField] private Transform _BulletSpawn;
    [SerializeField] private GameObject _EnemyPrefab;
    [SerializeField] private Transform _EnemySpawn;
    [SerializeField] private float _speed;
    private Vector3 _direction;
    private bool _isFire;
    private bool _isSprint;


    private void Awake()
    {
        _direction = Vector3.zero;
        _isFire = false;
    }
    void Start()
    {
        GameObject bullet = Instantiate(_BulletPrefab, _BulletSpawn.position, Quaternion.identity);
        Destroy(bullet,3f);
        GameObject enemy = Instantiate(_EnemyPrefab, _EnemySpawn.position, Quaternion.identity);
    }

    void Update()
    {
        _direction.x = Input.GetAxis("Horizontal");
        _direction.z = Input.GetAxis("Vertical");
        _isFire = Input.GetMouseButtonDown(0);
        _isSprint = Input.GetButton("Sprint");
    }
    void FixedUpdate()
    {
        float sprint = (_isSprint) ? 2f : 1f;
        transform.Translate(_direction.normalized * _speed * sprint * Time.fixedDeltaTime);
        if (_isFire)
            Fire();
    }
    private void Fire()
    {
        _isFire = false;
        GameObject bullet = Instantiate(_BulletPrefab, _BulletSpawn.position, Quaternion.identity);
        Destroy(bullet, 5f);
    }
}
