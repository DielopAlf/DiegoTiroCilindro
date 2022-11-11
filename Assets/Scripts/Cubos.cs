using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubos : MonoBehaviour
{


    public Material hitMaterial;
    public bool grande=false;
    public AudioClip shotSound;
    private AudioSource gunAudioSource;
    void Awake()
    {
        gunAudioSource = GetComponent<AudioSource>();

    }
    void Update()
    {
        Debug.Log(grande);
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
            if (Physics.Raycast(rayo, out hitInfo) == true)
            {
                if (hitInfo.collider.tag.Equals("Cubo"))
                {
                    Rigidbody rigidbodyCubo = hitInfo.collider.GetComponent<Rigidbody>();
                    //hitInfo.collider.GetComponent<MeshRenderer>().material = hitMaterial;
                    LeanTween.scale(gameObject, Vector3.one * 4.0f, 1.5f);
                    if (grande == false) 
                    {
                        
                        //hitInfo.collider.GetComponent<MeshRenderer>().material = hitMaterial;
                        LeanTween.scale(gameObject, Vector3.one *4.0f, 1.5f);
                        grande = true;
                    }

                    else 
                    {
                        //hitInfo.collider.GetComponent<MeshRenderer>().material = hitMaterial;
                        LeanTween.scale(gameObject, Vector3.one * 1.0f, 1.5f);
                        grande = false;
                    }
                }
                


            }


        }

    }
}



    // Start is called before the first frame update
    






