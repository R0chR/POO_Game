using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    GameObject player;
    Player sPlayer;
    Vector3 posicaoJogador;
    [SerializeField]
    private float diferencaPosicaoPlayer;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Jogador");
        sPlayer = player.GetComponent<Player>();
        posicaoJogador = player.transform.position;
        this.transform.position = new Vector3(posicaoJogador.x, posicaoJogador.y, -10);
    }

    // Update is called once per frame
    void Update()
    {
        atualizarCamera();
    }

    private bool atualizarCamera()
    {
        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            posicaoJogador = player.transform.position;
        }

        diferencaPosicaoPlayer = player.transform.position.x - posicaoJogador.x;

        if (diferencaPosicaoPlayer < 1 && diferencaPosicaoPlayer > -1)
        {
            return false;
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            this.transform.position += new Vector3(sPlayer.getPlayerVelocidadeMovimento(),0,0);
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            this.transform.position -= new Vector3(sPlayer.getPlayerVelocidadeMovimento(), 0, 0);
        }
        return true;
    }
}
