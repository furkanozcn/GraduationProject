using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraTakip : MonoBehaviour
{
    public GameObject Araba;

    private Vector3 Mesafe;

    private Vector3 BaslangicPozisyon;

    private float BaslangicZaman;

    private Transform Arac;

    [SerializeField]
    private Vector3 Pozisyon;

    [SerializeField]
    private Space offsetPositionSpace = Space.Self;

    [SerializeField]
    private bool lookAt = true;

    // Start is called before the first frame update
    void Start()
    {
        Mesafe = transform.position - Araba.transform.position;
        List<GameObject> cars = GameObject.Find("CarController").GetComponent<CarControllerAI>().getCars();
        Araba = cars[Random.Range(0, cars.Count - 1)];
        BaslangicPozisyon = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Arac = GameObject.FindGameObjectWithTag("Player").transform;
        Araba = GameObject.FindGameObjectWithTag("Player");
        transform.position = Araba.transform.position + Mesafe;
        Yenile();
        
    }
    public void Takip(GameObject YeniTakip)
    {
        BaslangicPozisyon = Araba.transform.position;
        BaslangicZaman = Time.time;
        Araba = YeniTakip;

    }
    public GameObject TakipEt()
    {
        return Araba;
    }
    public void Yenile()
    {
        if (Arac == null)
        {
            Debug.LogWarning("Hedef Bulunamadı !", this);

            return;
        }

        // Pozisyon
        if (offsetPositionSpace == Space.Self)
        {
            transform.position = Arac.TransformPoint(Pozisyon);
        }
        else
        {
            transform.position = Arac.position + Pozisyon;
        }

        // Yön
        if (lookAt)
        {
            transform.LookAt(Arac);
        }
        else
        {
            transform.rotation = Arac.rotation;
        }
    }
}
