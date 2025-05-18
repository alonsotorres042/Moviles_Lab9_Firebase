using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Scriptable Objects/PlayerData")]
public class PlayerData : ScriptableObject
{
    public string Name;
    public string LastName;

    public int lastScore;
    public List<int> highScores;

    public void SetUp()
    {
        highScores = new List<int>();
    }
    public void UpdateData(string name, string lastName)
    {
        Name = name;
        LastName = lastName;
    }
    public void ResetData()
    {
        Name = "";
        LastName = "";
        lastScore = 0;
        highScores = new List<int>();
    }
}