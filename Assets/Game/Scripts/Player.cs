using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject _laserPrefab;

    [SerializeField]
    private float _fireRate = 0.25f;
    private float _canFire = 0.0f;

    [SerializeField]
    private float _speed = 5.0f;

    private void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    private void Update()
    {
        movement();
        if(Input.GetKeyDown(KeyCode.Space))

        {
            if (Time.time > _canFire)
            {
                shoot();   
            }
        }
    }

    private void shoot()
    {
        Instantiate(_laserPrefab, transform.position + new Vector3(0, 0.88f, 0), Quaternion.identity);
        _canFire = Time.time + _fireRate;
    }

    private void movement() 
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float VerticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * Time.deltaTime * _speed * horizontalInput);
        transform.Translate(Vector3.up * Time.deltaTime * _speed * VerticalInput);


        if (transform.position.y < -3.9f)
        {
            transform.position = new Vector3(transform.position.x, -3.9f, 0);
        }
        else if (transform.position.y > 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }

        if (transform.position.x > 9.39f)
        {
            transform.position = new Vector3(-9.39f, transform.position.y, 0);
        }
        else if (transform.position.x < -9.39f)
        {
            transform.position = new Vector3(9.39f, transform.position.y, 0);
        }
    }
}
