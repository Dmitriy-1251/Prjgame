using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR

using UnityEditor;
using UnityEditor.SceneManagement;


public class CustomBuild
{
    static string outputProjectsFolder = Environment.GetEnvironmentVariable("OutputDirectory");
    static string xcodeProjectsFolder = Environment.GetEnvironmentVariable("XcodeDirectory");

    static void SetVersion()
    {
        PlayerSettings.bundleVersion = PackageInfo.Version;// "6.03";  
       // UnityEngine.Debug.Log("PlayerSettings.bundleVersion=" + PlayerSettings.bundleVersion);

    }

    [MenuItem("Build/Build Demo")]
    public static void BuildDemo()
    {
        SetVersion();
        var path = "_Demo";
        try
        {
            BuildWindows(path, "DevXUnityUnpackerDemo-WIN");
            BuildOSX(path, "DevXUnityUnpackerDemo-MAC");
            ExportPackage(path, "DevXUnityEditor-GameRecovery-Demo.unitypackage");


            System.IO.Directory.Delete("Assets/StreamingAssets", true);
            BuildAndroid(path, "DevXUnityUnpackerDemo-Android.apk");


            EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTargetGroup.Standalone, BuildTarget.StandaloneOSX);
       
            Debug.LogWarning("Build demo - ok");
        }
        catch(Exception ex)
        {
            Debug.LogError("Build demo - Error\n"+ex);
        }
    }
    [MenuItem("Build/Build LIC")]
    public static void BuildLIC()
    {
        SetVersion();
        try
        {
            var path = "_LIC";
            BuildWindows(path, "DevXUnityUnpacker-WIN-LIC");
            BuildOSX(path, "DevXUnityUnpacker-MAC-LIC");
            ExportPackage(path, "DevXUnityEditor-GameRecovery-LIC.unitypackage");

            System.IO.Directory.Delete("Assets/StreamingAssets", true);
            BuildAndroid(path, "DevXUnityUnpacker-Android-LIC.apk");
          
            EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTargetGroup.Standalone, BuildTarget.StandaloneOSX);
       
            Debug.LogWarning("Build lic - ok");
        }
        catch (Exception ex)
        {
            Debug.LogError("Build demo - Error\n" + ex);
        }
    }

    public static void ExportPackage(string path, string name)
    {
        AssetDatabase.ExportPackage(new string[] { "Assets/DevXUnityUnpackerToolsLib","Assets/TempAssets","Assets/Windows" , "Assets/StreamingAssets" }, path +"/"+name,ExportPackageOptions.Recurse);
    }

   
    static void BuildAndroid(string path, string name )
    {
        //= "DevXUnityUnpacker-Android-LIC.apk"

        EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTargetGroup.Android, BuildTarget.Android);
        SetVersion();

        //PlayerSettings.applicationIdentifier = Environment.GetEnvironmentVariable("AppBundle");
        //PlayerSettings.Android.keystoreName = Environment.GetEnvironmentVariable("KeystoreName");
        //PlayerSettings.Android.keystorePass = Environment.GetEnvironmentVariable("KeystorePassword");
        //PlayerSettings.Android.keyaliasName = Environment.GetEnvironmentVariable("KeyAlias");
        //PlayerSettings.Android.keyaliasPass = Environment.GetEnvironmentVariable("KeyPassword");

        BuildPipeline.BuildPlayer(GetScenes(),path+ "/"+name, BuildTarget.Android, BuildOptions.None);
    }
  
    static void BuildWindows(string path, string name)
    {
        //="DevXUnityUnpackerDemo-WIN"
        EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTargetGroup.Standalone, BuildTarget.StandaloneWindows64);
        SetVersion();
        BuildPipeline.BuildPlayer(GetScenes(), path+"/"+name+"/" + name + ".exe", BuildTarget.StandaloneWindows64, BuildOptions.None);

        try
        {
            System.IO.File.Delete(path + "/" + name + "/UnityCrashHandler64.exe");
        }
        catch { }

        PackageInfo.CompressFolder(path+"/" + name + "", path+"/" + name + ".zip", path);
    }

    static void BuildOSX(string path, string name = "DevXUnityUnpackerDemo-MAC")
    {
        EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTargetGroup.Standalone, BuildTarget.StandaloneOSX);
        SetVersion();
        BuildPipeline.BuildPlayer(GetScenes(), path+"/"+name, BuildTarget.StandaloneOSX, BuildOptions.None);
        PackageInfo.CompressFolder(path + "/" + name + ".app", path+"/" + name + ".zip", path);
    }
    //[MenuItem("Build/MAC compres")]
    //static void BuildOSX11()
    //{
    //    PackageInfo.CompressFolder("_Demo" + "/" + "DevXUnityUnpackerDemo-MAC" + ".app", "_Demo" + "/" + "DevXUnityUnpackerDemo-MAC" + ".zip");
    //}

    /*
    static void BuildIOS()
    {
        BuildTarget target = BuildTarget.iOS;
        EditorUserBuildSettings.SwitchActiveBuildTarget(target);
        PlayerSettings.applicationIdentifier = Environment.GetEnvironmentVariable("AppBundle");
        PlayerSettings.iOS.appleDeveloperTeamID = Environment.GetEnvironmentVariable("GymTeamId");

        BuildPipeline.BuildPlayer(GetScenes(), xcodeProjectsFolder, target, options);
    }
    */
    // Добавляем выбранные в настройках сцены в билд
    static string[] GetScenes()
    {
        var projectScenes = EditorBuildSettings.scenes;
        List<string> scenesToBuild = new List<string>();
        for (int i = 0; i < projectScenes.Length; i++)
        {
            if (projectScenes[i].enabled)
            {
                scenesToBuild.Add(projectScenes[i].path);
            }
        }
        return scenesToBuild.ToArray();
    }
}

#endif