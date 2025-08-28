using System.IO;
using UnityEditor;
using UnityEngine;

public class CodeLineCounter : MonoBehaviour
{
    [MenuItem("Chucha/Output total code lines")]
    static void PrintTotalLine()
    {
        string[] fileName = Directory.GetFiles("Assets/Scripts", "*.cs", SearchOption.AllDirectories);
 
        int totalLine = 0;
        foreach (var temp in fileName)
        {
            int nowLine = 0;
            StreamReader sr = new StreamReader(temp);
            while (sr.ReadLine() != null)
            {
                nowLine++;
            }
 
            //File name + number of file lines
            //Debug.Log(String.Format("{0}——{1}", temp, nowLine));
 
            totalLine += nowLine;
        }
 
        Debug.Log( "Total code lines:" + totalLine);
    }
}
