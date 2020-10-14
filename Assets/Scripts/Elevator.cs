using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public GameObject panel;
    public Collider theTrigger;
    private bool canPress = false;
    private bool isDown = true;
    private GameObject player;
    private Animation anim;
    // Start is called before the first frame update
    void Start()
    {
        this.panel.SetActive(false);
        this.anim = this.GetComponent<Animation>();
        this.anim.Play();
    }
    // Update is called once per frame
    void Update()
    {
        if (this.canPress)
            if (Input.GetKeyDown(KeyCode.E))
            {
                this.canPress = false;
                this.panel.SetActive(false);
                if (this.isDown)
                {
                    this.anim.Play("SubirElevador");
                    this.isDown = false;
                }
                else
                {
                    this.isDown = true;
                    this.anim.Play("DescerElevador");
                }
            }
    }
    
    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.name == "Player" && !this.anim.isPlaying)
        {
            this.canPress = true;
            this.panel.SetActive(true);
            this.player = other.gameObject;
            this.panel.GetComponentInChildren<UnityEngine.UI.Text>().text = this.isDown ?
            "Aperte 'E' para subir o elevador" : "Aperte 'E' para descer o elevador";
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            this.panel.SetActive(false);
            this.canPress = false;
        }
    }
}
