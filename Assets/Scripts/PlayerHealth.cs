using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] Sprite healthSpriteGreen;
    [SerializeField] Sprite healthSpriteOrange;
    [SerializeField] Sprite healthSpriteRed;
    [SerializeField] GameObject healthImage;

    Text playerHealthText;
    Player player;

    // Start is called before the first frame update
    void Start()
    {
        playerHealthText = GetComponent<Text>();
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        CurrentHealth();
    }
   
    void CurrentHealth()
    {
        //playerHealthText.text = player.GetPlayerHealth().ToString();
        CurrentHealthImage();
    }

    void CurrentHealthImage()
    {
        if(player.GetPlayerHealth() > 2)
        {
            healthImage.GetComponent<Image>().sprite = healthSpriteGreen;
        }
        else if(player.GetPlayerHealth() == 2)
        {
            healthImage.GetComponent<Image>().sprite = healthSpriteOrange;
        }
        else if (player.GetPlayerHealth() == 1)
        {
            healthImage.GetComponent<Image>().sprite = healthSpriteRed;
        }
    }

}
