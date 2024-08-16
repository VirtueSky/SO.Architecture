using UnityEngine;
using VirtueSky.Inspector;
using VirtueSky.Utils;

namespace VirtueSky.Tracking
{
    [EditorIcon("icon_scriptable"), HideMonoScript]
    public class AppsFlyerSetting : ScriptableSettings<AppsFlyerSetting>
    {
        [SerializeField] private string devKey;
        [SerializeField] private string appID;
        [SerializeField] private string uwpAppID;
        [SerializeField] private string macOSAppID;
        [SerializeField] private bool getConversionData;
        [SerializeField] private bool isDebug;


        public static string DevKey => Instance.devKey;
        public static string AppID => Instance.appID;
        public static string UWPAppID => Instance.uwpAppID;
        public static string MacOSAppID => Instance.macOSAppID;
        public static bool IsDebug => Instance.isDebug;
        public static bool GetConversionData => Instance.getConversionData;
    }
}