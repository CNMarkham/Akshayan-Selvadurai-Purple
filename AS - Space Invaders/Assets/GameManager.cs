using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject enemyPrefab;

    public float xSpace;
    public float xOffset;
    // Update is called once per frame
    void Start()
    {

        for (int x = 0; x < 10; x++)
        {
            Instantiate(enemyPrefab, new Vector2(x * xSpace + xOffset, 3), Quaternion.identity);
            Instantiate(enemyPrefab, new Vector2(x * xSpace + xOffset, 4.5f), Quaternion.identity);
            Instantiate(enemyPrefab, new Vector2(x * xSpace + xOffset, 6f), Quaternion.identity);
        }
    }
}
