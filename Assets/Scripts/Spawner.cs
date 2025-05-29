using System.Collections;
using System.Linq.Expressions;
using TMPro;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject prefabEnemigo;
    [SerializeField] private TextMeshProUGUI textoOleadas;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnEnemies());      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SpawnEnemies()
    {
        for (int i = 0; i < 5; i++)//nivel
        {
            for (int j = 0; j < 3; j++)//oleada
            {
                textoOleadas.text = "Nivel " + (i+1) + " -" + " Oleadas " + (j+1);
                yield return new WaitForSeconds(2f);
                textoOleadas.text="";

                for (int k = 0; k < 10; k++)//enemigo
                {
                    Vector3 puntoAleatorio = new Vector3(transform.position.x, Random.Range(-4.5f , 4.5f), 0);
                    Instantiate(prefabEnemigo, puntoAleatorio, Quaternion.identity);
                    yield return new WaitForSeconds(1f);
                }
                yield return new WaitForSeconds(2f);
            }
            yield return new WaitForSeconds(3f);
        }
    }
}
