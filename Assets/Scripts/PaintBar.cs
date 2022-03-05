using System;
using UnityEngine;
using UnityEngine.UI;

public class PaintBar : MonoBehaviour
{
    [SerializeField] private Slider slider;

    [SerializeField] private float maxPaint = 100f;

    [SerializeField] private float currentPaint = 100f;

    [SerializeField] private float regeneration = 15f;

    public bool CanShoot(float cost)
    {
        return currentPaint >= cost;
    }

    public void Shoot(float cost)
    {
        currentPaint -= cost;
    }

    public void SetColor(Color color)
    {
        slider.fillRect.GetComponent<Image>().color = color;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentPaint < maxPaint)
        {
            currentPaint = Mathf.Clamp(currentPaint + regeneration * Time.deltaTime, 0, maxPaint);
        }

        slider.value = currentPaint / maxPaint;
    }
}
