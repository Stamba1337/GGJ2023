using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public GameObject PickUpText;
    public GameObject ItemOnPlayer;

    // Start is called before the first frame update
    void Start()
    {
        ItemOnPlayer.SetActive(false);
        PickUpText.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            PickUpText.SetActive(true);

            if (Input.GetKeyDown(KeyCode.F))
            {
                this.gameObject.SetActive(false);
                ItemOnPlayer.SetActive(true);
                PickUpText.SetActive(false);
            }

        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        PickUpText.SetActive(false);
    }
}
