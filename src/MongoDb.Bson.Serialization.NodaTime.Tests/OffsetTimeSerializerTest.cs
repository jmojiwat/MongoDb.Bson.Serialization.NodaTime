using Bogus;
using FluentAssertions;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using NodaTime;

namespace MongoDb.Bson.Serialization.NodaTime.Tests;

public class OffsetTimeSerializerTest
{
    static OffsetTimeSerializerTest()
    {
        BsonSerializer.RegisterSerializer(new OffsetTimeSerializer());
    }

    [Fact]
    public void Serialize_returns_expected_result()
    {
        var faker = new Faker();
        var date = faker.Date.Recent();
        var localTime = new LocalTime(date.Hour, date.Minute, date.Second, date.Millisecond);
        var offset = Offset.FromSeconds(faker.Random.Int(1, 500));

        var offsetTime = new OffsetTime(localTime, offset);

        var serialized = offsetTime.ToJson();
        var deserialized = BsonSerializer.Deserialize<OffsetTime>(serialized);

        deserialized.Should().Be(offsetTime);
    }
}