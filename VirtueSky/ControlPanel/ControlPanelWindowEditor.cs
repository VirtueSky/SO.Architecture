﻿using UnityEditor;
using UnityEngine;
using VirtueSky.Ads;
using VirtueSky.AssetFinder.Editor;
using VirtueSky.Audio;
using VirtueSky.Events;
using VirtueSky.Iap;
using VirtueSky.Inspector;
using VirtueSky.LevelEditor;
using VirtueSky.ObjectPooling;
using VirtueSky.Rating;
using VirtueSky.UtilsEditor;
using VirtueSky.Variables;

namespace VirtueSky.ControlPanel
{
    public class ControlPanelWindowEditor : EditorWindow
    {
        private StatePanelControl statePanelControl;
        private bool isFieldMax = false;

        private bool isFielAdmob = false;
        // private static CustomColor selectedColorContent = CustomColor.LightRed;
        // private static CustomColor selectedColorTextContent = CustomColor.Gold;
        //
        // private static CustomColor selectedColorBackgroundRect = CustomColor.DarkSlateGray;
        // private Color colorContent = ColorExtensions.ToColor(selectedColorContent);
        // private Color colorTextContent = ColorExtensions.ToColor(selectedColorTextContent);
        // private Color colorBackgroundRect = ColorExtensions.ToColor(selectedColorBackgroundRect);


        [MenuItem("Sunflower/Control Panel &1", false)]
        public static void ShowPanelControlWindow()
        {
            ControlPanelWindowEditor window = GetWindow<ControlPanelWindowEditor>("Sunflower Control Panel");
            if (window == null)
            {
                Debug.LogError("Couldn't open the iap settings window!");
                return;
            }

            window.minSize = new Vector2(500, 300);
            window.Show();
        }

        private void OnGUI()
        {
            EditorGUI.DrawRect(new Rect(0, 0, position.width, position.height), ColorBackgroundRect.ToColor());
            GUILayout.Space(10);
            GUI.contentColor = ColorTextContent.ToColor();
            GUILayout.Label("SUNFLOWER CONTROL PANEL", EditorStyles.boldLabel);
            GUI.backgroundColor = ColorContent.ToColor();
            Handles.color = Color.black;
            Handles.DrawAAPolyLine(4, new Vector3(0, 30), new Vector3(position.width, 30));
            // GuiLine(2, Color.black);
            GUILayout.Space(10);
            GUILayout.BeginHorizontal();
            GUILayout.BeginVertical(GUILayout.Width(200));
            DrawButton();
            Handles.DrawAAPolyLine(4, new Vector3(210, 0), new Vector3(210, position.height));
            GUILayout.EndVertical();
            DrawContent();
            GUILayout.EndHorizontal();
        }

        void DrawButton()
        {
            if (GUILayout.Button("Advertising"))
            {
                statePanelControl = StatePanelControl.Advertising;
            }

            if (GUILayout.Button("In App Purchase"))
            {
                statePanelControl = StatePanelControl.InAppPurchase;
            }

            if (GUILayout.Button("ScriptableObject Event"))
            {
                statePanelControl = StatePanelControl.SO_Event;
            }

            if (GUILayout.Button("ScriptableObject Variable"))
            {
                statePanelControl = StatePanelControl.SO_Variable;
            }

            if (GUILayout.Button("Audio"))
            {
                statePanelControl = StatePanelControl.Audio;
            }

            if (GUILayout.Button("Pools"))
            {
                statePanelControl = StatePanelControl.Pools;
            }

            if (GUILayout.Button("Assets Usage Detector"))
            {
                statePanelControl = StatePanelControl.AssetsUsageDetector;
            }

            if (GUILayout.Button("In App Review"))
            {
                statePanelControl = StatePanelControl.InAppReview;
            }

            if (GUILayout.Button("Level Editor"))
            {
                statePanelControl = StatePanelControl.LevelEditor;
            }

            if (GUILayout.Button("Notifications Chanel"))
            {
                statePanelControl = StatePanelControl.NotificationsChanel;
            }

            if (GUILayout.Button("Scripting Define Symbols"))
            {
                statePanelControl = StatePanelControl.ScriptDefineSymbols;
            }

            if (GUILayout.Button("About"))
            {
                statePanelControl = StatePanelControl.About;
            }
        }

