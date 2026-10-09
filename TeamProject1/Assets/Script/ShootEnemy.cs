using UnityEngine;

public class ShootEnemy : MonoBehaviour
{
    public float DectRange = 5f;

    private Transform player;

    public GameObject BulletPrefab;// prefab for bullet

    public Transform FirePoint;// where bullet shoot
    public Transform FirePointLeft;


    public float BulletSpeed = 10f;//bullet speed

    public float ShootCooldown = 2f;
    private float shootTimer = 0f;

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //find player
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        //player positipon
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
            return;

        shootTimer -= Time.deltaTime;

        float distance = Vector2.Distance(transform.position, player.position);//player position

        if (distance < DectRange && shootTimer <= 0f)//if the player close to the shootenemy it start shoot
        {
            Shoot();

            shootTimer = ShootCooldown;
        }
        void Shoot()// shooting 
        {
            Transform firePoint;

            //shoot when player in right
            if (player.position.x > transform.position.x)
            {
                firePoint = FirePoint;
            }
            //shoot when player in left
            else
            {
                firePoint = FirePointLeft;
            }

            GameObject bullet = Instantiate( BulletPrefab,firePoint.position,firePoint.rotation);// sapwen the bulletb in this position

            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

            rb.linearVelocity = firePoint.right * BulletSpeed;//move bullet
        }

    
    }
}
