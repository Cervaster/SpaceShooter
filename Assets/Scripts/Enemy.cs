using System.Collections;
using System.Data;
using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour  
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject spawnPoint;
    [SerializeField] private GameObject shootPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(Shoot()); 
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(-1, 0, 0) * speed * Time.deltaTime);
    }

    IEnumerator Shoot()//disparo infinito 

    {
        while (true)
        {
            Instantiate(shootPrefab, spawnPoint.transform.position, Quaternion.identity);
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
