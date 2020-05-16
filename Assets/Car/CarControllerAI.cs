using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CarControllerAI : MonoBehaviour {
    public List<GameObject> Arabalar;
    public int Adet;
    public static int adet;
    public static int Adim=0;
    public GameObject Araba;
    [HideInInspector]
    public DNA winner;
    public DNA secWinner;
    private int carsCreated = 0; 
    // Use this for initialization
    void Start () {
        newPopulation();
       
    }
	
	// Update is called once per frame
	void Update () {
        adet = Arabalar.Count();
    }
    public List<GameObject> getCars()
    {
        return Arabalar;
    }
    public void newPopulation()
    {
        Arabalar = new List<GameObject>();
        for(int i = 0; i < Adet; i++)
        {
            GameObject carObj = (Instantiate(Araba));
            Arabalar.Add(carObj);
            carObj.GetComponent<Car>().Initialize();
        }
        
        Adim++;
        Debug.Log(Adim);
    }
    public void newPopulation(bool geneticManipulation)
    {
        if (geneticManipulation)
        {
            
            Debug.Log("Arabalar Yüklendi..!");
            Arabalar = new List<GameObject>();
            for(int i = 0; i < Adet; i++)
            {
                DNA dna = winner.crossover(secWinner);
                DNA mutated = dna.mutate();
                GameObject carObj = Instantiate(Araba);
                Arabalar.Add(carObj);
                carObj.GetComponent<Car>().Initialize(mutated);
            }
        }
        Adim++;
        carsCreated = 0;
        GameObject.Find("Camera").GetComponent<KameraTakip>().Takip(Arabalar[0]);
    }
    public void restartGeneration()
    {
        Arabalar.Clear();
        newPopulation();
    }
}
