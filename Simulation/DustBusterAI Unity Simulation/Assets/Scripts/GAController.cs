using System.Threading;
using GeneticSharp.Domain;
using GeneticSharp.Domain.Crossovers;
using GeneticSharp.Domain.Mutations;
using GeneticSharp.Domain.Populations;
using GeneticSharp.Domain.Selections;
using GeneticSharp.Domain.Terminations;
using GeneticSharp.Infrastructure.Framework.Threading;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class GAController : MonoBehaviour
{
    private GeneticAlgorithm m_ga;
    private Thread m_gaThread;

    public int m_numberOfCities = 20;
    public Object CityPrefab;

    //private System.Collections.Generic.IList<TspCity> Cities;
    public List<GameObject> citiesGO;
    public GameObject target;
    public GameObject robot;
    public GameObject plane;

    private bool m_isEnabled = false;
    public enum Mode { Random, Ordered }

    public Mode mode;

    [Header("Area discretization")]
    [SerializeField]
    int disc_interval;

    public Transform CityParent;

    public GameObject Obstacles;

    private LineRenderer m_lr;

    List<ObstacleManager> obsManagers;
    private void Awake()
    {
        target.transform.position = robot.transform.position;
        
    }
    private void Start()
    {
        

        //Cities = DrawCities();
        //FillObsManager();
        Invoke("FillObsManager", .2f);
        Invoke("LateStart", .3f);

    }

    void FillObsManager()
    {
        obsManagers = new List<ObstacleManager>();

        foreach (var obsManager in Obstacles.GetComponentsInChildren<ObstacleManager>())
        {
            obsManagers.Add(obsManager);

            //foreach (var item in obsManager.bounds)
            //{
            //    //print(item);
            //}
        }
        obsManagers.RemoveAt(0);
        print(obsManagers.Count);

        foreach (var obsManager in obsManagers)
        {
            foreach (var bound in obsManager.bounds)
            {
                print(bound.ToString());
            }
            print("\n");
        }
    }
    void LateStart()
    {
        List<Vector3> points = new List<Vector3>();

        if (mode == Mode.Ordered)
        {
            Vector3 planeSize = plane.GetComponent<Renderer>().bounds.size;
            Vector3 planePosition = plane.transform.position;
            points = DiscretizePlane(planeSize, planePosition, disc_interval);
            m_numberOfCities = points.Count;
        }

        m_lr = GetComponent<LineRenderer>();
        m_lr.positionCount = m_numberOfCities + 1;

        var fitness = new TspFitness(m_numberOfCities, plane, robot, mode.ToString(), points);
        var chromosome = new TspChromosome(m_numberOfCities);

        // This operators are classic genetic algorithm operators that lead to a good solution on TSP,
        // but you can try others combinations and see what result you get.
        var crossover = new OrderedCrossover();
        var mutation = new ReverseSequenceMutation();
        var selection = new RouletteWheelSelection();
        var population = new Population(50, 100, chromosome);

        m_ga = new GeneticAlgorithm(population, fitness, selection, crossover, mutation);
        m_ga.Termination = new TimeEvolvingTermination(System.TimeSpan.FromHours(1));

        // The fitness evaluation of whole population will be running on parallel.
        m_ga.TaskExecutor = new ParallelTaskExecutor
        {
            MinThreads = 100,
            MaxThreads = 200
        };

        // Everty time a generation ends, we log the best solution.
        m_ga.GenerationRan += delegate
        {
            var distance = ((TspChromosome)m_ga.BestChromosome).Distance;
            //Debug.Log($"Generation: {m_ga.GenerationsNumber} - Distance: ${distance}");
        };

        DrawCities();

        // Starts the genetic algorithm in a separate thread.
        try
        {
            m_gaThread = new Thread(() => m_ga.Start());
            m_gaThread.Start();
            //StartCoroutine(LateStart(0f));
            //StartCoroutine(LateStart(0.2f));
        }

        catch
        {
            ;
        }
        InvokeRepeating("IterateOverTime", .2f, .1f);
        Invoke("CancelInvokeIteration", 15f);
        //DrawRoute();
        ////m_isEnabled = true;
        //target.transform.position = citiesGO[0].transform.position;
    }

    void IterateOverTime()
    {
        DrawRoute();
        
    }

    private void CancelInvokeIteration()
    {
        CancelInvoke("IterateOverTime");
        target.transform.position = citiesGO[0].transform.position;
        m_isEnabled = true;
    }

    private void OnDestroy()
    {
        // When the script is destroyed we stop the genetic algorithm and abort its thread too.
        m_ga.Stop();
        m_gaThread.Abort();
    }


    void DrawCities()
    {
        var cities = ((TspFitness)m_ga.Fitness).Cities;

        for (int i = 0; i < cities.Count; i++)
        {
            var city = cities[i];
            var go = Instantiate(CityPrefab, city.Position, Quaternion.identity) as GameObject;
            go.transform.SetParent(CityParent);
            citiesGO.Add(go);
            go.GetComponent<CityController>().Data = city;
            city.go = go;
            //go.GetComponentInChildren<TextMesh>().text = i.ToString();
            go.name = "City " + i;
        }

    }

    TspCity prevCity;
    List<TspCity> orderedCities;
    public void DrawRoute()
    {
        prevCity = new TspCity
        {
            next = null
        };
        var c = m_ga.Population.CurrentGeneration.BestChromosome as TspChromosome;

        if (c != null)
        {
            var genes = c.GetGenes();
            var cities = ((TspFitness)m_ga.Fitness).Cities;
            orderedCities = new List<TspCity>();

            for (int i = 0; i < genes.Length; i++)
            {
                var city = cities[(int)genes[i].Value];
                city.prev = prevCity;

                city.next = (i == genes.Length - 1) ? cities[(int)genes[0].Value] : new TspCity();

                m_lr.SetPosition(i, city.Position);
                city.Order = i;
                city.go.GetComponentInChildren<TextMesh>().text = city.Order.ToString();
                prevCity.next = city;
                prevCity = city;
            }

            var initialCity = cities[0];
            
            initialCity.Order = 0;
            initialCity.go.GetComponentInChildren<TextMesh>().text = initialCity.Order.ToString();
            orderedCities.Add(initialCity);
            var iter = initialCity.next;


            int order = 1;
            while (order < m_numberOfCities)
            {
                iter.Order = order++;
                iter.go.GetComponentInChildren<TextMesh>().text = iter.Order.ToString();
                orderedCities.Add(iter);
                iter = iter.next;
            }

               

            var firstCity = cities[(int)genes[0].Value];
            m_lr.SetPosition(m_numberOfCities, firstCity.Position);

        }
    }

    private List<Vector3> DiscretizePlane(Vector3 planeSize, Vector3 planePosition, int interval)
    {
        bool inWall;

        float planeWidth = planeSize.x;
        float planeHeight = planeSize.z;
        int widthDiscretization = Mathf.RoundToInt(planeWidth);
        int heightDiscretization = Mathf.RoundToInt(planeHeight);

        List<Vector3> points = new List<Vector3>();
        
        for (int i = 2; i <= widthDiscretization - 2; i += interval)
        {
            for (int j = 2; j <= heightDiscretization - 2; j += interval)
            {
                float x = i - widthDiscretization / 2 + planePosition.x;
                float z = j - heightDiscretization / 2 + planePosition.z;

                //print(obsManagers.Count);
                Vector2 point2D = new Vector2(x, z);
                inWall = false;
                foreach (var obsManager in obsManagers)
                {

                    if (IsPointInsideRectangle(obsManager.bounds, point2D))
                    {
                        inWall = true;
                        break;
                    }

                }

                if (!inWall)
                {
                    Vector3 point = new Vector3(x, 2.08f, z);
                    points.Add(point);
                }
            }
        }


        return points;
    }

    bool IsPointInsideRectangle(Vector2[] rectangleCorners, Vector2 point)
    {
        int j = rectangleCorners.Length - 1;
        bool inside = false;
        for (int i = 0; i < rectangleCorners.Length; i++)
        {
            if ((rectangleCorners[i].y < point.y && rectangleCorners[j].y >= point.y ||
                rectangleCorners[j].y < point.y && rectangleCorners[i].y >= point.y) &&
                (rectangleCorners[i].x <= point.x || rectangleCorners[j].x <= point.x))
            {
                inside ^= (rectangleCorners[i].x + (point.y - rectangleCorners[i].y) /
                    (rectangleCorners[j].y - rectangleCorners[i].y) *
                    (rectangleCorners[j].x - rectangleCorners[i].x) < point.x);
            }
            j = i;
        }

        return inside;
    }

    public void Reset()
    {
        Debug.ClearDeveloperConsole();
        order = 0;
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    int order = 0;
    private void Update()
    {
        //DrawRoute();

        if (m_isEnabled)
        {
            if (order < m_numberOfCities)
            {
                if (Mathf.Abs(robot.transform.position.x - target.transform.position.x) < 0.1 && Mathf.Abs(robot.transform.position.z - target.transform.position.z) < 0.1)
                {
                    try {
                        orderedCities[order].go.GetComponentInChildren<TextMesh>().color = Color.green;
                        order++;
                        if (order < m_numberOfCities)
                            target.transform.position = orderedCities[order].go.transform.position;
                    }

                    catch
                    {
                        DrawRoute();
                    }
                    
                }
            }
        }
    }

    

}