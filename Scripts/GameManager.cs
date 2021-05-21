using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject foodPrefab;
    public GameObject playerObject;
    private PlayerMovement playerScript;
    public TextMeshProUGUI scoreText;

    public int score;
    private Vector2 spawnPos;

    private float randomX = 8;
    private float randomY = 4;
    private float invokeStart = 2;
    public float invokeRepeat = 2;
    public int startingFood = 20;

    // Start is called before the first frame update
    void Start()
    {
        // Get the player script
        playerScript = playerObject.GetComponent<PlayerMovement>();

        score = 0;
        scoreText.text = "Food Eaten: " + score;

        InvokeRepeating("InstantiateFood", invokeStart, invokeRepeat);

        // Instantiate 20 food at the start of the game.
        for (int i = 0; i < startingFood; i++)
        {
            InstantiateFood();
        }
    }

    private void Update()
    {
        // Update score text;
        score = playerScript.foodEaten;
        scoreText.text = "Food Eaten: " + score;
    }


    private void InstantiateFood()
    {
        // Instantiate food at a random position.
        spawnPos = new Vector2(Random.Range(-randomX, randomX), Random.Range(-randomY, randomY));
        Instantiate(foodPrefab, spawnPos, Quaternion.identity);
    }
}
