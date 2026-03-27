using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // No olvides añadir este using para TextMeshPro

public class GameManager : MonoBehaviour
{

    public static GameManager Instance; // Singleton

    public TextMeshProUGUI pointsText; // Referencia al texto de puntos
    private int totalPoints = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddPoints(int points)
    {
        totalPoints += points;
        UpdatePointsText();
    }

    private void UpdatePointsText()
    {
        pointsText.text = "Puntuación: " + totalPoints;
    }
}