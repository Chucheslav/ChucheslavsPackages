using System.IO;
using System.Text;
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
    static void PrintPlayerLoopSubSystems()
    {
        StringBuilder output = new StringBuilder();
        output.AppendLine("PlayerLoopSubSystems:");
        foreach (PlayerLoopSystem system in PlayerLoop.GetCurrentPlayerLoop().subSystemList)
        {
            AddSystemRecursively(system, 0);
        }
        Debug.Log( output.ToString() );
        void AddSystemRecursively(PlayerLoopSystem system, int level)
        {
            output.Append(' ', level*indent).AppendLine(system.type.ToString());
            if (system.subSystemList == null ||  system.subSystemList.Length == 0) return;
            foreach (PlayerLoopSystem subSystem in system.subSystemList) 
                AddSystemRecursively(subSystem, level + 1);
        }
    }
}
}
