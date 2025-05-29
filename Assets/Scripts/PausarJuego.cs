using UnityEngine;
using UnityEngine.SceneManagement;

public class PausarJuego : MonoBehaviour
{
    public GameObject menuPausa;
    private bool juegoPausado = false;
    public AudioSource audioPausa; 
    public AudioSource audioJuego;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (audioPausa == null)
        {
            audioPausa = GetComponent<AudioSource>(); // Intenta obtener el AudioSource del mismo GameObject
        }

        if (audioJuego == null)
        { 
            audioJuego = GetComponent<AudioSource>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (juegoPausado)
            {
                Reanudar();
            }
            else
            {
                Pausar();
            }
        }
    }

    public void Reanudar()
    {
        menuPausa.SetActive(false);
        Time.timeScale = 1;
        juegoPausado = false;

        if (audioPausa != null && audioPausa.isPlaying)
        {
            audioPausa.Stop(); 
            audioJuego.Play();
        }
    }

    public void Pausar()
    {
        menuPausa.SetActive(true);
        Time.timeScale = 0;
        juegoPausado = true;

        if (audioPausa != null)
        {
            audioPausa.Play(); 
            audioJuego.Pause();
        }
    }

    public void Entrar()
    {
        SceneManager.LoadScene("Juego", LoadSceneMode.Single);
    }
}
