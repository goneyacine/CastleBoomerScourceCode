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
            //'A', 'Q', 'z', 'P', 'm', 'e', '_', 'I','o','V'
            switch (c)
            {
                case 'A':
                    newChar = '1';
                    break;

                case 'Q':
                    newChar = '2';
                    break;

                case 'z':
                    newChar = '3';
                    break;

                case 'P':
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

                case 'I':
                    newChar = '8';
                    break;

                case 'o':
                    newChar = '9';
                    break;

                case 'V':
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
        if (ip == null || ip == "") { return null; }
        string id = "";
        for (int i = 0; i < ip.Length; i++)
        {
            char c = ip[i];
            char newChar = 'A';
            //'A', 'Q', 'z', 'P', 'm', 'e', '_', 'I','o','V'
            switch (c)
            {
                case '1':
                    newChar = 'A';
                    break;

                case '2':
                    newChar = 'Q';
                    break;

                case '3':
                    newChar = 'z';
                    break;

                case '4':
                    newChar = 'P';
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
                    newChar = 'I';
                    break;

                case '9':
                    newChar = 'o';
                    break;

                case '.':
                    newChar = 'V';
                    break;
            }
            id = id + newChar;
        }
        return id;
    }
    public Text id_Text;
    public string id; 
}