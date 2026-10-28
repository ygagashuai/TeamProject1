using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    public float DectRange = 5f;

    public float Speed = 3f;
    public float TeleportTimer = 3f;
    public float TeleportTimerMax = 3f;
    public float TeleportRange = 7f;

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
        TeleportTimer -= Time.deltaTime;

        //start chasing when close
        if (distance < DectRange)
        {
            Vector2 direction = (player.position - transform.position).normalized;

            transform.position += (Vector3)direction * Speed * Time.deltaTime;
            if (TeleportTimer < 0)
            {
                transform.position = player.position + new Vector3(0, 4, 0);
                TeleportTimer = TeleportTimerMax;
            }
        }
    }
}
