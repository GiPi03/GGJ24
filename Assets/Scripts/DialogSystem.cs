using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogSystem : MonoBehaviour
{
    public GameObject dialogPrefab;
    private void Start()
    {
    }
    public DialogPanel OpenDialog(Dialog dialog, Transform chare)
    {
        GameObject panel = Instantiate(dialogPrefab, GameObject.FindGameObjectWithTag("DialogCanvas").transform);
        panel.GetComponent<DialogPanel>().ShowDialog(dialog);
        return panel.GetComponent<DialogPanel>();
    }
    Dialog[] GetDialogs()
    {
        List<Dialog> list = new List<Dialog>();
        string filePath = System.IO.Path.Combine(Application.streamingAssetsPath, "dialog.csv");
        using (System.IO.StreamReader sr = new System.IO.StreamReader(filePath))
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                string[] data = line.Split(';');
                if (data.Length > 0)
                {
                    Dialog dialog = new Dialog(System.Convert.ToInt32(((string)data[0]).Trim()), data[1], data[2]);
                    list.Add(dialog);
                }
            }
        }
    
        return list.ToArray();
        }
    
    public Dialog GetDialog(int id)
    {
        string filePath = System.IO.Path.Combine(Application.streamingAssetsPath, "dialog.csv");
        Dialog dialog = new Dialog();
        using (System.IO.StreamReader sr = new System.IO.StreamReader(filePath))
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                string[] data = line.Split(";");
                if (data.Length > 0)
                {
                    if (System.Convert.ToInt32(data[0]) == id)
                    {
                        dialog = new Dialog(id, data[1], data[2]);

                    }
                }
            }
        }
        return dialog;
    }
}
