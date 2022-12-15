using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gol : MonoBehaviour
{
    GameObject bola;
    GameObject placar;
    Placar sPlacar;
    Bola sBola;
   
    // Start is called before the first frame update
    void Start()
    {
        bola = GameObject.Find("Bola");
        sBola = bola.GetComponent<Bola>();
        placar = GameObject.Find("Placar");
        sPlacar = placar.GetComponent<Placar>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Bola")
        {
            if(bola.transform.position.x < 0)
            {
                sPlacar.setGolsEsq(1 + sPlacar.getGolsEsq());
            }
            else
            {
                sPlacar.setGolsDir(1 + sPlacar.getGolsDir());
            }
            Debug.Log("Gol!");
            sPlacar.atualizarPlacar();
            sBola.iniciarBola();
        }
    }
}
