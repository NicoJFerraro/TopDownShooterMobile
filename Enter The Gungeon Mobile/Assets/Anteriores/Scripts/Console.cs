using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class Console : MonoBehaviour {

    public GameObject container;

    public Text backText;
    public InputField inputText;

    public delegate void TemplateMethod();
    public Dictionary<string, CommandData> allComands = new Dictionary<string, CommandData>();

    public static Console instance;

    // Use this for initialization

    void Awake () {
        if (instance != null)
        {

            GameObject.Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            Clear();
            RegisterCommand("clear", Clear, "Limpia la pantalla");
            RegisterCommand("help", Help, "Muestra todos los comandos");
        }
        
    }

    public void RegisterCommand(string cmsName, TemplateMethod cmdCommand, string description)
    {
        var cdata = new CommandData();

        cdata.name = "/" + cmsName.ToLower();
        cdata.commmand = cmdCommand;
        cdata.description = description;

        allComands.Add(cdata.name, cdata);
    }


    public void Clear()
    {
        backText.text = "/help para ayuda";
    }

    public void Help()
    {
        foreach(var item in allComands)
        {
            Write(item.Value.ToString());
        }
    }

 
    
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.F1))
        {
            container.gameObject.SetActive(!container.gameObject.activeSelf);
            if(container.activeSelf)
            {
                inputText.Select();
            }
        }

        if (container.activeSelf)
        {
            if(Input.GetKeyDown(KeyCode.Return))
            {
                inputText.text = inputText.text.ToLower();
                if (allComands.ContainsKey(inputText.text))
                { 
                    try
                    {
                        allComands[inputText.text].commmand.Invoke();
                    }
                    catch (Exception error)
                    {
                        Write("Error: " + error.Message);
                    }
                }
                else
                {
                    Write(inputText.text);
                }
                inputText.text = "";

            }
        }
	}
    public void Write (string txt)
    {
        backText.text += "\n" + txt; 
    }
}
