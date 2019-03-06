﻿#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using MonsterRedactor;
using Resource;
using Items;

namespace OpenWorld
{
    public class WindowSetting
    {
        private static Map editMap;
        private static int _areaViseble = 1;
        private static MonstersList _monstersList;
        private static WorldMonstersList _worldMonstrList;
        private static ResourceList _resourceList;
        private static WorldResourcesList _worldResourcesList;
        private static MachineList _machineList;
        private static ItemsList _itemsList;

        public static Map Map{get{return editMap; } }
        public static int areaVisible { get { return _areaViseble; } }
        public static MonstersList monstersList { get { return _monstersList; } }
        public static WorldMonstersList WorldMonsterList { get { return _worldMonstrList; } }
        public static ResourceList ResourcesList { get { return _resourceList; } }
        public static WorldResourcesList WorldResourcesList { get { return _worldResourcesList; } }
        public static MachineList MachineList { get { return _machineList; } }
        public static ItemsList ItemsList { get { return _itemsList; } }


        private static Map dontSaveMap;
        private static int dontSaveAreaVisible;
        private static MonstersList dontSaveMonstersList;
        private static WorldMonstersList dontSaveWorldMonsterList;
        private static ResourceList dontSaveResourcesList;
        private static WorldResourcesList dontSaveWorldResourceList;
        private static MachineList dontSaveMachineList;
        private static ItemsList dontSaveItemsList;

        public static void Draw()
        {


            GUILayout.Space(15.0f);
            dontSaveAreaVisible = EditorGUILayout.IntSlider("Зона видимости: ", dontSaveAreaVisible, 1, 10);



            GUILayout.Space(15.0f);
            GUILayout.Label("Карта для редактирования"); GUILayout.Space(5.0f);
            dontSaveMap = EditorGUILayout.ObjectField(dontSaveMap, typeof(Map), false) as Map;

            GUILayout.Space(15.0f);
            GUILayout.Label("Список монстров"); GUILayout.Space(5.0f);
            dontSaveMonstersList = EditorGUILayout.ObjectField(dontSaveMonstersList, typeof(MonstersList), false) as MonstersList;

            GUILayout.Space(15.0f);
            GUILayout.Label("Список монстров закрепленых на карте"); GUILayout.Space(5.0f);
            dontSaveWorldMonsterList = EditorGUILayout.ObjectField(dontSaveWorldMonsterList, typeof(WorldMonstersList), false) as WorldMonstersList;

            GUILayout.Space(15.0f);
            GUILayout.Label("Список ресурсов"); GUILayout.Space(5.0f);
            dontSaveResourcesList = EditorGUILayout.ObjectField(dontSaveResourcesList, typeof(ResourceList), false) as ResourceList;

            GUILayout.Space(15.0f);
            GUILayout.Label("Список ресурсов закрепленых на карте"); GUILayout.Space(5.0f);
            dontSaveWorldResourceList = EditorGUILayout.ObjectField(dontSaveWorldResourceList, typeof(WorldResourcesList), false) as WorldResourcesList;

            GUILayout.Space(15.0f);
            GUILayout.Label("Список станков закрепленых на карте"); GUILayout.Space(5.0f);
            dontSaveMachineList = EditorGUILayout.ObjectField(dontSaveMachineList, typeof(MachineList), false) as MachineList;

            GUILayout.Space(15.0f);
            GUILayout.Label("Список предметов"); GUILayout.Space(5.0f);
            dontSaveItemsList = EditorGUILayout.ObjectField(dontSaveItemsList, typeof(ItemsList), false) as ItemsList;

            GUILayout.Space(20.0f);
            GUI.enabled = dontSaveAreaVisible != _areaViseble || dontSaveMap != editMap || dontSaveMonstersList != _monstersList || dontSaveWorldMonsterList != _worldMonstrList || dontSaveResourcesList != _resourceList
                || _worldResourcesList != dontSaveWorldResourceList || _machineList != dontSaveMachineList || _itemsList != dontSaveItemsList;
            if (GUILayout.Button("Save"))
            {
                _areaViseble = dontSaveAreaVisible;
                PlayerPrefs.SetInt("EditAreaVisible", _areaViseble);

                editMap = dontSaveMap;
                string pathToPrefab = AssetDatabase.GetAssetPath(editMap);
                PlayerPrefs.SetString("editMapPath", pathToPrefab);

                _monstersList = dontSaveMonstersList;
                pathToPrefab = AssetDatabase.GetAssetPath(_monstersList);
                PlayerPrefs.SetString("editMonsterList", pathToPrefab);

                _worldMonstrList = dontSaveWorldMonsterList;
                pathToPrefab = AssetDatabase.GetAssetPath(_worldMonstrList);
                PlayerPrefs.SetString("editWorldMonsterList", pathToPrefab);

                _resourceList = dontSaveResourcesList;
                pathToPrefab = AssetDatabase.GetAssetPath(_resourceList);
                PlayerPrefs.SetString("editResourcesList", pathToPrefab);

                _worldResourcesList = dontSaveWorldResourceList;
                pathToPrefab = AssetDatabase.GetAssetPath(_worldResourcesList);
                PlayerPrefs.SetString("editWorldResourcesList", pathToPrefab);

                _machineList = dontSaveMachineList;
                pathToPrefab = AssetDatabase.GetAssetPath(_machineList);
                PlayerPrefs.SetString("editMachineList", pathToPrefab);

                _itemsList = dontSaveItemsList;
                Project.ItemsList = _itemsList;

                WindowOpenWorld.ReloadMap();
            }
            GUI.enabled = true;
        }

        public static void Load()
        {
            string path = PlayerPrefs.GetString("editMapPath");
            editMap = AssetDatabase.LoadAssetAtPath<Map>(path);
            dontSaveMap = editMap;

            _areaViseble = PlayerPrefs.GetInt("EditAreaVisible", 1);
            dontSaveAreaVisible = _areaViseble;

            path = PlayerPrefs.GetString("editMonsterList");
            _monstersList = AssetDatabase.LoadAssetAtPath<MonstersList>(path);
            dontSaveMonstersList = _monstersList;

            path = PlayerPrefs.GetString("editWorldMonsterList");
            _worldMonstrList = AssetDatabase.LoadAssetAtPath<WorldMonstersList>(path);
            dontSaveWorldMonsterList = _worldMonstrList;


            path = PlayerPrefs.GetString("editResourcesList");
            _resourceList = AssetDatabase.LoadAssetAtPath<ResourceList>(path);
            dontSaveResourcesList = _resourceList;

            path = PlayerPrefs.GetString("editWorldResourcesList");
            _worldResourcesList = AssetDatabase.LoadAssetAtPath<WorldResourcesList>(path);
            dontSaveWorldResourceList = _worldResourcesList;

            path = PlayerPrefs.GetString("editMachineList");
            _machineList = AssetDatabase.LoadAssetAtPath<MachineList>(path);
            dontSaveMachineList = _machineList;

            dontSaveItemsList = _itemsList = Project.ItemsList;

        }
    }
}
#endif