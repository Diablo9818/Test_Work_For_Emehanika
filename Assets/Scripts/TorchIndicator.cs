using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TorchIndicator : MonoBehaviour
{
    public Slider progressBar; // ������ �� ������ ProgressBar
    public float maxTorchValue = 10f; // ������������ �������� ����������
    private float currentTorchValue; // ������� �������� ����������

    // ���������� ��� ������ ����
    private void Start()
    {
        currentTorchValue = 1; // ������������� ��������� ��������
        UpdateProgressBar();
    }

    // ���������� ��� ���������� �������� ����������
    public void DecreaseTorchValue(float amount)
    {
        currentTorchValue -= amount;
        if (currentTorchValue < 0f)
        {
            currentTorchValue = 0f;
            // ����� ����� �������� ������, ����� ����� �����
        }
        UpdateProgressBar();
    }

    // ���������� ��� ���������� �������� ����������
    public void IncreaseTorchValue(float amount)
    {
        currentTorchValue += amount;
        if (currentTorchValue > maxTorchValue)
        {
            currentTorchValue = maxTorchValue;
        }
        UpdateProgressBar();
    }

    // ���������� ����������� ProgressBar
    private void UpdateProgressBar()
    {
        if (progressBar != null)
        {
            progressBar.value = currentTorchValue;
        }
    }
}
