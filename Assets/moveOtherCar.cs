using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveOtherCar : MonoBehaviour
{
    
    public Transform kart;
    public Transform otherKart;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        otherKart.position = new Vector3(kart.position.x - 0.5f, kart.position.y,kart.position.z - 0.5f);
    }
}
