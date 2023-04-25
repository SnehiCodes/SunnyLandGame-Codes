
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class enemyScript : MonoBehaviour
{

    public static int scoreValue ;
    public TextMeshProUGUI score;
   // Text score;
    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        score.text = ""+ scoreValue ;
    }
}