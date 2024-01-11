using Bogus;
using FluentAssertions;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using NodaTime;

namespace MongoDb.Bson.Serialization.NodaTime.Tests;

public class LocalDateSerializerTest
{
    static LocalDateSerializerTest()
    {
        BsonSerializer.RegisterSerializer(new LocalDateSerializer());
    }

    [Fact]
    public void Serialize_returns_expected_result()
    {
        var faker = new Faker();
        var localDate = LocalDate.FromDateTime(faker.Date.Recent());

        var serialized = localDate.ToJson();
        var deserialized = BsonSerializer.Deserialize<LocalDate>(serialized);

        deserialized.Should().Be(localDate);
    }
}