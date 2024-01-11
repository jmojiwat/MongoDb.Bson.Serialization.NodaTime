using Bogus;
using FluentAssertions;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using NodaTime;

namespace MongoDb.Bson.Serialization.NodaTime.Tests;

public class LocalTimeSerializerTest
{
    static LocalTimeSerializerTest()
    {
        BsonSerializer.RegisterSerializer(new LocalTimeSerializer());
    }

    [Fact]
    public void Serialize_returns_expected_result()
    {
        var faker = new Faker();
        var date = faker.Date.Recent();
        var localTime = new LocalTime(date.Hour, date.Minute, date.Second, date.Millisecond);

        var serialized = localTime.ToJson();
        var deserialized = BsonSerializer.Deserialize<LocalTime>(serialized);

        deserialized.Should().Be(localTime);
    }
}