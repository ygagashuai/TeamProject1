using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    public float DectRange = 5f;

    public float Speed = 3f;

    private Transform player;


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

        float distance = Vector2.Distance(transform.position, player.position);
        //start chasing when close
        if (distance < DectRange)
        {
            Vector2 direction = (player.position - transform.position).normalized;

            transform.position += (Vector3)direction * Speed * Time.deltaTime;
        }
    }
}
