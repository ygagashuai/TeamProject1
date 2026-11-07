 using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class DashEnemyAi : MonoBehaviour
{
    public float DectRange = 5f;

    public float Speed = 3f;
    public float dashTimer = 2f;
    public float dashTimerMax = 2f;
    public float dashDis = 15f;
    public float dashDetectionDistance = 3f;
    public float dashDuration = 0.5f;
    public Rigidbody2D enemyRB;
    private Transform player;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //find player
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        //player position
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

        float distance = Vector2.Distance(transform.position, player.position);
        dashTimer -= Time.deltaTime;
        //start chasing when close
        if (distance < DectRange)
        {
            Vector2 direction = (player.position - transform.position).normalized;

            transform.position += (Vector3)direction * Speed * Time.deltaTime;
            if (dashTimer < 0 && dashDuration >= 0 && distance >= dashDetectionDistance)
            {

                    if (enemyRB.linearVelocityX >= 0)
                    {
                        enemyRB.linearVelocity = new Vector2(dashDis, 0);//dash right when no moving or move to right
                    }
                    else if (enemyRB.linearVelocityX < 0)
                    {
                       enemyRB.linearVelocity = new Vector2(-dashDis, 0);//dash left
                    }
                dashDuration -= Time.deltaTime;
            }
            if (dashDuration == 0)
            {
                enemyRB.linearVelocity = Vector2.zero;
                dashTimer = dashTimerMax;
                dashDuration = 0.5f;
            }
        }
    }
}
