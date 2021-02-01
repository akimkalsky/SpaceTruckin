﻿using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public static class ButtonExtensions
{
    public static void AddOnClick(this Button self, UnityAction callback)
    {
        self.onClick.RemoveAllListeners();
        self.onClick.AddListener(callback);
    }

    public static void SetText(this Button self, string text)
    {
        Text buttonText = self.GetComponentInChildren<Text>();
        if (buttonText != null)
        {
            buttonText.text = text; 
        }
    }

    public static void SetColour(this Button self, Color newColour)
    {
        Image image = self.GetComponent<Image>();
        if (image != null)
        {
            image.color = newColour;
        }
    }
}
