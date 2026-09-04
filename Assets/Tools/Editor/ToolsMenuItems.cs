using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.LowLevel;

namespace Tools.Menu
{
public static class ToolsMenuItems
{
    [MenuItem( "Tools/Chucha/Print total code lines")]
    static void CountLinesAndPrintToConsole()
    {
        string[] fileName = Directory.GetFiles("Assets/", "*.cs", SearchOption.AllDirectories);
 
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

    private const int indent = 2;

    [MenuItem("Tools/Chucha/Ouptut PlayerLoop subsystems")]
    static void PrintPlayerLoopSubSystems() => PlayerLoopTools.PrintToConsole(PlayerLoop.GetCurrentPlayerLoop(), indent);
}
}
