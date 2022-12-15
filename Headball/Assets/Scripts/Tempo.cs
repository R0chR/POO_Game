using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tempo : MonoBehaviour
{
    private float segundos;
    private int segundosInteiros;
    private float tempo;
    private int minutosInteiros;
    GameObject temporizador;
    TextMeshProUGUI txtTemporizador;

    // Start is called before the first frame update
    void Start()
    {
        segundos = 120;
        tempo = Time.time;
        temporizador = GameObject.Find("Temporizador");
        txtTemporizador = temporizador.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        atualizarTempo();
    }

    public void atualizarTempo()
    {
        if (segundos > 0)
        {
            segundos = 120 - (Time.time - tempo);
            segundosInteiros = (int)segundos % 60;
            minutosInteiros = (int)segundos / 60;
        }
        
        txtTemporizador.SetText(minutosInteiros+":"+segundosInteiros.ToString());
    }
}
