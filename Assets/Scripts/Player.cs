using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // coinf param
    [SerializeField] float playerHealth = 100f;
    [SerializeField] GameObject playerLooseVFX;
    [Header("Player movement")]
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float padding = 0f;
    [Header("Player fire")] 
    [SerializeField] GameObject bulletPlayer;
    [SerializeField] float projectileVelocity = 1f;
    [SerializeField] float projectileFiringRate = 0.1f;
    [Header("Player Audio")]
    [SerializeField] AudioClip palyerShootingAudioClip;
    [SerializeField] AudioClip playerLooseAudioClip;
    [SerializeField] [Range(0, 1)] float playerShotVolume = 1f;
    [SerializeField] [Range(0, 1)] float playerLooseVolume = 1f;
    

    Coroutine firingCoroutine;

    // states
    float xMin;
    float xMax;
    float yMin;
    float yMax;
    float xDelta = -5f;
    float yDelta = -5f;
    float playerHealthPlus = 1f;

    // references
    Sceneloader level;
   
    

    // Start is called before the first frame update
    void Start()
    {
        SetUpMoveBoudaries();
        level = FindObjectOfType<Sceneloader>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Fire();
       
    }

    private void SetUpMoveBoudaries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }
    private void Move()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        var newPosX = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        var newPosY = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);
        transform.position = new Vector2(newPosX, newPosY);
        
    }

    private void Fire()
    {      
            if (Input.GetButtonDown("Fire1"))
            {
               firingCoroutine = StartCoroutine(FireCoroutine());
            }

            if (Input.GetButtonUp("Fire1"))
            {
            StopCoroutine(firingCoroutine);
            }          
    }

    IEnumerator FireCoroutine()
    {
        while (true)
        { 
            GameObject bullet = Instantiate(bulletPlayer, transform.position, Quaternion.identity) as GameObject;
            PlayPlayerFireAudio();
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileVelocity);
            yield return new WaitForSeconds(projectileFiringRate);
    
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Bonus Health")
        {
            playerHealth += playerHealthPlus;
            Destroy(other.gameObject);
        }
        else
        {
            Damagedealer damageDealer = other.GetComponent<Damagedealer>();
            if (!damageDealer)
            {
                return;
            }
            playerHealth -= damageDealer.GetDamage();
            damageDealer.Hit();
            if (playerHealth <= 0)
            {
                PlayPlayerLooseAudio();
                PlayerDestroyed();
                Destroy(gameObject);
                level.LoadLastScene();
            }
        }
    }

    private void PlayPlayerFireAudio()
    {
        AudioSource.PlayClipAtPoint(palyerShootingAudioClip, Camera.main.transform.position, playerShotVolume);
    }

    private void PlayPlayerLooseAudio()
    {
        AudioSource.PlayClipAtPoint(playerLooseAudioClip, Camera.main.transform.position, playerLooseVolume);
    }

    public float GetPlayerHealth()
    {
        return playerHealth;
    }
  
   void PlayerDestroyed()
    {
        Instantiate(playerLooseVFX, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject, 1f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Asteroid")
        {
            Damagedealer damageDealerAsteroid = collision.collider.GetComponent<Damagedealer>();
            if (!damageDealerAsteroid)
            {
                return;
            }
            playerHealth -= damageDealerAsteroid.GetDamage();
            damageDealerAsteroid.Hit();
            if (playerHealth <= 0)
            {
                PlayPlayerLooseAudio();
                PlayerDestroyed();
                Destroy(gameObject);
                level.LoadLastScene();
            }
        }
    }
}
