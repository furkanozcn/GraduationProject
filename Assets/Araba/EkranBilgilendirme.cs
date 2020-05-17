using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EkranBilgilendirme : MonoBehaviour
{
    public Text AdetText;
    public Text AdimText;
    private static int Adim;
    private static int Adet;
    // Start is called before the first frame update
    void Start()
    {

    }
    
    // Update is called once per frame
    void Update()
    {
        Adet = CarControllerAI.adet;
        Adim = CarControllerAI.Adim;
        AdetText.text = "Araba Adedi: " + Adet.ToString(); 
        AdimText.text = "Test Sayısı: " + Adim.ToString();
    }
}
