using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using GeneticSharp.Domain.Chromosomes;
using GeneticSharp.Domain.Fitnesses;
using GeneticSharp.Domain.Randomizations;
using UnityEngine;

public class TspFitness : IFitness
{
    //private Rect m_area;
    GameObject plane;
    public TspFitness(int numberOfCities, GameObject plane, GameObject robot)
    {
        this.plane = plane;
        Cities = new List<TspCity>(numberOfCities);

        var size = Camera.main.orthographicSize - 1;
        //m_area = new Rect(-size, -size, size * 2, size * 2);

        for (int i = 0; i < numberOfCities; i++)
        {
            if (i == 0)
            {
                var city = new TspCity { Position = robot.transform.position };
                city.Order = 0;
                Cities.Add(city);
            }
            else
            {
                var city = new TspCity { Position = GetCityRandomPosition() };
                //Debug.Log(city.Position);
                Cities.Add(city);
            }
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

    private Vector3 GetCityRandomPosition()
    {
        Vector3 pos = PickRandomPointOnPlane();
        return pos;
        //return new Vector3(
        //    RandomizationProvider.Current.GetFloat(m_area.xMin, m_area.xMax + 1),
        //    2.08f,
        //    RandomizationProvider.Current.GetFloat(m_area.yMin, m_area.yMax + 1));
    }

    private static double CalcDistanceTwoCities(TspCity one, TspCity two)
    {
        return Vector3.Distance(one.Position, two.Position);
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

}