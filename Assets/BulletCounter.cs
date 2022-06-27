using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BulletCounter : MonoBehaviour
{
    private int Count = 0;
    public TextMeshProUGUI text;
    


    // Start is called before the first frame update
    void Start()
    {
        text = FindObjectOfType<TextMeshProUGUI>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