        void DrawContent()
        {
            switch (statePanelControl)
            {
                case StatePanelControl.Advertising:
                    OnDrawAdvertising();
                    break;
                case StatePanelControl.InAppPurchase:
                    OnDrawIap();
                    break;
                case StatePanelControl.AssetsUsageDetector:
                    OnDrawAssetUsageDetector();
                    break;
                case StatePanelControl.Audio:
                    OnDrawAudio();
                    break;
                case StatePanelControl.Pools:
                    OnDrawPools();
                    break;
                case StatePanelControl.InAppReview:
                    OnDrawInAppReview();
                    break;
                case StatePanelControl.LevelEditor:
                    OnDrawLevelEditor();
                    break;
                case StatePanelControl.NotificationsChanel:
                    OnDrawNotificationChanel();
                    break;
                case StatePanelControl.SO_Event:
                    OnDrawSoEvent();
                    break;
                case StatePanelControl.SO_Variable:
                    OnDrawSoVariable();
                    break;
                case StatePanelControl.ScriptDefineSymbols:
                    OnDrawScriptDefineSymbols();
                    break;
                case StatePanelControl.About:
                    OnDrawAbout();
                    break;
            }
        }

        #region Draw Content Details

        void OnDrawAdvertising()
        {
            GUILayout.Space(10);
            GUILayout.BeginVertical();
            GUILayout.Label("ADVERTISING", EditorStyles.boldLabel);
            GUILayout.Space(10);
            if (GUILayout.Button("Open AdSetting (Alt+4 / Option+4)"))
            {
                AdsWindowEditor.OpenAdSettingsWindows();
            }

            GUILayout.Space(10);
            Handles.DrawAAPolyLine(3, new Vector3(210, GUILayoutUtility.GetLastRect().y + 10),
                new Vector3(position.width, GUILayoutUtility.GetLastRect().y + 10));
            GUILayout.Space(10);
            isFieldMax = GUILayout.Toggle(isFieldMax, "Max");
            if (isFieldMax)
            {
                if (GUILayout.Button("Create Max Client"))
                {
                    AdsWindowEditor.CreateMaxClient();
                }

                if (GUILayout.Button("Create Max Banner"))
                {
                    AdsWindowEditor.CreateMaxBanner();
                }

                if (GUILayout.Button("Create Max Inter"))
                {
                    AdsWindowEditor.CreateMaxInter();
                }

                if (GUILayout.Button("Create Max Reward"))
                {
                    AdsWindowEditor.CreateMaxReward();
                }

                if (GUILayout.Button("Create Max Reward Inter"))
                {
                    AdsWindowEditor.CreateMaxRewardInter();
                }

                if (GUILayout.Button("Create Max App Open"))
                {
                    AdsWindowEditor.CreateMaxAppOpen();
                }
            }

            GUILayout.Space(10);
            Handles.DrawAAPolyLine(3, new Vector3(210, GUILayoutUtility.GetLastRect().y + 10),
                new Vector3(position.width, GUILayoutUtility.GetLastRect().y + 10));
            GUILayout.Space(10);
            isFielAdmob = GUILayout.Toggle(isFielAdmob, "Admob");
            if (isFielAdmob)
            {
                if (GUILayout.Button("Create Admob Client"))
                {
                    AdsWindowEditor.CreateAdmobClient();
                }

                if (GUILayout.Button("Create Admob Banner"))
                {
                    AdsWindowEditor.CreateAdmobBanner();
                }

                if (GUILayout.Button("Create Admob Inter"))
                {
                    AdsWindowEditor.CreateAdmobInter();
                }

                if (GUILayout.Button("Create Admob Reward"))
                {
                    AdsWindowEditor.CreateAdmobReward();
                }

                if (GUILayout.Button("Create Admob Reward Inter"))
                {
                    AdsWindowEditor.CreateAdmobRewardInter();
                }

                if (GUILayout.Button("Create Admob App Open"))
                {
                    AdsWindowEditor.CreateAdmobAppOpen();
                }
            }

            GUILayout.EndVertical();
        }

