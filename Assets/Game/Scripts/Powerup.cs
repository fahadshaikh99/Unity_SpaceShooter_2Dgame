using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField]
    private int powerupID; // 0 = tripleShot, 1 = SpeedUp, 2 = sheilds
    [SerializeField]
    private float _speed = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * _speed);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collided with :" + other.name);
        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                if (powerupID == 0)
                {
                    player.TripleShotPowerupOn();
                }

                else if(powerupID == 1)
                {
                    player.SpeedBoostPowerupOn();
                }
                else if(powerupID == 2)
                {
                    //enable power sheild
                }
            }

            Destroy(this.gameObject);

        }
    }
}
