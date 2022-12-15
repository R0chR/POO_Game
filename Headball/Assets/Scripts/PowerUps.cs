using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    GameObject jogador;
    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "JogadorEsq")
        {
            jogador = GameObject.Find("JogadorEsq");
            Player sPlayer = jogador.GetComponent<Player>();
            puSuperSpeed(sPlayer);
            Destroy(gameObject);
            Debug.Log("Esq pegou o poder " + sPlayer.getPlayerVelocidadeMovimento());
        }
        else if(other.name == "JogadorDir")
        {
            jogador = GameObject.Find("JogadorDir");
            Player2 sPlayer = jogador.GetComponent<Player2>();
            puSuperSpeed(sPlayer);
            Destroy(gameObject);
            Debug.Log("Esq pegou o poder " + sPlayer.getPlayerVelocidadeMovimento());
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        destruirForaDoJogo();
    }
    public void puSuperSpeed(Player sPlayer)
    {
        sPlayer.setPlayerVelocidadeMovimento(5);
    }
    public void puSuperSpeed(Player2 sPlayer)
    {
        sPlayer.setPlayerVelocidadeMovimento(5);
    }
    public void destruirForaDoJogo()
    {
        if(transform.position.y < -2)
        {
            Destroy(gameObject);
        }
    }
}
