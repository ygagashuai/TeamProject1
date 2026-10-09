using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private Rigidbody2D rb;

    public float dirx = 0f;
    public float speed = 5f;//speed for player

    public float knockbackForce = 8f;
    public bool knockedBack = false;

    public float jumpH = 5f;//jump high
    bool jump;
    public float DoubleJump = 2f;//double jump 

    public float DashDis = 15f;//dash distances
    public float CoolDownDash = 3f;// cool down for dash
    bool dashing = false;

    [SerializeField] private Text HealthText;//show health
    public float Health = 5f;
    public Image HealthBar;
    private float MaxHealth, CureentHealth;

    [SerializeField] private Text DashText;// show dash

    public float Dash = 0f;

    public float ShootAbility = 0f;//

    [SerializeField] private Text AbilityText;// show shoot ability

    public float ShootTime = 0f;//shoot time 

    public float StartCount = 0f;

    public GameObject BulletPrefab;// prefab for bullet

    public Transform FirePoint;// where bullet shoot

    public float BulletSpeed = 10f;//bullet speed




    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jump = true;

        MaxHealth = 100f;
        CureentHealth = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        //all show the text on hud
        HealthText.text = "Health : " + MaxHealth;

        DashText.text = "Dash : " + Dash;

        AbilityText.text = "Shoot Ability :" + ShootAbility;

        // player movement in horizontral
        dirx = Input.GetAxisRaw("Horizontal");
        if (!dashing && !knockedBack)//player move when not dash and knockbak
        {
            rb.linearVelocity = new Vector2(dirx * speed, rb.linearVelocity.y);
        }

        //jump and double jump
        if (Input.GetButtonDown("Jump") && jump == true && DoubleJump >= 0)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpH);

            DoubleJump -= 1;

            if (DoubleJump == 0)//after two jum, jump become false
            {
                jump = false;

            }
            
        }

        CoolDownDash += Time.deltaTime;
        if(CoolDownDash >= 3)//dash cool down
        {
            Dash = 1;
        }

        if (Input.GetKeyDown(KeyCode.K) && CoolDownDash >= 3)//press k to dash when cool down > 3
        {
            dashing = true;

            if (dirx >= 0)
            {
                rb.linearVelocity = new Vector2(DashDis, 0);//dash right when no moving or move to right
            }
            else if (dirx < 0)
            {
                rb.linearVelocity = new Vector2(-DashDis, 0);//dash left
            }

            CoolDownDash = 0;

            Dash = 0;

            Invoke("StopDash", 0.2f);
        }

        if (Input.GetKeyDown(KeyCode.J) && ShootAbility >= 1)// press j to shoot when player have shoot Ability 
        {

            Shoot();

            StartCount = 1f;

        }
        if (StartCount == 1)// start count , when player shoot after 5 second stop shooting 
        {
            ShootTime += Time.deltaTime;
            if (ShootTime >= 5)
            {
                StartCount = 0;

                ShootAbility -= 1f;

                ShootTime = 0;

            }
        }
        //load losescenes when the health equal 0
        if(MaxHealth == 0 | CureentHealth == 0)
        {
            SceneManager.LoadScene("LoseScenes");
        }


    }
    void StopDash()//stop dash
    {
        dashing = false;
    }
    public void Knockback(float direction)// applies knockback to the player when hit
    {
        knockedBack = true;

        rb.linearVelocity = new Vector2(direction * knockbackForce,rb.linearVelocity.y);// applies horizontal velocity to push the player

        Invoke(nameof(EndKnockback), 0.2f);//end in 0.2 second
    }

    void EndKnockback()// no knockback
    {
        knockedBack = false;
    }
    void Shoot()// shooting 
    {
        GameObject bullet = Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);// sapwen the bulletb in this position 

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        rb.linearVelocity = FirePoint.right * BulletSpeed;//move bullet
        
    }
    void ChangeHealth(float delat)//change the health
    {
        CureentHealth = Mathf.Clamp(CureentHealth + delat, 0, MaxHealth);

        HealthBar.fillAmount = CureentHealth/MaxHealth;
    }
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" && DoubleJump >= 0) //player only can jump after touch ground
        {

            jump = true;

            DoubleJump = 2;
        }
        //Decrease health when hit by the enemy
        if (collision.gameObject.CompareTag("Enemy"))
        {
            ContactPoint2D contact = collision.GetContact(0);


            if (contact.normal.y > 0.5f && rb.linearVelocity.y <= 0)
            {
                // Destroy the enemy
                Destroy(collision.gameObject);
            }
            else//if not kill the enemy then decrease health
            {
                ChangeHealth(-20);

                MaxHealth -= 20f;
            }

        }
        if (collision.gameObject.CompareTag("Ball"))//decrease the health when player hit by the enemy ball
        {
            ChangeHealth(-20);

            MaxHealth -= 20f;
        }
        //load end scenes when touch end point
        if (collision.gameObject.CompareTag("End Point"))
        {

            SceneManager.LoadScene("EndScenes");

        }
        // get shoot ability when touch shootability item and show on the hud
        if (collision.gameObject.CompareTag("ShootAbility"))
        {
            Destroy(collision.gameObject);

            ShootAbility += 1;

            AbilityText.text = "Shoot Ability :" + ShootAbility;

        }


    }


}
