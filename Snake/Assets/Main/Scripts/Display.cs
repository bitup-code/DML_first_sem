using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Display : MonoBehaviour
{
    private Text appleText;
    private int apple = 0; 
    
    void Start()
    {
        appleText = GetComponent<Text>();
        UpdateDisolay();
    }

    public void AddStars(int amount)
    {
        apple += amount;
        UpdateDisolay();
    }

    
    private void UpdateDisolay()
    {
        appleText.text = apple.ToString();
    }
}
