using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextManager : MonoBehaviour
{
    [SerializeField()]
    string[] texts;
    public GameObject[] particles;
    public TextMeshProUGUI textContainer;
    int currentIndex = 0;
    public bool loadGameAfter = false;

    LevelManager levelManager;

    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();

        if (!textContainer || texts.Length == 0)
        {
            Debug.LogError("Missing Text container from inspector");
        }
        else
        {
            ManageText();
        }
    }
    
    void ManageText()
    {
        if(currentIndex < texts.Length)
        {
            textContainer.text = texts[currentIndex];
            if (particles.Length > 0) {
                if (particles[currentIndex])
                {
                    Instantiate(particles[currentIndex]);
                }
            }
            currentIndex++;
            StartCoroutine(Timer(3));
            return;
        }
        else if(loadGameAfter)
        {
            levelManager.LoadMain();
            return;
        }
    }

    IEnumerator Timer(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        ManageText();
    }
}
