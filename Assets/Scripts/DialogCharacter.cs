using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogCharacter : MonoBehaviour
{
    public List<int> dialogIDs;
    DialogSystem dialogSystem;
    Transform playerPos;
    public DialogPanel currentPanel = null;


    // Start is called before the first frame update
    void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        dialogSystem = FindObjectOfType<DialogSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, playerPos.position) < 2f)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (currentPanel != null)
                {
                    currentPanel.ClosePanel();
                    return;
                }
                currentPanel = dialogSystem.OpenDialog(dialogSystem.GetDialog(dialogIDs[0]));
                if (dialogIDs.Count > 1)
                {
                    dialogIDs.RemoveAt(0);
                }

            }
        }
    }
}
