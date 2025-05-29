using System.Collections;
using System.Data;
using TMPro;
using UnityEngine;

public class Enemigo : MonoBehaviour  
{
    [SerializeField] private float velocidad;
    [SerializeField] private GameObject spawnPoint;
    [SerializeField] private GameObject disparoPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(Disparar()); 
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(-1, 0, 0) * velocidad * Time.deltaTime);
    }

    IEnumerator Disparar()//disparo infinito 

    {
        while (true)
        {
            Instantiate(disparoPrefab, spawnPoint.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(1f);
        }
       
    }

    private void OnTriggerEnter2D(Collider2D elOtro)
    {
        if (elOtro.gameObject.CompareTag("DisparoPlayer"))//impacto contra disparo
        {
            Destroy(elOtro.gameObject);
            Destroy(this.gameObject);

            GameObject.Find("Player").SendMessage("SumarPuntos");
        }
    }
    
}
