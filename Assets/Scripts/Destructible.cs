using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    public float health = 100f;
    public int pointsValue = 10;

    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            if (GameManager.Instance != null)
            {
                GameManager.Instance.AddPoints(pointsValue);
            }

            Level1Manager level1Manager = FindObjectOfType<Level1Manager>();
            if (level1Manager != null)
            {
                level1Manager.AddDestroyedObstacle();
            }

            Level2Manager level2Manager = FindObjectOfType<Level2Manager>();
            if (level2Manager != null)
            {
                level2Manager.AddDestroyedObject();
            }

            Destroy(gameObject);
        }
    }
}