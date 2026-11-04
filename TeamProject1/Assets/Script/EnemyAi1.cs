using UnityEngine;

public class EnemyAi1 : MonoBehaviour
{
    public float DectRange = 7f;

    public float Speed = 3.5f;
    public float TeleportTimer = 5f;
    public float TeleportTimerMax = 5f;
    public float TeleportRange = 7f;
    public float TeleportMinRange = 5f;
    public float distance = 0f;

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

        distance = Vector2.Distance(transform.position, player.position);
        TeleportTimer -= Time.deltaTime;

        //start chasing when close
        if (distance < DectRange)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            

            transform.position += (Vector3)direction * Speed * Time.deltaTime;
            if (TeleportTimer < 0 && distance >= TeleportMinRange && distance <= TeleportRange)
            {
                transform.position = player.position + new Vector3(0, 4, 0);
                TeleportTimer = TeleportTimerMax;
            }
        }
    }
}