        void OnDrawIap()
        {
            GUILayout.Space(10);
            GUILayout.BeginVertical();
            GUILayout.Label("IN APP PURCHASE", EditorStyles.boldLabel);
            GUILayout.Space(10);
            if (GUILayout.Button("Open AdSetting (Alt+2 / Option+2)"))
            {
#if VIRTUESKY_IAP
                IapWindowEditor.OpenIapSettingsWindows();

#else
                Debug.LogError("Add scripting define symbols ( VIRTUESKY_IAP ) to use IAP");
#endif
            }

            if (GUILayout.Button("Create Iap Purchase Product Event"))
            {
#if VIRTUESKY_IAP
                IapWindowEditor.CreateIapProductEvent();

#else
                Debug.LogError("Add scripting define symbols ( VIRTUESKY_IAP ) to use IAP");
#endif
            }

            if (GUILayout.Button("Create Iap Purchase Product Event"))
            {
#if VIRTUESKY_IAP
                IapWindowEditor.CreateIsPurchaseProductEvent();

#else
                Debug.LogError("Add scripting define symbols ( VIRTUESKY_IAP ) to use IAP");
#endif
            }

            GUILayout.EndVertical();
        }

        void OnDrawAssetUsageDetector()
        {
            GUILayout.Space(10);
            GUILayout.BeginVertical();
            GUILayout.Label("ASSET USAGE DETECTOR", EditorStyles.boldLabel);
            GUILayout.Space(10);
            if (GUILayout.Button("Active Window"))
            {
                AssetUsageDetectorWindow.OpenActiveWindow();
            }

            if (GUILayout.Button("New Window"))
            {
                AssetUsageDetectorWindow.OpenNewWindow();
            }

            GUILayout.EndVertical();
        }

        void OnDrawAudio()
        {
            GUILayout.Space(10);
            GUILayout.BeginVertical();
            GUILayout.Label("AUDIO", EditorStyles.boldLabel);
            GUILayout.Space(10);
            if (GUILayout.Button("Create Event Audio Handle"))
            {
                AudioWindowEditor.CreateEventAudioHandle();
            }

            if (GUILayout.Button("Create Sound Data"))
            {
                AudioWindowEditor.CreateSoundData();
            }

            GUILayout.EndVertical();
        }

        void OnDrawPools()
        {
            GUILayout.Space(10);
            GUILayout.BeginVertical();
            GUILayout.Label("POOLS", EditorStyles.boldLabel);
            GUILayout.Space(10);
            if (GUILayout.Button("Create Pools"))
            {
                PoolWindowEditor.CreatePools();
            }

            GUILayout.EndVertical();
        }

        void OnDrawInAppReview()
        {
            GUILayout.Space(10);
            GUILayout.BeginVertical();
            GUILayout.Label("IN APP REVIEW", EditorStyles.boldLabel);
            GUILayout.Space(10);
            if (GUILayout.Button("Create In App Review"))
            {
                RatingWindowEditor.CreateInAppReview();
            }

            GUILayout.EndVertical();
        }

        void OnDrawLevelEditor()
        {
            GUILayout.Space(10);
            GUILayout.BeginVertical();
            GUILayout.Label("LEVEL EDITOR", EditorStyles.boldLabel);
            GUILayout.Space(10);
            if (GUILayout.Button("Open Level Editor (Alt+3 / Option+3)"))
            {
                UtilitiesLevelSystemDrawer.OpenLevelEditor();
            }

            GUILayout.EndVertical();
        }

