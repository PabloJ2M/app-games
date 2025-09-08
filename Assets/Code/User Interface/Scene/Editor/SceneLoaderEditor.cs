using UnityEditor;

namespace UnityEngine.SceneManagement
{
    [CustomEditor(typeof(SceneLoader), true)]
    public class SceneLoaderEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            SceneLoader loader = target as SceneLoader;
            SceneAsset currentScene = AssetDatabase.LoadAssetAtPath<SceneAsset>(loader.ScenePath);

            serializedObject.Update();
            EditorGUI.BeginChangeCheck();
            SceneAsset newScene = EditorGUILayout.ObjectField("Scene", currentScene, typeof(SceneAsset), false) as SceneAsset;

            //Apply path to string variable
            if (EditorGUI.EndChangeCheck()) loader.ScenePath = AssetDatabase.GetAssetPath(newScene);
            serializedObject.ApplyModifiedProperties();

            Undo.RecordObject(loader, "change scene in loader");
        }
    }
}