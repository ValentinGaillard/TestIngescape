using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ingescape;
using System;
using System.IO;

public class test : MonoBehaviour
{
    igs_observeCallback callbackLabelString;
    igs_observeCallback callbackLabelDouble;
    igs_observeCallback callbackLabelDoubleVideo;

    // Start is called before the first frame update
    void Start()
    {
        InitIngescape();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.X))
        {
            byte[] bytes = File.ReadAllBytes(Application.dataPath + "/p1_x.png");

            Debug.Log(bytes.Length);

            Igs.writeOutputAsData("image", bytes,(uint)bytes.Length);

            File.WriteAllBytes(Application.dataPath + "/../p1_xcopie.png", bytes);
        }

        if (Input.GetKeyUp(KeyCode.C))
        {
            byte[] bytes = File.ReadAllBytes(Application.dataPath + "/v.mp4");

            Debug.Log(bytes.Length);

            Igs.writeOutputAsData("video", bytes, (uint)bytes.Length);

            File.WriteAllBytes(Application.dataPath + "/../vcopie.mp4", bytes);
        }

        Igs.writeOutputAsString("string", "patate");
    }

    void CallbackString(iop_t iopType, string name, iopType_t valueType, IntPtr value, int valueSize, IntPtr myData)
    {
       
    }

    private void InitIngescape()
    {
        Igs.setAgentName("UnityAgent");
        
        Igs.createOutput("string", iopType_t.IGS_STRING_T, IntPtr.Zero, 0);
        Igs.createOutput("image", iopType_t.IGS_DATA_T, IntPtr.Zero, 0);
        Igs.createOutput("video", iopType_t.IGS_DATA_T, IntPtr.Zero, 0);
        /**
        Igs.addMappingEntry("string", "WpfAgent", "stringEntry");
        Igs.setMappingDescription("send string from unity to wpf");
        Igs.setMappingName("MappingUnityWpf");
        **/
        
        callbackLabelString = CallbackString;

        /**
        Igs.observeOutput("string", callbackLabelString, IntPtr.Zero);
        using (StreamReader r = new StreamReader("mapping.json"))
        {
            string json = r.ReadToEnd();
            Debug.Log(json);
            Igs.loadMapping(json);
            
        }**/
        
        Debug.Log(Igs.getMapping());

        Igs.startWithDevice("Wi-Fi", 5670);
    }
}
