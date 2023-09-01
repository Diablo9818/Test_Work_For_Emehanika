using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TorchIndicator : MonoBehaviour
{
    public Slider progressBar; // Ссылка на объект ProgressBar
    public float maxTorchValue = 10f; // Максимальное значение индикатора
    private float currentTorchValue; // Текущее значение индикатора

    // Вызывается при старте игры
    private void Start()
    {
        currentTorchValue = 1; // Устанавливаем начальное значение
        UpdateProgressBar();
    }

    // Вызывается для уменьшения значения индикатора
    public void DecreaseTorchValue(float amount)
    {
        currentTorchValue -= amount;
        if (currentTorchValue < 0f)
        {
            currentTorchValue = 0f;
            // Здесь можно добавить логику, когда факел погас
        }
        UpdateProgressBar();
    }

    // Вызывается для увеличения значения индикатора
    public void IncreaseTorchValue(float amount)
    {
        currentTorchValue += amount;
        if (currentTorchValue > maxTorchValue)
        {
            currentTorchValue = maxTorchValue;
        }
        UpdateProgressBar();
    }

    // Обновление отображения ProgressBar
    private void UpdateProgressBar()
    {
        if (progressBar != null)
        {
            progressBar.value = currentTorchValue;
        }
    }
}