        void OnDrawNotificationChanel()
        {
            GUILayout.Space(10);
            GUILayout.BeginVertical();
            GUILayout.Label("NOTIFICATION CHANEL", EditorStyles.boldLabel);
            GUILayout.Space(10);
            if (GUILayout.Button("Create Notification Chanel"))
            {
                NotificationWindowEditor.CreateNotificationChannel();
            }

            GUILayout.EndVertical();
        }

        void OnDrawSoEvent()
        {
            GUILayout.Space(10);
            GUILayout.BeginVertical();
            GUILayout.Label("SCRIPTABLE OBJECT EVENT", EditorStyles.boldLabel);
            GUILayout.Space(10);
            if (GUILayout.Button("Create Boolean Event"))
            {
                EventWindowEditor.CreateEventBoolean();
            }

            if (GUILayout.Button("Create Dictionary Event"))
            {
                EventWindowEditor.CreateEventDictionary();
            }

            if (GUILayout.Button("Create No Param Event"))
            {
                EventWindowEditor.CreateEventNoParam();
            }

            if (GUILayout.Button("Create Float Event"))
            {
                EventWindowEditor.CreateEventFloat();
            }

            if (GUILayout.Button("Create Int Event"))
            {
                EventWindowEditor.CreateEventInt();
            }

            if (GUILayout.Button("Create Object Event"))
            {
                EventWindowEditor.CreateEventObject();
            }

            if (GUILayout.Button("Create Short Double Event"))
            {
                EventWindowEditor.CreateEventShortDouble();
            }

            if (GUILayout.Button("Create String Event"))
            {
                EventWindowEditor.CreateEventString();
            }

            if (GUILayout.Button("Create Vector3 Event"))
            {
                EventWindowEditor.CreateEventVector3();
            }

            GUILayout.EndVertical();
        }

        void OnDrawSoVariable()
        {
            GUILayout.Space(10);
            GUILayout.BeginVertical();
            GUILayout.Label("SCRIPTABLE OBJECT VARIABLE", EditorStyles.boldLabel);
            GUILayout.Space(10);
            if (GUILayout.Button("Create Boolean Variable"))
            {
                VariableWindowEditor.CreateVariableBoolean();
            }

            if (GUILayout.Button("Create Float Variable"))
            {
                VariableWindowEditor.CreateVariableFloat();
            }

            if (GUILayout.Button("Create Int Variable"))
            {
                VariableWindowEditor.CreateVariableInt();
            }

            if (GUILayout.Button("Create Object Variable"))
            {
                VariableWindowEditor.CreateVariableObject();
            }

            if (GUILayout.Button("Create Rect Variable"))
            {
                VariableWindowEditor.CreateVariableRect();
            }

            if (GUILayout.Button("Create Short Double Variable"))
            {
                VariableWindowEditor.CreateVariableShortDouble();
            }

            if (GUILayout.Button("Create String Variable"))
            {
                VariableWindowEditor.CreateVariableString();
            }

            if (GUILayout.Button("Create Transform Variable"))
            {
                VariableWindowEditor.CreateVariableTransform();
            }

            if (GUILayout.Button("Create Vector3 Variable"))
            {
                VariableWindowEditor.CreateVariableVector3();
            }

            GUILayout.EndVertical();
        }

