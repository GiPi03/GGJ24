using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogCharacter : MonoBehaviour
{
    public List<int> dialogIDs;
    DialogSystem dialogSystem;
    Transform playerPos;
    DialogPanel currentPanel = null;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        dialogSystem = FindObjectOfType<DialogSystem>();
        if (Vector3.Distance(transform.position, playerPos.position) < 2f)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (currentPanel != null)
                {
                    currentPanel.ClosePanel();
                    return;
                }
                currentPanel = dialogSystem.OpenDialog(dialogSystem.GetDialog(dialogIDs[0]),transform);
                if (dialogIDs.Count > 1)
                {
                    dialogIDs.RemoveAt(0);
                }

            }
        }
        
    }
}
