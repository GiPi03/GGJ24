using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogPanel : MonoBehaviour
{
    
    public Text title;
    public Text description;
    public void ShowDialog(Dialog dialog)
    {
        title.text = dialog.title;
        description.text = dialog.description;
    }
    public void ClosePanel()
    {
        Destroy(gameObject);
    }

}