        void OnDrawScriptDefineSymbols()
        {
            GUILayout.Space(10);
            GUILayout.BeginVertical();
            GUILayout.Label("SCRIPTING DEFINE SYMBOLS", EditorStyles.boldLabel);
            GUILayout.Space(10);

            #region flag ads

            GUILayout.BeginHorizontal();
            if (GUILayout.Button("VIRTUESKY_ADS", GUILayout.Width(400)))
            {
                EditorScriptDefineSymbols.AdsConfigFlag();
            }

            GUILayout.Space(10);
            GUILayout.Toggle(EditorScriptDefineSymbols.IsAdsFlag(),
                TextIsEnable(EditorScriptDefineSymbols.IsAdsFlag()));
            GUILayout.EndHorizontal();

            #endregion

            #region flag applovin

            GUILayout.BeginHorizontal();
            if (GUILayout.Button("ADS_APPLOVIN", GUILayout.Width(400)))
            {
                EditorScriptDefineSymbols.ApplovinConfigFlag();
            }

            GUILayout.Space(10);
            GUILayout.Toggle(EditorScriptDefineSymbols.IsApplovinFlag(),
                TextIsEnable(EditorScriptDefineSymbols.IsApplovinFlag()));
            GUILayout.EndHorizontal();

            #endregion

            #region flag admob

            GUILayout.BeginHorizontal();
            if (GUILayout.Button("ADS_ADMOB", GUILayout.Width(400)))
            {
                EditorScriptDefineSymbols.AdmobConfigFlag();
            }

            GUILayout.Space(10);
            GUILayout.Toggle(EditorScriptDefineSymbols.IsAdmobFlag(),
                TextIsEnable(EditorScriptDefineSymbols.IsAdmobFlag()));
            GUILayout.EndHorizontal();

            #endregion

            #region flag adjust

            GUILayout.BeginHorizontal();
            if (GUILayout.Button("VIRTUESKY_ADJUST", GUILayout.Width(400)))
            {
                EditorScriptDefineSymbols.AdjustConfigFlag();
            }

            GUILayout.Space(10);
            GUILayout.Toggle(EditorScriptDefineSymbols.IsAdjustFlag(),
                TextIsEnable(EditorScriptDefineSymbols.IsAdjustFlag()));
            GUILayout.EndHorizontal();

            #endregion

            #region flag firebase app

            GUILayout.BeginHorizontal();
            if (GUILayout.Button("VIRTUESKY_FIREBASE", GUILayout.Width(400)))
            {
                EditorScriptDefineSymbols.FirebaseAppConfigFlag();
            }

            GUILayout.Space(10);
            GUILayout.Toggle(EditorScriptDefineSymbols.IsFirebaseAppFlag(),
                TextIsEnable(EditorScriptDefineSymbols.IsFirebaseAppFlag()));
            GUILayout.EndHorizontal();

            #endregion

            #region flag analytic

            GUILayout.BeginHorizontal();
            if (GUILayout.Button("VIRTUESKY_FIREBASE_ANALYTIC", GUILayout.Width(400)))
            {
                EditorScriptDefineSymbols.AnalyticConfigFlag();
            }

            GUILayout.Space(10);
            GUILayout.Toggle(EditorScriptDefineSymbols.IsAnalyticFlag(),
                TextIsEnable(EditorScriptDefineSymbols.IsAnalyticFlag()));
            GUILayout.EndHorizontal();

            #endregion

            #region Flag Remote Config

            GUILayout.BeginHorizontal();
            if (GUILayout.Button("VIRTUESKY_FIREBASE_REMOTECONFIG", GUILayout.Width(400)))
            {
                EditorScriptDefineSymbols.RemoteConfigConfigFlag();
            }

            GUILayout.Space(10);
            GUILayout.Toggle(EditorScriptDefineSymbols.IsRemoteConfigConfigFlag(),
                TextIsEnable(EditorScriptDefineSymbols.IsRemoteConfigConfigFlag()));
            GUILayout.EndHorizontal();

            #endregion

            #region flag iap

            GUILayout.BeginHorizontal();
            if (GUILayout.Button("VIRTUESKY_IAP", GUILayout.Width(400)))
            {
                EditorScriptDefineSymbols.IapConfigFlag();
            }

            GUILayout.Space(10);
            GUILayout.Toggle(EditorScriptDefineSymbols.IsIapFlag(),
                TextIsEnable(EditorScriptDefineSymbols.IsIapFlag()));
            GUILayout.EndHorizontal();

            #endregion

            #region flag ratting

            GUILayout.BeginHorizontal();
            if (GUILayout.Button("VIRTUESKY_RATING", GUILayout.Width(400)))
            {
                EditorScriptDefineSymbols.RattingConfigFlag();
            }

            GUILayout.Space(10);
            GUILayout.Toggle(EditorScriptDefineSymbols.IsRattingFlag(),
                TextIsEnable(EditorScriptDefineSymbols.IsRattingFlag()));
            GUILayout.EndHorizontal();

            #endregion

            #region flag notifications

            GUILayout.BeginHorizontal();
            if (GUILayout.Button("VIRTUESKY_NOTIFICATION", GUILayout.Width(400)))
            {
                EditorScriptDefineSymbols.NotificationConfigFlag();
            }

            GUILayout.Space(10);
            GUILayout.Toggle(EditorScriptDefineSymbols.IsNotificationFlag(),
                TextIsEnable(EditorScriptDefineSymbols.IsNotificationFlag()));
            GUILayout.EndHorizontal();

            #endregion

            GUILayout.EndVertical();
        }

