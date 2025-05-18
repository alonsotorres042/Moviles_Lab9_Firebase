using UnityEngine;
using UnityEngine.UI;

public class CustomTimeHud : MonoBehaviour
{
    [SerializeField] private Sprite[] noonSprites;
    [SerializeField] private TimerHUD hourHud;
    [SerializeField] private TimerHUD minuteHud;
    [SerializeField] private Image noonImage;

    public void SetUp(TimeDate newTime)
    {
        hourHud.UpdateTimer(newTime.Hour);
        minuteHud.UpdateTimer(newTime.Minute);

        noonImage.sprite = newTime.NoonTime == noonTime.AM ? noonSprites[0] : noonSprites[1];
    }
}
