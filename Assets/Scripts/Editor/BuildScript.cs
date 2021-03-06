﻿using Boo.Lang;
using UnityEditor;

public class BuildScript
{
    static string[] EnabledScenes = FindEnabledEditorScenes();
    
    static void PerformBuild()
    {
        BuildPipeline.BuildPlayer(new BuildPlayerOptions
        {
            scenes = EnabledScenes,
            locationPathName = "./builds/android/game.apk",
            target = BuildTarget.Android,
            options = BuildOptions.None
        });
    }
    
    private static string[] FindEnabledEditorScenes(){
 
        List<string> EditorScenes = new List<string>();
        foreach (EditorBuildSettingsScene scene in EditorBuildSettings.scenes){
            if (scene.enabled){
                EditorScenes.Add(scene.path);
            }
        }
        return EditorScenes.ToArray();
    }
}
