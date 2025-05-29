using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private float velocidad;
    [SerializeField] private float RatioDisparo;
    [SerializeField] private GameObject DisparoPrefab;
    [SerializeField] private Transform SpawnPoint1; 
    [SerializeField] private Transform SpawnPoint2;

    [SerializeField] private TextMeshProUGUI vidasTexto; 
    private float temporizador = 0.5f;
    private float vidas = 100;

    [SerializeField] private TextMeshProUGUI puntosText;
    private int puntos = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        vidasTexto.text = "Vidas: " + (vidas);
        puntosText.text = "Puntos: " + (puntos);
    }

    // Update is called once per frame
    void Update()
    {
        Movimiento();
        DelimitarMovimiento();
        Disparar(); 
    }

    void Movimiento()
    {
        float inputH = Input.GetAxis("Horizontal");
        float inputV = Input.GetAxis("Vertical");
        transform.Translate(new Vector2(inputH, inputV).normalized * velocidad * Time.deltaTime);
    }

    void DelimitarMovimiento()
    {
        float xClamp = Mathf.Clamp(transform.position.x, -8.19f, 8.19f);
        float yClamp = Mathf.Clamp(transform.position.y, -4.21f, 4.21f);
        transform.position = new Vector3(xClamp, yClamp, 0);
    }

    void Disparar()
    {
        temporizador += 1 * Time.deltaTime;

        if (Input.GetKey(KeyCode.Space) && temporizador > RatioDisparo)   
        {
            Instantiate(DisparoPrefab, SpawnPoint1.position, Quaternion.identity);
            Instantiate(DisparoPrefab, SpawnPoint2.position, Quaternion.identity);
            temporizador = 0; 
        }
    }

    private void OnTriggerEnter2D(Collider2D elOtro)
    {
        if (elOtro.gameObject.CompareTag("DisparoEnemigo") || elOtro.gameObject.CompareTag("Enemigo"))
        {
            vidas -= 20;
            Destroy (elOtro.gameObject);
            if (vidas <= 0)
            {
                Destroy(this.gameObject);
                SceneManager.LoadScene("Juego", LoadSceneMode.Single);
            }
            vidasTexto.text = "Vidas: " + (vidas);
        }
    }

    public void SumarPuntos()
    {
        puntos += 100;
        puntosText.text = "Puntos: " + (puntos);
    }

}
