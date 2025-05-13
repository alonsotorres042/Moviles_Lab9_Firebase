using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Character Data", menuName = "Scriptable Objects/Character/Character Data")]
public class CharacterSO : ScriptableObject
{
    public string CharacterStringName;
    [Header("Character Seleciton")]
    public Sprite CharacterSprite;
    public Sprite CharacterName;
    public Sprite CharacterLogo;
    [Header("Super Arts")]
    public SuperArt CharacterArt1;
    public SuperArt CharacterArt2;
    public SuperArt CharacterArt3;
    [Header("Rival Seleciton")]
    public Sprite CharacterRivalLogo;
    public Sprite CharacterFlag;
    public Sprite CharacterCountry;
    public Sprite CharacterPlace;
    public TimeDate CharacterDate;

    public void UpdateValues(CharacterSO currentCharacterData)
    {
        CharacterStringName = currentCharacterData.CharacterStringName;
        CharacterSprite = currentCharacterData.CharacterSprite;
        CharacterName = currentCharacterData.CharacterName;
        CharacterLogo = currentCharacterData.CharacterLogo;
        CharacterArt1 = currentCharacterData.CharacterArt1;
        CharacterArt2 = currentCharacterData.CharacterArt2;
        CharacterArt3 = currentCharacterData.CharacterArt3;
        CharacterFlag = currentCharacterData.CharacterFlag;
        CharacterCountry = currentCharacterData.CharacterCountry;
        CharacterPlace = currentCharacterData.CharacterPlace;
        CharacterDate = currentCharacterData.CharacterDate;
    }

    public SuperArt GetArt(int position)
    {
        if(position == 0)
        {
            return CharacterArt1;
        }else if(position == 1)
        {
            return CharacterArt2;
        }
        else
        {
            return CharacterArt3;
        }
    }
}

[System.Serializable]
public struct SuperArt
{
    public Sprite SuperArtNum;
    public Sprite SuperArtName;
    public Sprite[] SuperArtCommands;
}

[System.Serializable]
public struct TimeDate
{
    public int Hour;
    public int Minute;
    public noonTime NoonTime;
}

public enum noonTime
{
    AM,
    PM
}
