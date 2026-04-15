using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject player;
    public int enemyRango;
    public float generatecFrec;

    float currentTime;
    void Start()
    {

    }

    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= generatecFrec)
        {
            GenerateEnemy();
            currentTime = 0;
        }
    }

    public void GenerateEnemy()
    {
        float X = Random.Range(-1f, 1f);
        float Y = Random.Range(-1f, 1f);
        Vector2 enemypost = new Vector2(X, Y);
        enemypost = enemypost.normalized;
        Vector2 playerPost = player.transform.position;
        GameObject Enemy = Instantiate(enemyPrefab);
        Enemy.transform.position = (enemypost * enemyRango) + playerPost;
        print(playerPost);
        print(enemypost);
    }
}