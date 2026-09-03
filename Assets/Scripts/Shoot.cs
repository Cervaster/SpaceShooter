using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private float velocidad;
    [SerializeField] private Vector3 direccion;

    private bool destroy = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.Rotate(new Vector3(0, 0, 90));
    }

    // Update is called once per frame
    void Update()
    {      
        transform.Translate(direccion * velocidad * Time.deltaTime);
        BulletCrasher();
    }

    private void OnTriggerEnter2D(Collider2D elOtro)
    {
        if (elOtro.gameObject.CompareTag("BulletCrasher"))
        {
            destroy = true;
        }
    }

    private void BulletCrasher()
    {
        if (destroy)
        {
            Destroy(this.gameObject);
            destroy = false;
        }
    }
}
