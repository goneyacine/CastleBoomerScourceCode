using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using UnityEngine.UI;

    
    public class ID_Generator : MonoBehaviour
    {
    private void OnEnable()
    {
        string hostName = Dns.GetHostName();
        string ip = Dns.GetHostByName(hostName).AddressList[0].ToString();
        string id = IP_to_ID(ip);
        id_Text.text = "Your ID : " + id;
    }
    //from id to an ip adress
    public static string ID_to_IP(string id)
    {
        if (id == null || id == "") { return null; }
        string ip = "";
        for(int i = 0; i < id.Length; i++)
        {
            char c = id[i];
            char newChar  = '1';
            switch (c)
            {
                case '.':
                newChar = '0';
                break;
                case 'A':
                    newChar = '1';
                    break;

                case 'Q':
                    newChar = '2';
                    break;

                case 'x':
                    newChar = '3';
                    break;

                case '3':
                    newChar = '4';
                    break;

                case 'm':
                    newChar = '5';
                    break;
                case 'e':
                    newChar = '6';
                    break;

                case '_':
                    newChar = '7';
                    break;

                case 'i':
                    newChar = '8';
                    break;

                case '7':
                    newChar = '9';
                    break;

                case '9':
                    newChar = '.';
                    break;
            }
            ip = ip + newChar;
        }
        return ip;
    }
    //from ip adress to an id
    public static string IP_to_ID(string ip)
    {
        Debug.Log(ip);
        if (ip == null || ip == "") { return null; }
        string id = "";
        for (int i = 0; i < ip.Length; i++)
        {
            char c = ip[i];
            char newChar = 'A';
            switch (c)
            {
                case '0':
                newChar = '.';
                break;
                case '1':
                    newChar = 'A';
                    break;

                case '2':
                    newChar = 'Q';
                    break;

                case '3':
                    newChar = 'x';
                    break;

                case '4':
                    newChar = '3';
                    break;

                case '5':
                    newChar = 'm';
                    break;
                case '6':
                    newChar = 'e';
                    break;

                case '7':
                    newChar = '_';
                    break;

                case '8':
                    newChar = 'i';
                    break;

                case '9':
                    newChar = '7';
                    break;

                case '.':
                    newChar = '9';
                    break;
            }
            id = id + newChar;
        }
        return id;
    }
    public Text id_Text;
    public string id; 
}