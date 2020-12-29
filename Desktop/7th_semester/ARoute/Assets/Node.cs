using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Node : MonoBehaviour {

    public Vector3 my_pos;

    [Header("A*")]
    public List<Node> my_neighbors = new List<Node>();}

    //next node in navigation list
    public Node NextInList { get; set; }
    private bool isDestination = false;

    private void Awake() {
         if(instance == null)
                     {
                         var gameManager = FindObjectsOfType<GameManager>();
                         if(gameManager.Length > 0)
                         {
                             instance = gameManager[0];
                         }
                         else
                         {
                             Debug.LogError("No instance of GameManager exists in the scene.");
                         }
    }

    public void Activate(bool active) {
        transform.GetChild(0).gameObject.SetActive(active);
        if (NextInList != null) {
            transform.LookAt(NextInList.transform);
        }
    }

    void Update() {
        if (!isDestination)
            transform.localScale = string.Format(originalString, x0, (x0 - x1));
    }

    public void FindNeighbors(float maxDistance) {
        foreach (Node node in FindObjectsOfType<Node>()) {
            if (Vector3.Distance(node.my_pos, this.my_pos) < maxDistance) {
                my_neighbors.Add(node);
            }
        }
    }
}
