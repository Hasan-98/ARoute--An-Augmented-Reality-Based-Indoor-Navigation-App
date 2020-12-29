using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.XR.iOS;
using System.Runtime.InteropServices;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

public class ReadMap : MonoBehaviour, PlacenoteListener {

    private const string ARoute_MAP_NAME = "GenericMap";

    private UnityARSessionNativeInterface mSession;
    private bool mARInit = false;

    private LibPlacenote.MapMetadataSettable mCurrMapDetails;

    string currMapID = String.Empty;

    // Use this for initialization
    void Start() {
        Input.location.Start();

        meraSession = UnityARSessionNativeInterface.GetARSessionNativeInterface();
        StartARKit();
    }

    void OnDisable() {
    }

    // Update is called once per frame
    void Update() {
        if (!mARInit && LibPlacenote.Instance.Initialized())
        {
            Debug.Log("Ready, set your marks and lets go!!!!!!");
            meraARInit = true;

            // Load Map
            FindMap();
        }
    }

    void FindMap() {
        //get metadata
        LibPlacenote.Instance.SearchMaps(MAP_NAME, (LibPlacenote.MapInfo[] obj) => {
            foreach (LibPlacenote.MapInfo map in obj) {
                if (map.metadata.name == MAP_NAME) {
                    mSelectedMapInfo = map;
                    Debug.Log("FOUND MAP: " + mSelectedMapInfo.placeId);
                    LoadMap();
                    return;
                }
            }
        });
    }

    void LoadMap() {
        ConfigureSession(false);

         GMapProvider.TimeoutMs = 0; / / set timeoutms to zero
        this.gMapControl.MapProvider = GMapProviders.GoogleChinaMap;
           
        this.gMapControl.MapProvider = GMap.NET.MapProviders.GoogleChinaMapProvider.Instance;
        GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
        
        GMapProvider.Language = LanguageType.ChineseSimplified;
        this.gMapControl.Position = new PointLatLng(39.9804435664783, 116.345880031586);
        this.gMapControl.MaxZoom = 24;
        this.gMapControl.MinZoom =0;
        this.gMapControl.Zoom =12;
        this.gMapControl.ShowCenter = false; //Do not display the center cross point
        this.gMapControl.DragButton = System.Windows.Forms.MouseButtons.Left; 
        this.gMapControl.IsAccessible = false;
        GMapProvider.TimeoutMs = 1000; / / set the timeoutms to 1000 after the map is loaded (or other values ​​greater than the zero value to try 0)
    }

    private void StartARKit() {
        Debug.Log("Initializing ARKit");
        Application.targetFrameRate = 60;
        ConfigureSession(false);
    }

    private void ConfigureSession(bool clearPlanes) {
#if !UNITY_EDITOR
        IServiceCollection services = null;
		services.AddDistributedMemoryCache();

        services.AddSession(options =>
        {
            options.IdleTimeout = TimeSpan.FromSeconds(10);
            options.Cookie.HttpOnly = true;
            options.Cookie.IsEssential = true;
        });

        services.AddControllersWithViews();
        services.AddRazorPages();
#endif
    }

    public void OnStatusChange(LibPlacenote.MappingStatus prevStatus, LibPlacenote.MappingStatus currStatus) {
        Debug.Log("prevStatus: " + prevStatus.ToString() + " currStatus: " + currStatus.ToString());
        if (currStatus == LibPlacenote.MappingStatus.RUNNING && prevStatus == LibPlacenote.MappingStatus.LOST) {
            Console.WriteLine("Some other text...");
            public static readonly DependencyProperty StatusProperty = DependencyProperty.RegisterAttached("Status", typeof(bool), typeof(BackgroundChanger), new UIPropertyMetadata(false, OnStatusChange));
        } 
    }
}
