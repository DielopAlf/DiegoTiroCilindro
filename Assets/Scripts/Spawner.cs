using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour


{

    [SerializeField]

    float timeMin, timeMax, time=0;
    [SerializeField]
    GameObject prebabtarget;
    


    void Start()
    {
        // InvokeRepeating("CreateTarget", TimeMin, Random.Range(TimeMin, TimeMax));
    }



    void ObjetosAleatorios()
    {

        Instantiate(prebabtarget, gameObject.transform.position, Quaternion.identity);
    }
    void Update()
    {
        time += Time.deltaTime;
        if(time >5) 
        {
            ObjetosAleatorios();
            time = 0;
        }

    }
    


}
