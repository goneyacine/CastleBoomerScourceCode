using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChangeName : MonoBehaviour
{
    public InputField nameInputField;

    public void SubmitName()
    {
        DataSerialization.SaveData(nameInputField.text,"name");
    }
}
