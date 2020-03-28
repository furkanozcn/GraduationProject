using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCollision : MonoBehaviour
{
    public Car car;
    private void OnCollisionEnter(Collision collision)
    { 
        if (collision.gameObject.tag == "Kenar")
        {
            Debug.Log("Araç temas");
            Destroy(car);
            car.changeCamera();
        }
    }
}
