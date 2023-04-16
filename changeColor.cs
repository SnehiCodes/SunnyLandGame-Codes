using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeColor : MonoBehaviour
{
    public Image img;
    [SerializeField] private Color colorToTurnTo = Color.white;
    
    private void Start()
    {
        Image img = GetComponent<Image>();

        img.color = colorToTurnTo;

    }

    // Update is called once per frame
    
}

