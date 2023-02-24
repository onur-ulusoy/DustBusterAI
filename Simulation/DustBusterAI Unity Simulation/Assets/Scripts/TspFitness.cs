using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using GeneticSharp.Domain.Chromosomes;
using GeneticSharp.Domain.Fitnesses;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public class TspFitness : IFitness
{
    //private Rect m_area;
    GameObject plane;
    [SerializeField] private float wallPenalty = 100f;
    public TspFitness(int numberOfCities, GameObject plane, GameObject robot, string Mode, List<Vector3> points)
    {
        //ai.position = new Vector3(0, 2.08f, 0);
        this.plane = plane;

        //var size = Camera.main.orthographicSize - 1;
        //m_area = new Rect(-size, -size, size * 2, size * 2);

        //for (int i = 0; i < numberOfCities; i++)
        //{
        //if (i == 0)
        //{
        //    var city = new TspCity { Position = robot.transform.position };
        //    city.Order = 0;
        //    Cities.Add(city);
        //}

        switch (Mode)
        {
            case "Random":
                Cities = new List<TspCity>(numberOfCities);

                for (int i = 0; i < numberOfCities; i++)
                {
                    var city = new TspCity { Position = GetCityRandomPosition() };
                    //Debug.Log(city.Position);
                    
                    Cities.Add(city);
                }

                break;

            case "Ordered":
                //var city2 = new TspCity { Position = GetCityRandomPosition() };
                //Cities.Add(city2);
                
                Cities = new List<TspCity>(points.Count);
                InstantiateCities(points);
                break;

            default:
                break;
        }

    }

    public IList<TspCity> Cities { get; private set; }

    public double Evaluate(IChromosome chromosome)
    {
        var genes = chromosome.GetGenes();
        var distanceSum = 0.0;
        var lastCityIndex = Convert.ToInt32(genes[0].Value, CultureInfo.InvariantCulture);
        var citiesIndexes = new List<int>();
        citiesIndexes.Add(lastCityIndex);

        // Calculates the total route distance.
        foreach (var g in genes)
        {
            var currentCityIndex = Convert.ToInt32(g.Value, CultureInfo.InvariantCulture);
            distanceSum += CalcDistanceTwoCities(Cities[currentCityIndex], Cities[lastCityIndex]);
            lastCityIndex = currentCityIndex;

            citiesIndexes.Add(lastCityIndex);
        }

        distanceSum += CalcDistanceTwoCities(Cities[citiesIndexes.Last()], Cities[citiesIndexes.First()]);

        var fitness = 1.0 - (distanceSum / (Cities.Count * 1000.0));

        ((TspChromosome)chromosome).Distance = distanceSum;

        // There is repeated cities on the indexes?
        var diff = Cities.Count - citiesIndexes.Distinct().Count();

        if (diff > 0)
        {
            fitness /= diff;
        }

        if (fitness < 0)
        {
            fitness = 0;
        }

        return fitness;
    }
    private double CalcDistanceTwoCities(TspCity one, TspCity two)
    {
        //Vector3 startPos = one.Position;
        //Vector3 endPos = two.Position;
        //discalc.startPos = startPos;
        //discalc.endPos = endPos;

        //discalc.Scan = true;


        //float distance = discalc.GetDistance(startPos, endPos);
        //float distance = discalc.dist;
        //Debug.Log(startPos.ToString() + endPos + distance);


        //float distance = 2;
        //return (double)distance;
        //Debug.Log(robot.GetComponent<AIDestinationSetter>().ai.position);
        //robot.GetComponent<AIDestinationSetter>().target.position = new Vector3(0, 0, 0);
        //dummyRobot.position = one.Position;
        //dummyTarget.position = two.Position;

        ////DisCalc.one = one.Position;
        ////DisCalc.two = two.Position;
        ////DisCalc.Scan = true;


        //while (DisCalc.Scan);

        //Thread.Sleep(300);
        //Debug.Log(DisCalc.dist+"*");

        //Debug.Log(Vector3.Distance(one.Position, two.Position));
        //return Vector3.Distance(one.Position, two.Position);
        //Debug.Log(++count);
        //Thread.Sleep(3000);

        return GetDistance(one.Number, two.Number);
    }
    public class SaveData
    {
        public string Cache;
        public double Distance;
    }

    public Dictionary<string, double> distances = new Dictionary<string, double>();
    public void ConvertJsonToDictionary()
    {
        string json = File.ReadAllText("C:/Users/onuru/OneDrive/Desktop/DustBusterAI/Simulation/DustBusterAI Unity Simulation/Assets/distance_data.json");

        var dict = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(json);
        var result = new Dictionary<string, double>();
        foreach (var item in dict)
        {
            string cache = (string)item["Cache"];
            double distance = (double)item["Distance"];
            result[cache] = distance;
        }
        distances = result;
    }

    public double GetDistance(int order1, int order2)
    {
        string cache = $"{order1}-{order2}";
        if (distances.ContainsKey(cache))
        {
            double distance = distances[cache];
            //Debug.Log(order1+" "+order2+":"+distance);
            return distance;
        }
        else
        {
            //Debug.Log(distances.ToString());
            //Debug.Assert(false);
            return 0.0;
        }
    }


    private Vector3 GetCityRandomPosition()
    {
        Vector3 pos = PickRandomPointOnPlane();
        return pos;
        //return new Vector3(
        //    RandomizationProvider.Current.GetFloat(m_area.xMin, m_area.xMax + 1),
        //    2.08f,
        //    RandomizationProvider.Current.GetFloat(m_area.yMin, m_area.yMax + 1));
    }

    private Vector3 PickRandomPointOnPlane()
    {
        Vector3 planeSize = plane.GetComponent<Renderer>().bounds.size;
        Vector3 planePosition = plane.transform.position;

        float planeWidth = planeSize.x;
        float planeHeight = planeSize.z;

        float randomX = UnityEngine.Random.Range(-planeWidth / 2, planeWidth / 2) + planePosition.x;
        float randomZ = UnityEngine.Random.Range(-planeHeight / 2, planeHeight / 2) + planePosition.z;
        return new Vector3(randomX, 2.08f, randomZ);
    }

    private void InstantiateCities(List<Vector3> points)
    {
        for (int i = 0; i < points.Count; i++)
        {
            var city = new TspCity { Position = points[i] };
            Cities.Add(city);
        }
    }


}