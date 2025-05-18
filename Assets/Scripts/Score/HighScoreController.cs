using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class HighScoreController : MonoBehaviour
{
    public PlayerData playerData;

    public TextMeshProUGUI[] scoreTexts = new TextMeshProUGUI[] { };

    void Start()
    {
        //SortScores();       // Ordena los puntajes
        //UpdateScoreUI();    // Muestra los puntajes en pantalla
    }

    // Agrega un nuevo puntaje y actualiza la lista
    public void AddScore(PlayerData playerData)
    {
        playerData.highScores.Add(playerData.lastScore); // Añade el nuevo puntaje
        SortScores();                        // Ordena la lista de mayor a menor
        TrimScores();                        // Elimina cualquier puntaje por encima del 5º
        //UpdateScoreUI();                     // Actualiza la UI con los nuevos puntajes
    }

    // Ordena la lista de puntajes de mayor a menor
    private void SortScores()
    {
        playerData.highScores.Sort((a, b) => b.CompareTo(a));
    }

    // Mantiene solo los 5 puntajes más altos en la lista
    private void TrimScores()
    {
        if (playerData.highScores.Count > 5)
        {
            // Elimina desde el índice 5 en adelante (es decir, el 6º puntaje y siguientes)
            playerData.highScores.RemoveRange(5, playerData.highScores.Count - 5);
        }
    }

    // Actualiza la interfaz gráfica para mostrar los puntajes en pantalla
    public void UpdateScoreUI()
    {
        for (int i = 0; i < scoreTexts.Length; i++)
        {
            if (i < playerData.highScores.Count)
            {
                scoreTexts[i].text = $"{i + 1}. {playerData.highScores[i]}"; // Muestra puntaje existente
            }
            else
            {
                scoreTexts[i].text = $"{i + 1}. ---"; // Espacio vacío si no hay puntaje
            }
        }
    }
    public void SwitchActive(GameObject victim)
    {
        victim.SetActive(victim.activeSelf ? false : true);
    }
}