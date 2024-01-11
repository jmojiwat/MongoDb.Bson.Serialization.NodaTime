using Bogus;
using FluentAssertions;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using NodaTime;

namespace MongoDb.Bson.Serialization.NodaTime.Tests;

public class PeriodSerializerTest
{
    static PeriodSerializerTest()
    {
        BsonSerializer.RegisterSerializer(new PeriodSerializer());
    }

    [Fact]
    public void Serialize_returns_expected_result()
    {
        var faker = new Faker();
        var period = Period.FromMonths(faker.Random.Int(1, 1000));

        var serialized = period.ToJson();
        var deserialized = BsonSerializer.Deserialize<Period>(serialized);

        deserialized.Should().Be(period);
    }
}