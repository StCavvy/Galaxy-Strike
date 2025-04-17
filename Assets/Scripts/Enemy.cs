using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private byte hitPoints = 6;
    [SerializeField] private GameObject destroyVFX;
    [SerializeField] private byte scoreValue = 10;

    ScoreBoard scoreboard;


    private void Start()
    {
        scoreboard = FindFirstObjectByType<ScoreBoard>();
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    //this method provides enemy health and death mechanic via collision with player weapon particles
    private void ProcessHit()
    {
        hitPoints--;
        if (hitPoints <= 0)
        {
            scoreboard.IncreaseScore(scoreValue);
            Instantiate(destroyVFX, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
