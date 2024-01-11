using Bogus;
using FluentAssertions;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using NodaTime;

namespace MongoDb.Bson.Serialization.NodaTime.Tests;

public class OffsetDateTimeSerializerTest
{
    static OffsetDateTimeSerializerTest()
    {
        BsonSerializer.RegisterSerializer(new OffsetDateTimeSerializer());
    }

    [Fact]
    public void Serialize_returns_expected_result()
    {
        var faker = new Faker();
        var localDate = LocalDateTime.FromDateTime(faker.Date.Recent());
        var offset = Offset.FromSeconds(faker.Random.Int(1, 500));

        var offsetDateTime = new OffsetDateTime(localDate, offset);

        var serialized = offsetDateTime.ToJson();
        var deserialized = BsonSerializer.Deserialize<OffsetDateTime>(serialized);

        deserialized.Should().Be(offsetDateTime);
    }
}