using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bola : MonoBehaviour
{
    GameObject bola;
    float alturaBola;
    // Start is called before the first frame update
    void Start()
    {
        bola = GameObject.Find("Bola");
        alturaBola = bola.transform.localScale.y / 2;
    }

    // Update is called once per frame
    void Update()
    {
        bola.transform.position = new Vector3(this.transform.position.x, transform.position.y, 0);
        arrumarAlturaBola();
    }
    private void arrumarAlturaBola()
    {
        if(bola.transform.position.y < alturaBola)
            bola.transform.position += new Vector3(0,0.01f,0);
        reposicionarBola();
    }

    private bool estaNoCampo()
    {
        if(this.transform.position.x > 16)
        {
            return false;
        }
        if (this.transform.position.x < -16)
        {
            return false;
        }
        if (this.transform.position.y < -1)
        {
            return false;
        }
        if (this.transform.position.x > 23)
        {
            return false;
        }
        return true;
    }

    public void reposicionarBola()
    {
        if (!estaNoCampo())
        {
            iniciarBola();
        }
    }

    public void iniciarBola()
    {
        this.transform.position = new Vector3(0, 13, 0);
        this.GetComponent<Rigidbody>().velocity = Vector3.zero;
        this.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }
}
