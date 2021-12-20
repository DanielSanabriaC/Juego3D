using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public static UIManager instance;

    public Image blackScreen;

    public float speedScreen = 2f;

    public bool backToFade, backFromFade;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        if (backToFade)
        {
            blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b, Mathf.MoveTowards(blackScreen.color.a, 1f, speedScreen * Time.deltaTime));

            if(blackScreen.color.a == 1f)
            {
                backToFade = false;
            }
        }
        if (backFromFade)
        {
            blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b, Mathf.MoveTowards(blackScreen.color.a, 0f, speedScreen * Time.deltaTime));

            if (blackScreen.color.a == 0f)
            {
                backFromFade = false;
            }
        }
    }
}
