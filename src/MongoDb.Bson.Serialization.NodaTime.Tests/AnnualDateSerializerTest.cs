using Bogus;
using FluentAssertions;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using NodaTime;

namespace MongoDb.Bson.Serialization.NodaTime.Tests;

public class AnnualDateSerializerTest
{
    static AnnualDateSerializerTest()
    {
        BsonSerializer.RegisterSerializer(new AnnualDateSerializer());
    }

    [Fact]
    public void Serialize_returns_expected_result()
    {
        var faker = new Faker();
        var dateTime = faker.Date.Recent();

        var annualDate = new AnnualDate(dateTime.Month, dateTime.Day);

        var serialized = annualDate.ToJson();
        var deserialized = BsonSerializer.Deserialize<AnnualDate>(serialized);

        deserialized.Should().Be(annualDate);
    }
}