        void OnDrawAbout()
        {
            GUILayout.Space(10);
            GUILayout.BeginVertical();
            GUILayout.Label("ABOUT", EditorStyles.boldLabel);
            GUILayout.Space(10);
            GUILayout.TextArea("Name: Sunflower", EditorStyles.boldLabel);
            GUILayout.TextArea("Description: Core ScriptableObject architecture for building Unity games",
                EditorStyles.boldLabel);
            GUILayout.TextArea("Version: 2.3.1", EditorStyles.boldLabel);
            GUILayout.TextArea("Author: VirtueSky", EditorStyles.boldLabel);
            GUILayout.Space(10);
            if (GUILayout.Button("Open Repo Github"))
            {
                Application.OpenURL("https://github.com/VirtueSky/sunflower");
            }

            if (GUILayout.Button("Document"))
            {
                Application.OpenURL("https://github.com/VirtueSky/sunflower/wiki");
            }

            Handles.DrawAAPolyLine(3, new Vector3(210, 195), new Vector3(position.width, 195));
            GUILayout.Space(20);
            GUILayout.Label("SETUP THEME", EditorStyles.boldLabel);
            GUILayout.Space(10);
            ColorContent = (CustomColor)EditorGUILayout.EnumPopup("Color Content:", ColorContent);
            ColorTextContent = (CustomColor)EditorGUILayout.EnumPopup("Color Text Content:", ColorTextContent);
            ColorBackgroundRect = (CustomColor)EditorGUILayout.EnumPopup("Color Background:", ColorBackgroundRect);
            GUILayout.Space(10);
            if (GUILayout.Button("Theme Default"))
            {
                ColorContent = CustomColor.LightRed;
                ColorTextContent = CustomColor.Gold;
                ColorBackgroundRect = CustomColor.DarkSlateGray;
            }

            GUILayout.EndVertical();
        }

        #endregion

        void GuiLine(int i_height, Color colorLine)
        {
            Rect rect = EditorGUILayout.GetControlRect(false, i_height);

            rect.height = i_height;

            EditorGUI.DrawRect(rect, colorLine);
        }

        string TextIsEnable(bool condition)
        {
            return condition ? "Enable" : "Disable";
        }

        private CustomColor ColorContent
        {
            get => (CustomColor)EditorPrefs.GetInt("ColorContent_ControlPanel", (int)CustomColor.LightRed);
            set => EditorPrefs.SetInt("ColorContent_ControlPanel", (int)value);
        }

        private CustomColor ColorTextContent
        {
            get => (CustomColor)EditorPrefs.GetInt("ColorTextContent_ControlPanel", (int)CustomColor.Gold);
            set => EditorPrefs.SetInt("ColorTextContent_ControlPanel", (int)value);
        }

        private CustomColor ColorBackgroundRect
        {
            get => (CustomColor)EditorPrefs.GetInt("ColorBackground_ControlPanel", (int)CustomColor.DarkSlateGray);
            set => EditorPrefs.SetInt("ColorBackground_ControlPanel", (int)value);
        }
    }

    public enum StatePanelControl
    {
        Advertising,
        InAppPurchase,
        AssetsUsageDetector,
        Audio,
        Pools,
        InAppReview,
        LevelEditor,
        NotificationsChanel,
        SO_Event,
        SO_Variable,
        ScriptDefineSymbols,
        About,
    }
}