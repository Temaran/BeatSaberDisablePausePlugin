using UnityEngine.SceneManagement;
using Harmony;
using IPA;
using System.Reflection;

namespace DisablePausePlugin
{
    [HarmonyPatch(typeof(InstantPauseTrigger))]
    [HarmonyPatch("Tick")]
    public class InstantPauseTrigger_Tick_Patch
    {
        public static bool Prefix()
        {
            return false;
        }
    }

    public class Plugin : IBeatSaberPlugin
    {
        public const string VERSION_NUMBER = "1.0.0";
        public static Plugin Instance;
        public static IPA.Logging.Logger Log;
        private static HarmonyInstance _harmony;

        public void Init(object nullObject, IPA.Logging.Logger logger)
        {
            Log = logger;
        }

        public void OnApplicationStart()
        {
            Instance = this;

            if (_harmony == null)
            {
                _harmony = HarmonyInstance.Create("com.github.harmony.disablepauseplugin");
                _harmony.PatchAll(Assembly.GetExecutingAssembly());
            }
        }

        public void OnApplicationQuit()
        {            
        }

        public void OnUpdate()
        {
        }

        public void OnFixedUpdate()
        {
        }

        public void OnSceneLoaded(Scene scene, LoadSceneMode sceneMode)
        { 
        }

        public void OnSceneUnloaded(Scene scene)
        {
        }

        public void OnActiveSceneChanged(Scene prevScene, Scene nextScene)
        {
        }
    }
}
