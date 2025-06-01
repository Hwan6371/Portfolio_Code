using System.IO;
using UnityEditor;
using UnityEditor.Callbacks;

public class BuildPostProcessor
{
    [PostProcessBuild(1)]
    public static void OnPostProcessBuild(BuildTarget target, string pathToBuiltProject)
    {
        if (target == BuildTarget.WebGL)
        {
            string customHtmlPath = "Assets/CustomWebGLTemplates/index.html"; // 커스텀 index.html 파일의 경로
            string destinationPath = Path.Combine(pathToBuiltProject, "index.html"); // 빌드된 WebGL의 index.html 파일 경로

            if (File.Exists(customHtmlPath))
            {
                File.Copy(customHtmlPath, destinationPath, true);
                // Debug.Log("Custom index.html has been copied to the WebGL build folder.");
            }
            else
            {
                // Debug.LogError("Custom index.html file not found at: " + customHtmlPath);
            }
        }
    }
}
