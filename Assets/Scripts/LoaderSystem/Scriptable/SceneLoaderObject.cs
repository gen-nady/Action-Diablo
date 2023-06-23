using UnityEngine;

namespace SceneLoader.Scriptable
{
    [CreateAssetMenu(fileName = "SceneLoader", menuName = "Loader", order = 0)]
    public class SceneLoaderObject : ScriptableObject
    {
        public Object Scene;
    }
}