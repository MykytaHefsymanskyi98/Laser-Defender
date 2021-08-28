using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //conf param
    [Header("Enemy parameters")]
    [SerializeField] float health = 100;
    [SerializeField] GameObject explosionAnimation;
    [SerializeField] AudioClip explosionAudioClip;
    [SerializeField] AudioClip enemyShootingAudioClip;
    [SerializeField] [Range(0, 1)] float explosionVolume = 1f;
    [SerializeField] [Range(0, 1)] float enemyShootingVolume = 1f;
    [SerializeField] int scoreForEnemy = 100;
    [Header("Enemy fire")]
    [SerializeField] float shotCounter;
    [SerializeField] float minTimeBetweenShots = 0.1f;
    [SerializeField] float maxTimeBetweenShots = 2f;
    [SerializeField] GameObject shotPrefab;
    [SerializeField] float bulletSpeed = 10f;


    // references

    GameSession gameSession;

    // Start is called before the first frame update
    void Start()
    {
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        gameSession = FindObjectOfType<GameSession>();
    }

    // Update is called once per frame
    void Update()
    {
        CountDownAndShoot();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Damagedealer damageDealer = other.gameObject.GetComponent<Damagedealer>();
        if(!damageDealer)
        {
            return;
        }
        DestroyEnemy(damageDealer);     
    }

    private void DestroyEnemy(Damagedealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        damageDealer.Hit();
        if (health <= 0)
        {
            ExplosionEnemy();
            PlayEnemyExplosionAudio();
            Destroy(gameObject);
            gameSession.SetScore(scoreForEnemy);
        }
    }
    private void CountDownAndShoot()
    {
        shotCounter -= Time.deltaTime;
        if(shotCounter <= 0)
        {
            Fire();
            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }

    private void Fire()
    {
        GameObject enemyBullet = Instantiate(shotPrefab, transform.position, Quaternion.identity) as GameObject;
        EnemyShootingAudio();
        enemyBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -bulletSpeed);
    }
    private void ExplosionEnemy()
    {
        GameObject explosion = Instantiate(explosionAnimation, transform.position, Quaternion.identity) as GameObject;
        Destroy(explosion, 1f);
    }

    private void PlayEnemyExplosionAudio()
    {
        AudioSource.PlayClipAtPoint(explosionAudioClip, Camera.main.transform.position, explosionVolume);
    }

    private void EnemyShootingAudio()
    {
        AudioSource.PlayClipAtPoint(enemyShootingAudioClip, Camera.main.transform.position, enemyShootingVolume);
    }
}
