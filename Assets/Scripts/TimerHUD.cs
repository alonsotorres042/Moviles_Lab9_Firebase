using UnityEngine;
using UnityEngine.UI;

public class TimerHUD : MonoBehaviour
{
    [SerializeField] private Sprite[] timeNumbers;
    [SerializeField] private Image tenImage;
    [SerializeField] private Image unitImage;

    [SerializeField] private bool isSubscriber = true;

    private void OnEnable()
    {
        if (!isSubscriber) return;

        Timer.OnTimeUpdate += UpdateTimer;
    }

    private void OnDisable()
    {
        if (!isSubscriber) return;

        Timer.OnTimeUpdate -= UpdateTimer;
    }

    public void UpdateTimer(int time)
    {
        int ten = time / 10;
        int unit = time % 10;

        tenImage.sprite = timeNumbers[ten];
        unitImage.sprite = timeNumbers[unit];
    }

}
