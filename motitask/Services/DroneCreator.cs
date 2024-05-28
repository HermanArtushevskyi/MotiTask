using System.Linq;
using motitask.Windows.Vectors;

namespace motitask.Services;

public class DroneCreator
{

    public void CreateDrone(DBContext dbContext, string name, int maxDistance, int price, int maxPayload,
        int flightTime, int weight)
    {
        Alternative alternative = new Alternative()
        {
            A_name = name
        };
        
        Mark distanceMark = CreateMaxDistanceMark(maxDistance);
        Mark priceMark = CreatePriceMark(price);
        Mark payloadMark = CreateMaxPayloadMark(maxPayload);
        Mark flightTimeMark = CreateFlightTimeMark(flightTime);
        Mark weightMark = CreateWeightMark(weight);
        

        dbContext.Alternatives.Add(alternative);
        dbContext.Marks.Add(distanceMark);
        dbContext.Marks.Add(priceMark);
        dbContext.Marks.Add(payloadMark);
        dbContext.Marks.Add(flightTimeMark);
        dbContext.Marks.Add(weightMark);
        dbContext.SaveChanges();

        int alternativeId = alternative.A_id;
        int distanceMarkId = distanceMark.M_id;
        int priceMarkId = priceMark.M_id;
        int payloadMarkId = payloadMark.M_id;
        int flightTimeMarkId = flightTimeMark.M_id;
        int weightMarkId = weightMark.M_id;
        
        AddMark(alternativeId, distanceMarkId, dbContext);
        AddMark(alternativeId, priceMarkId, dbContext);
        AddMark(alternativeId, payloadMarkId, dbContext);
        AddMark(alternativeId, flightTimeMarkId, dbContext);
        AddMark(alternativeId, weightMarkId, dbContext);

        dbContext.SaveChanges();
    }

    private void AddMark(int alternativeId, int flightTimeMarkId, DBContext dbContext)
    {
        Vector vector = new Vector()
        {
            A_id = alternativeId,
            M_id = flightTimeMarkId
        };
        dbContext.Vectors.Add(vector);
    }

    private Mark CreateWeightMark(int weight)
    {
        string name;
        int range;
        int numeric;
        int normalized;

        name = weight switch
        {
            >= 1000 => "Важкий",
            >= 500 => "Середній",
            >= 300 => "Легкий",
            _ => "Дуже легкий"
        };

        range = 2;

        numeric = weight;

        normalized = weight switch
        {
            >= 1000 => 5,
            >= 500 => 4,
            >= 300 => 3,
            _ => 2
        };

        return new Mark()
        {
            C_id = 8,
            M_name = name,
            M_range = range,
            M_num = numeric,
            M_norm = normalized
        };
    }

    private Mark CreateFlightTimeMark(int flightTime)
    {
        string name;
        int range;
        int numeric;
        int normalized;

        name = flightTime switch
        {
            >= 300 => "Дуже довго",
            >= 200 => "Довго",
            >= 100 => "Середньо",
            >= 60 => "Коротко",
            _ => "Дуже коротко"
        };

        range = 4;

        numeric = flightTime;

        normalized = flightTime switch
        {
            >= 300 => 5,
            >= 200 => 4,
            >= 100 => 3,
            >= 60 => 2,
            _ => 1
        };

        return new Mark()
        {
            C_id = 7,
            M_name = name,
            M_range = range,
            M_num = numeric,
            M_norm = normalized
        };
    }

    private Mark CreateMaxPayloadMark(int maxPayload)
    {
        string name;
        int range;
        int numeric;
        int normalized;

        name = maxPayload switch
        {
            >= 10 => "Велике",
            >= 7 => "Середнє",
            >= 4 => "Мале",
            >= 2 => "Дуже мале",
            _ => "Мінімальне"
        };

        range = 4;

        numeric = maxPayload;

        normalized = maxPayload switch
        {
            >= 10 => 5,
            >= 7 => 4,
            >= 4 => 3,
            >= 2 => 2,
            _ => 1
        };

        return new Mark()
        {
            C_id = 6,
            M_name = name,
            M_range = range,
            M_num = numeric,
            M_norm = normalized
        };
    }

    private Mark CreatePriceMark(int price)
    {
        string name;
        int range;
        int numeric;
        int normalized;

        name = price switch
        {
            >= 1000 => "Дуже дорого",
            >= 500 => "Дорого",
            >= 300 => "Середньо",
            >= 100 => "Дешево",
            _ => "Дуже дешево"
        };

        range = 5;
        
        numeric = price;

        normalized = price switch
        {
            >= 1000 => 5,
            >= 500 => 4,
            >= 300 => 3,
            >= 100 => 2,
            _ => 1
        };

        return new Mark()
        {
            C_id = 5,
            M_name = name,
            M_range = range,
            M_num = numeric,
            M_norm = normalized
        };
    }

    private Mark CreateMaxDistanceMark(int maxDistance)
    {
        string name;
        int range;
        int numeric;
        int normalized;

        name = maxDistance switch
        {
            >= 1000 => "Гарно",
            >= 500 => "Добре",
            >= 300 => "Середньо",
            >= 100 => "Погано",
            _ => "Дуже погано"
        };

        range = 4;

        numeric = maxDistance;

        normalized = maxDistance switch
        {
            >= 1000 => 5,
            >= 500 => 4,
            >= 300 => 3,
            >= 100 => 2,
            _ => 1
        };

        return new Mark()
        {
            C_id = 4,
            M_name = name,
            M_range = range,
            M_num = numeric,
            M_norm = normalized
        };
    }
}