using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject _tripleshotPrefab;

    [SerializeField]
    private GameObject _laserPrefab;

    public bool isSpeedBoostActive = false;
    
    
   

    [SerializeField]
    public bool TripleShoot = false;

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
        if (TripleShoot == true)
        {
            Instantiate(_tripleshotPrefab, transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(_laserPrefab, transform.position + new Vector3(0, 0.88f, 0), Quaternion.identity);
           
        }
        _canFire = Time.time + _fireRate;
    }

    private void movement() 
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float VerticalInput = Input.GetAxis("Vertical");

        if (isSpeedBoostActive == true)
        {
            transform.Translate(Vector3.right * Time.deltaTime * 5.0f * _speed * horizontalInput);
            transform.Translate(Vector3.up * Time.deltaTime * 5.0f * _speed * VerticalInput);
        }
        else
        {
            transform.Translate(Vector3.right * Time.deltaTime * _speed * horizontalInput);
            transform.Translate(Vector3.up * Time.deltaTime * _speed * VerticalInput);
        }

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

    public void SpeedBoostPowerupOn ()
    {
        isSpeedBoostActive = true;
        StartCoroutine(SpeedBoostDownRoutine());
    }

    public void TripleShotPowerupOn()
    {
        TripleShoot = true;
        StartCoroutine(TripleShotPowerDownRoutine());
    }

    public IEnumerator TripleShotPowerDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        TripleShoot = false;
    }

    public IEnumerator SpeedBoostDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        isSpeedBoostActive = false;
    }
}
