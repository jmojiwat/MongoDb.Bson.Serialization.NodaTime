using Bogus;
using FluentAssertions;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using NodaTime;

namespace MongoDb.Bson.Serialization.NodaTime.Tests;

public class InstantSerializerTest
{
    static InstantSerializerTest()
    {
        BsonSerializer.RegisterSerializer(new InstantSerializer());
    }

    [Fact]
    public void Serialize_returns_expected_result()
    {
        var faker = new Faker();
        var date = faker.Date.Recent();
        
        var instant = Instant.FromUtc(date.Year, date.Month, date.Day, date.Hour, date.Minute);

        var serialized = instant.ToJson();
        var deserialized = BsonSerializer.Deserialize<Instant>(serialized);

        deserialized.Should().Be(instant);
    }
}