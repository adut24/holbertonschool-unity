using System.Collections.Generic;
using UnityEngine;

public class SceneHistory : MonoBehaviour
{
    public static List<string> sceneVisited = new();
    public static List<GameObject> sceneObjects = new();

    private void Awake() => DontDestroyOnLoad(gameObject);
}
