using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public GameObject panel;
    private bool canPress = false;
    private Elevator elevator;
    private Player player;
    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.FindObjectOfType<Player>();
        this.elevator = GameObject.FindObjectOfType<Elevator>();
    }
    // Update is called once per frame
    void Update()
    {
        if (this.canPress)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                float x = this.elevator.transform.position.x;
                float y = this.elevator.transform.position.y + 1;
                float z = this.elevator.transform.position.z - 1;
                this.player.transform.SetPositionAndRotation(new Vector3(x, y, z), this.player.transform.rotation);
                this.canPress = false;
                this.panel.SetActive(false);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            this.panel.GetComponentInChildren<UnityEngine.UI.Text>().text = "Aperte 'E' para ir ao Elevador";
            this.panel.SetActive(true);
            this.canPress = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            this.canPress = false;
            this.panel.SetActive(false);
        }
    }
}
