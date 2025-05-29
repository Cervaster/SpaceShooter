using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private float velocidad;
    [SerializeField] private Vector3 direccion;
    [SerializeField] private float anchoImagen;

    private Vector3 posicionInicial;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        posicionInicial = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Cuanto me queda de recorrido para alcanzar un nuevo ciclo.
        float espacio = velocidad * Time.time;
        float recorridoFaltante = espacio % anchoImagen;

        //Mi posicion se va actualizando desde la inicial Sumando tanto como recorrido me falta
        transform.position = posicionInicial + recorridoFaltante * direccion;
    }
}
