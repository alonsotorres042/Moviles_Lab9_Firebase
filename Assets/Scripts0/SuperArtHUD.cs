using UnityEngine;
using UnityEngine.UI;

public class SuperArtHUD : MonoBehaviour
{
    [Header("Super Art Data")]
    [SerializeField] private Image artNumber;
    [SerializeField] private Image artName;
    [SerializeField] private Image[] commands;

    private void OnEnable()
    {
        SuperArtSelecitonHUD.OnChangeArt += ChangeSuperArt;
    }

    private void OnDisable()
    {
        SuperArtSelecitonHUD.OnChangeArt -= ChangeSuperArt;
    }

    private void ChangeSuperArt(SuperArt newData)
    {
        artNumber.sprite = newData.SuperArtNum;
        artName.sprite = newData.SuperArtName;

        for (int i = 0; i < commands.Length; i++)
        {
            if (i < newData.SuperArtCommands.Length)
            {
                commands[i].gameObject.SetActive(true);

                commands[i].sprite = newData.SuperArtCommands[i];
            }
            else
            {
                commands[i].gameObject.SetActive(false);
            }
        }
    }
}
