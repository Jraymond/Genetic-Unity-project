using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner_script : MonoBehaviour {

    public GameObject bouncy_sphere;
    public int number_of_spheres;
    public Text score_text;
    public Text generation;

    private PhysicMaterial material;
    private Vector3 localPOS;
    private List<GameObject> spheres;
    private GameObject temp_Obj;
    private bool scene_active;
    private int number_of_generations;


	// Use this for initialization
	void Start () {

        number_of_generations = 0;
        score_text.text = "Highest Score: ";
        spheres = new List<GameObject>();
        Genitic_sphere_spawn();

    }
	
	// Update is called once per frame
	void Update () {


    }

    /// <summary>
    /// Watches the scene to make sure that scoring method is not called until all objects have stopped moving
    /// </summary>
    /// <returns>void</returns>
    IEnumerator wait()
    {
        while (scene_active)
        {
            foreach (GameObject sphere in spheres)
            {
                if (!sphere.GetComponent<Rigidbody>().IsSleeping())
                {
                    scene_active = true;
                    break;
                }
                else
                    scene_active = false;
            }
            yield return new WaitForSeconds(2);
        }
        if (!scene_active)
            scoring();
    }
    /// <summary>
    /// scores each object by how long they have been moving since they spawned
    /// </summary>
    void scoring()
    {
        StopCoroutine(wait());
        temp_Obj = spheres[0];

        foreach (GameObject sphere in spheres)
        {
            if (sphere.GetComponent<Sphere_script>().score != 0)
            {
                if (temp_Obj.GetComponent<Sphere_script>().score <= sphere.GetComponent<Sphere_script>().score)
                    temp_Obj = sphere;
            }
            Destroy(sphere);
        }
        score_text.text = "Highest score: " + temp_Obj.GetComponent<Sphere_script>().score.ToString();
        spheres.Clear();
        Genitic_sphere_spawn(temp_Obj);
    }
    /// <summary>
    /// spawns the general objects for the program.
    /// contains the mutators
    /// </summary>
    void Genitic_sphere_spawn(){

        scene_active = true;
        generation.text = "Generation " + number_of_generations.ToString();

        localPOS = this.transform.localPosition;
        int x = 0;

        while (x < number_of_spheres)
        {
            spheres.Add((GameObject)Instantiate(bouncy_sphere, localPOS + new Vector3(x*1.5f, 0, x*(-1)), transform.rotation));
            x++;
        };

        foreach (GameObject sphere in spheres)
        {
            //This is the mutator. changing these variabls affects how the next generation spawns
            material = new PhysicMaterial
            {
                dynamicFriction = Random.Range(0.0f, 1.0f),
                staticFriction = Random.Range(0.0f, 1.0f),
                bounciness = Random.Range(0.0f, 1.0f)
                
            };
            sphere.GetComponent<SphereCollider>().material = material;
        }
        number_of_generations++;
        StartCoroutine(wait());
    }
    /// <summary>
    /// respawns the top fittest object, according to the scoring method.
    /// </summary>
    /// <param name="obj"></param>
    void Genitic_sphere_spawn(GameObject obj)
    {
        
        obj.GetComponent<Renderer>().material.color = Color.cyan;

        spheres.Add((GameObject)Instantiate(obj));
        spheres[0].transform.position = new Vector3(obj.transform.localPosition.x, localPOS.y,localPOS.z - 11);

        Genitic_sphere_spawn();
    }

}
