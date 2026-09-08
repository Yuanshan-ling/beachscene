#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

[InitializeOnLoad]
public static class OpenDefaultSceneOnProjectLaunch
{
    private const string DefaultScenePath =
        "Assets/Scenes/beachscene.unity";

    static OpenDefaultSceneOnProjectLaunch()
    {
        EditorApplication.delayCall += OpenDefaultSceneWhenNeeded;
    }

    private static void OpenDefaultSceneWhenNeeded()
    {
        if (EditorApplication.isPlayingOrWillChangePlaymode)
        {
            return;
        }

        if (AssetDatabase.LoadAssetAtPath<SceneAsset>(DefaultScenePath) == null)
        {
            return;
        }

        Scene activeScene = SceneManager.GetActiveScene();

        // 仅在 Unity 打开 Untitled 空场景时，自动载入海滩主场景。
        if (string.IsNullOrEmpty(activeScene.path))
        {
            EditorSceneManager.OpenScene(
                DefaultScenePath,
                OpenSceneMode.Single
            );
        }
    }
}
#endif
