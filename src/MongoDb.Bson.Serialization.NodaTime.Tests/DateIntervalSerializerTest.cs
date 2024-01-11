using Bogus;
using FluentAssertions;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using NodaTime;

namespace MongoDb.Bson.Serialization.NodaTime.Tests;

public class DateIntervalSerializerTest
{
    static DateIntervalSerializerTest()
    {
        BsonSerializer.RegisterSerializer(new DateIntervalSerializer());
    }

    [Fact]
    public void Serialize_returns_expected_result()
    {
        var faker = new Faker();
        var from = LocalDate.FromDateTime(faker.Date.Recent());
        var to = from.PlusDays(faker.Random.Number(1, 1000));


        var annualDate = new DateInterval(from, to);

        var serialized = annualDate.ToJson();
        var deserialized = BsonSerializer.Deserialize<DateInterval>(serialized);

        deserialized.Should().BeEquivalentTo(annualDate);
    }
}