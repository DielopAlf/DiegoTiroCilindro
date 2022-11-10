using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class Timer : MonoBehaviour
{
    [SerializeField] private TMP_Text timerText;//text del tiempo.

    private float timeElapsed; //mostrar la variable del tiempo.
    private int minutes, seconds, cents;


    private void Update()
    {

        timeElapsed += Time.deltaTime;//variable de tiempo sumandole el paso del tiempo.
        minutes = (int)(timeElapsed / 60f);// en un minuto pasa 95,75 en variable de tiempo por lo que se le multiplica.
        seconds = (int)(timeElapsed - minutes * 60f);// un minuto son 60 segundos por eso se le multiplica al minuto
        cents = (int)((timeElapsed - (int)timeElapsed) * 100f); //una centesima son 100 segundos por lo que se le multiplica a la variante del tiempo.
        timerText.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, cents);
        //asignamos  el formato string para que fluya y el texto para que siga el tiempo en el formato de 00:00:00.

    }
}

