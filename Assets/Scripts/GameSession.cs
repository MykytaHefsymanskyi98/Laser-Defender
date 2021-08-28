using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameSession : MonoBehaviour
{
    // conf param
    [SerializeField] int score = 0;

    public void SetScore( int scoreBonus)
    {
        score += scoreBonus;
      
    }

    private void Awake()
    {
        int scoreCounter = FindObjectsOfType(GetType()).Length;
        if (scoreCounter > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }

        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void DestroyScore()
    {
        Destroy(gameObject);
    }
    public int GetScore()
    {
        return score;
    }
}

    

