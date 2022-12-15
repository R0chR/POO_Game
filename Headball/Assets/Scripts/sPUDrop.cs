using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sPUDrop : MonoBehaviour
{
    [SerializeField]
    GameObject powerUp;
    float tempo;
    // Start is called before the first frame update
    void Start()
    {
        tempo = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        movimentacaoPowerUp();
        droparPowerUp();
    }

    public void movimentacaoPowerUp()
    {
        transform.position = new Vector3(Mathf.Sin(Time.time) * 10, 10, 0);
    }
    public void droparPowerUp()
    {
        if(Time.time - tempo >= 7 )
        {
            Instantiate(powerUp, this.transform);
            Debug.Log("Soltar Power Up");
            tempo = Time.time;
        }
    }

}
