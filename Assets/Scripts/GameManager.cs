using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    [SerializeField]
    private int health = 20;

    [SerializeField]
    private int collectedCoins = 0;


    public int GetHealth() => health;
    public void DecreaseHealth(int decreaseBy) => health -= decreaseBy;
    public void IncreaseHealth(int increaseBy) => health += increaseBy;


    public int GetCollectedCoins() => collectedCoins;
    public void DecreaseCollectedCoins(int decreaseBy) => collectedCoins -= decreaseBy;
    public void IncreaseCollectedCoins(int increaseBy) => collectedCoins += increaseBy;




    void Start()
    {
        if (instance != null) {
            return ;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        // Debug.Log("Collected coins: " + collectedCoins);
        // Debug.Log("Current health: " + health);
    }
}
