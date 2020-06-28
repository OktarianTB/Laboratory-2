using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    int nextRoundIndex = 0;
    public GameObject[] monsters;
    public Transform[] spawnPositions;
    public TextMeshProUGUI text;
    private LevelManager levelManager;
    public AudioClip deathClip;

    private void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        if (!levelManager)
        {
            Debug.LogError("No level manager");
        }
        LoadNextRound();
    }

    public void LoadNextRound()
    {
        if(nextRoundIndex < monsters.Length)
        {
            Instantiate(monsters[nextRoundIndex], spawnPositions[nextRoundIndex].position, Quaternion.identity);
            text.text = "Round " + (nextRoundIndex + 1).ToString();
            if(nextRoundIndex > 0)
            {
                AudioSource.PlayClipAtPoint(deathClip, transform.position);
            }
            nextRoundIndex++;
        }
        else
        {
            AudioSource.PlayClipAtPoint(deathClip, transform.position);
            print("Congrats");
            StartCoroutine(Timer(3f));
        }
    }

    IEnumerator Timer(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        levelManager.LoadWin();
    }
}
