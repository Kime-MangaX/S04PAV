using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;

    public float distance;

    void Start()
    {

    }

    void Update()
    {
        distance = Vector2.Distance(player.transform.position, enemy.transform.position);
    }
}