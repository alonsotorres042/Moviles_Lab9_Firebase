using System;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float currentTime;
    [SerializeField] private int currentTimeInt;

    public static event Action<int> OnTimeUpdate;

    private void Update()
    {
        if (currentTime <= 0) return;

        currentTime -= Time.deltaTime;

        currentTimeInt = (int)currentTime;

        OnTimeUpdate?.Invoke(currentTimeInt);
    }

    public void SetTime(float newTime)
    {
        currentTime = newTime;
    }
}