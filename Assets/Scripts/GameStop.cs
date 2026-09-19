using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStop : MonoBehaviour
{
    public GameObject pauseMenu;
    private bool pauseGame = false;
    public AudioSource audioStop; 
    public AudioSource audioGame;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (audioStop == null)
        {
            audioStop = GetComponent<AudioSource>(); // Intenta obtener el AudioSource del mismo GameObject
        }

        if (audioGame == null)
        { 
            audioGame = GetComponent<AudioSource>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (pauseGame)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        pauseGame = false;

        if (audioStop != null && audioStop.isPlaying)
        {
            audioStop.Stop(); 
            audioGame.Play();
        }
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        pauseGame = true;

        if (audioStop != null)
        {
            audioStop.Play(); 
            audioGame.Pause();
        }
    }

    public void Entry()
    {
        SceneManager.LoadScene("Juego", LoadSceneMode.Single);
    }
}
