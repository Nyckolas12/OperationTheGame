using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class BloodLogic : MonoBehaviour
{
    [SerializeField] Slider blood;

    public float gameTime;
    private bool stopTimer;
    private bool hasGameOver = false;

    public AudioSource flat;
    public AudioClip clip;

    MenuManager gameOver;

    void Start()
    {
        stopTimer = false;
        blood.maxValue = gameTime;
        blood.value = gameTime;
        //gameTime = 5;
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name != "TestingScene") return;

        float elapsedTime = gameTime - Time.time;

        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);

        if (elapsedTime <= 0 && !hasGameOver)
        {
            hasGameOver = true;

            StartCoroutine(GameOver());
            
        }

        if (stopTimer == false)
        {
            blood.value = elapsedTime;
        }

        IEnumerator GameOver()
        {
            stopTimer = true;

            flat.PlayOneShot(clip);

            yield return new WaitForSecondsRealtime(clip.length);

            SceneManager.LoadScene(4);

            //Destroy(gameObject);
        }
    }
}
