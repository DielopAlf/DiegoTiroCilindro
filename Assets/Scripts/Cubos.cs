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
             
                    //hitInfo.collider.GetComponent<MeshRenderer>().material = hitMaterial;
                    if (grande == false) 
                    {
                        Cubos cubos = hitInfo.collider.GetComponent<Cubos>();
                        cubos.ClickOnCube();
                    }

                   
                }
                


            }


        }

    }
}



    // Start is called before the first frame update
    






