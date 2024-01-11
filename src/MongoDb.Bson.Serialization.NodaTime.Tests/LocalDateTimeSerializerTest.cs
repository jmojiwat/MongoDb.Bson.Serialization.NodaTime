using Bogus;
using FluentAssertions;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using NodaTime;

namespace MongoDb.Bson.Serialization.NodaTime.Tests;

public class LocalDateTimeSerializerTest
{
    static LocalDateTimeSerializerTest()
    {
        BsonSerializer.RegisterSerializer(new LocalDateTimeSerializer());
    }

    [Fact]
    public void Serialize_returns_expected_result()
    {
        var faker = new Faker();
        var localDateTime = LocalDateTime.FromDateTime(faker.Date.Recent());

        var serialized = localDateTime.ToJson();
        var deserialized = BsonSerializer.Deserialize<LocalDateTime>(serialized);

        deserialized.Should().Be(localDateTime);
    }
}