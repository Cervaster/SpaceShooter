using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [Header("Player Settings")]
    //Input settings
    [SerializeField] private float speed;
    private Rigidbody2D rb2D;
    private Vector2 moveDirection;
    [SerializeField] private InputActionReference move;
    [SerializeField] private InputActionReference attack;

    //Shoot settings
    [SerializeField] private float ratioShoot;
    [SerializeField] private GameObject shootPrefab;
    [SerializeField] private Transform spawnPoint1; 
    [SerializeField] private Transform spawnPoint2;
    private bool canShoot = true;

    //Sprite settings
    [SerializeField] private GameObject spritePlayer;

    [Header("UI Settings")]
    //UI settings
    [SerializeField] private TextMeshProUGUI textLife; 
    private float timer = 0.5f;
    private float lifes = 100;
    [SerializeField] private TextMeshProUGUI textPoints;
    private int points = 0;
    private int addLife = 0;


    void Start()
    {
        // Initialize UI text
        textLife.text = "Vidas: " + (lifes);
        textPoints.text = "Puntos: " + (points);

        // Get the Rigidbody2D component attached to the player
        rb2D = GetComponent<Rigidbody2D>();

        if (spritePlayer != null)
        {
            spritePlayer.GetComponent<SpriteRenderer>();
        }

    }

    void Update()
    {
        DelimitarMovimiento();

        // Read the movement input from the InputActionReference
        moveDirection = move.action.ReadValue<Vector2>();

        // Update the shooting timer
        timer += Time.deltaTime;

        // Check if the player can shoot and if the attack button is pressed
        if (canShoot && attack.action.IsPressed() && timer >= ratioShoot)
        {
            Attack(new InputAction.CallbackContext());
            timer = 0;
        }

        AddLife();
    }

    private void FixedUpdate()
    {
        rb2D.linearVelocity = new Vector2 (moveDirection.x * speed, moveDirection.y * speed);
    }

    private void OnEnable()
    {
        canShoot = true;
    }

    private void OnDisable()
    {
        canShoot = false;
    }

    private void Attack(InputAction.CallbackContext obj)
    {
        Instantiate(shootPrefab, spawnPoint1.position, Quaternion.identity);
        Instantiate(shootPrefab, spawnPoint2.position, Quaternion.identity);
    }

    void DelimitarMovimiento()
    {
        float xClamp = Mathf.Clamp(transform.position.x, -8.19f, 8.19f);
        float yClamp = Mathf.Clamp(transform.position.y, -4.21f, 4.21f);
        transform.position = new Vector3(xClamp, yClamp, 0);
    }

    // Handle collision with enemy projectiles or enemies
    private void OnTriggerEnter2D(Collider2D elOtro)
    {
        if (elOtro.gameObject.CompareTag("DisparoEnemigo") || elOtro.gameObject.CompareTag("Enemigo"))
        {
            Flash();
            MinusPoints();
            lifes -= 20;
            Destroy (elOtro.gameObject);

            if (lifes <= 0)
            {
                Destroy(this.gameObject);
                SceneManager.LoadScene("Juego", LoadSceneMode.Single);
            }
            textLife.text = "Vidas: " + (lifes);   
        }

    }

    // called from Enemy.cs when an enemy is destroyed to add points to the player
    public void SumarPuntos()
    {
        points += 100;
        textPoints.text = "Puntos: " + (points);

        addLife += 1;
    }

    private void MinusPoints()
    {
        if (points <=0)
        {  
            return; 
        }
        else
        {
            points -= 50;
            textPoints.text = "Puntos: " + (points);
        }
        
    }

    // Flash the player sprite red when hit
    private void Flash()
    {
        int flash = 3;
        for (int i = 0; i < flash; i++)
        {
            spritePlayer.GetComponent<SpriteRenderer>().color = Color.red;
            Invoke("ResetColor", 0.1f);
        }
    }
    private void ResetColor()
    {
        spritePlayer.GetComponent<SpriteRenderer>().color = Color.white;
    }

    // Add life to the player when they reach a certain number of points
    private void AddLife()
    {
        if (addLife >= 10)
        {
            lifes += 20;
            textLife.text = "Vidas: " + (lifes);
            addLife = 0;
        }
    }
}
