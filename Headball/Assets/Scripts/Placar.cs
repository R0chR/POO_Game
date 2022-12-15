using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Placar : MonoBehaviour
{
    [SerializeField]
    private int golsEsq;
    [SerializeField]
    private int golsDir;
    GameObject placarEsq;
    GameObject placarDir;
    private TextMeshProUGUI txtPlacarEsq;
    private TextMeshProUGUI txtPlacarDir;

    public int getGolsEsq()
    {
        return this.golsEsq;
    }

    public void setGolsEsq(int golsEsq)
    {
        this.golsEsq = golsEsq;
    }
    public int getGolsDir()
    {
        return this.golsDir;
    }

    public void setGolsDir(int golsDir)
    {
        this.golsDir = golsDir;
    }
    // Start is called before the first frame update
    void Start()
    {
        placarEsq = GameObject.Find("PlacarEsq");
        placarDir = GameObject.Find("PlacarDir");
        txtPlacarEsq = placarEsq.GetComponent<TextMeshProUGUI>();
        txtPlacarDir = placarDir.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void atualizarPlacar()
    {
        txtPlacarEsq.SetText(golsEsq.ToString());
        txtPlacarDir.SetText(golsDir.ToString());
    }
}
