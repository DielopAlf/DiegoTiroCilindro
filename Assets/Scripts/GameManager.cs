using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{



    int contador;
    public Material hitMaterial;
    [SerializeField]
    public AudioClip shotSound;
    public AudioClip shotSoundMetal;

    private AudioSource gunAudioSource;

    [SerializeField]
    TextMeshProUGUI puntuacion;

    void Awake()
    {
        gunAudioSource = GetComponent<AudioSource>();
        
    }
    // Update is called once per frame
    void Update()
    {

        if ((Input.touchCount >= 1 && Input.GetTouch(0).phase == TouchPhase.Ended) || (Input.GetMouseButtonUp(0)))
        {
            //gunAudioSource.PlayOneShot(shotSound);
            Vector3 pos = Input.mousePosition;
            if (Application.platform == RuntimePlatform.Android)
            { 
                pos = Input.GetTouch(0).position;
            }

            Ray rayo = Camera.main.ScreenPointToRay(pos);
            RaycastHit hitInfo;
            if (Physics.Raycast(rayo, out hitInfo)==true)
            {
                if (hitInfo.collider.tag.Equals("Lata"))
                {
                    Rigidbody rigidbodyLata = hitInfo.collider.GetComponent<Rigidbody>();
                    rigidbodyLata.AddForce(rayo.direction * 50f, ForceMode.VelocityChange);
                    hitInfo.collider.GetComponent<MeshRenderer>().material = hitMaterial;
                    gunAudioSource.PlayOneShot(shotSoundMetal);

                    contador += 10;
                    puntuacion.text = "Puntuación: " + contador;


                }
                else { contador -= 5; puntuacion.text = "Puntuación: " + contador;
                    gunAudioSource.PlayOneShot(shotSound);

                }

            }
            else { contador -= 5; puntuacion.text = "Puntuación: " + contador;
                gunAudioSource.PlayOneShot(shotSound);

            }

        }

    }
}
