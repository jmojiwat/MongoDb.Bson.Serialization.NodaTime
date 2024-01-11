using Bogus;
using FluentAssertions;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using NodaTime;

namespace MongoDb.Bson.Serialization.NodaTime.Tests;

public class OffsetDateSerializerTest
{
    static OffsetDateSerializerTest()
    {
        BsonSerializer.RegisterSerializer(new OffsetDateSerializer());
    }

    [Fact]
    public void Serialize_returns_expected_result()
    {
        var faker = new Faker();
        var localDate = LocalDate.FromDateTime(faker.Date.Recent());
        var offset = Offset.FromSeconds(faker.Random.Int(1, 500));

        var offsetDate = new OffsetDate(localDate, offset);

        var serialized = offsetDate.ToJson();
        var deserialized = BsonSerializer.Deserialize<OffsetDate>(serialized);

        deserialized.Should().Be(offsetDate);
    }
}