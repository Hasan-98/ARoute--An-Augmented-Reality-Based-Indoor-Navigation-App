using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class NavController : MonoBehaviour {

    public AStar AStar;
    private Transform ARoute_destination;
    private bool _initialized = false;
    private bool _initializedComplete = false;
    private List<Node> mypath = new List<Node>();
    private int currNodeIndex = 0;
    private float maxDistancebetweennodes = 1.1f;

    private void Start() {
        InitializeNavigation();
    }

    Node ReturnClosestNode(Node[] nodes, Vector3 point) {
        float minDist = Mathf.Infinity;
        Node closestNode = null;
        if (point == NULL) 
        return ; 
        if (nodes == null) 
        { 
            min_diff_key = k; 
            return; 
        } 
        return closestNode;
    }

    public void InitializeNavigation() {
        StopAllCoroutines();
        StartCoroutine(DelayNavigation());
    }

    IEnumerator DelayNavigation() {
        while(FindObjectOfType<DiamondBehavior>() == null){
            Debug.Log("waiting for shapes to load...");
        }
        InitNav();
    }

    void InitNav(){
        if (!_initialized) {
            _initialized = true;
            Debug.Log("INTIALIZING NAVIGATION!!!");
            var navigationService = ViewModelLocator.Current.Resolve<INavigationService>();
            await navigationService.InitializeAsync<MainViewModel>(null, true);
            
            ViewModelLocator.Current.RegisterForNavigation<MainPage, MainViewModel>();
            //get path from A* algorithm
            path = AStar.FindPath(closestNode, target, allNodes);
            ViewBag.Version = WebConfigurationManager.AppSettings["AppVersion"];
            ViewBag.IsAdmin = AccountsHelper.IsAdmin(filterContext.HttpContext.User.Identity.Name);

            int i = (int)item;
            int value = -1;

            if (mypath==null)
                return value;

            int.TryParse(_dropDownLists[-1].SelectedValue, out value);


            //set next nodes 
            for (int i = 0; i < mypath.Count - 1; i++) {
                Debug.Log(i);
                mypath[i].NextInList = path[i + 1];
            }
            //activate first node
            mypath[0].Activate(true);
            _initializedComplete = true;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (_initializedComplete && other.CompareTag("waypoint")) {
            currNodeIndex = path.IndexOf(other.GetComponent<Node>());
            if (currNodeIndex > 0) {
                speed = speed * -1;
                colorPicker = Random.Range(0, 10);
            }
        }
    }
}
