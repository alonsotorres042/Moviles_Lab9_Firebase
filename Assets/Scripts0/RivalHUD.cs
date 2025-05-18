using UnityEngine;
using UnityEngine.UI;

public class RivalHUD : MonoBehaviour
{
    [Header("Images Components")]
    [SerializeField] private Image slotRival;
    [SerializeField] private Image flagRival;
    [SerializeField] private Image countryRival;
    [SerializeField] private Image placeRival;

    [Header("Other Components")]
    [SerializeField] private CustomTimeHud timeHUD;
    [SerializeField] private CustomTextHud textHUD;

    public void SetUp(CharacterSO rivalData)
    {
        slotRival.sprite = rivalData.CharacterRivalLogo;
        flagRival.sprite = rivalData.CharacterFlag;
        countryRival.sprite = rivalData.CharacterCountry;
        placeRival.sprite = rivalData.CharacterPlace;

        timeHUD.SetUp(rivalData.CharacterDate);
        textHUD.SetUp(rivalData.CharacterStringName);
    }
}